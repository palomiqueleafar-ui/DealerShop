using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DealerShop
{
    public partial class frmCashier : Form
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();
        private int currentCashierId = 0;
        private decimal vat = 0.12m;


        public frmCashier(int id)
        {
            InitializeComponent();
            this.currentCashierId = id;
            loadProducts();
            LoadPendingItems();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void loadProducts()
        {
            flowLayoutPanel2.Controls.Clear();
            cn = new MySqlConnection(dbcon.MyConnection()); // Use your connection method

            try
            {
                cn.Open();

                // Query to fetch available products (where stock > 0)
                string query = "SELECT id, prod_model, prod_brand, prod_price, prod_quantity, image_path FROM products WHERE prod_quantity > 0";

                cm = new MySqlCommand(query, cn);
                MySqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Car_card card = new Car_card();

                    // Set the card properties using database data
                    card.ProductID = dr["id"].ToString();
                    string carName = $"{dr["prod_brand"].ToString()} {dr["prod_model"].ToString()}";
                    card.ProductName = carName;

                    if (decimal.TryParse(dr["prod_price"].ToString(), out decimal price))
                    {
                        card.ProductPrice = $"₱ {price:N2}"; // Format price for display
                    }
                    else
                    {
                        card.ProductPrice = "Price Error";
                    }

                    // Load image dynamically (Ensure 'CarImages' folder exists in your execution directory)
                    string imgPath = Path.Combine(Application.StartupPath, "CarImages", dr["image_path"].ToString());
                    if (File.Exists(imgPath))
                        card.CarImage = System.Drawing.Image.FromFile(imgPath);
                    else
                        card.CarImage = null;

                    // **Crucial:** Attach the click handler
                    card.Click += CarCard_Click;

                    flowLayoutPanel2.Controls.Add(card);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        public void CarCard_Click(object sender, EventArgs e)
        {
            Car_card card = (Car_card)sender;
            string id = card.ProductID;

            if (currentCashierId == 0) return; // Safety check

            cn = new MySqlConnection(dbcon.MyConnection());

            try
            {
                cn.Open();

                // 1. Check stock
                cm = new MySqlCommand("SELECT prod_quantity FROM products WHERE id = @id", cn);
                cm.Parameters.AddWithValue("@id", id);
                int stock = Convert.ToInt32(cm.ExecuteScalar());

                if (stock <= 0)
                {
                    MessageBox.Show("This car is sold out!", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Add {card.ProductName} to order?", "Add Car", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 2. Check if item is already in pending_cars for THIS cashier
                    cm = new MySqlCommand("SELECT COUNT(*) FROM pending_cars WHERE cashier_id = @cashier AND product_id = @product_id", cn);
                    cm.Parameters.AddWithValue("@cashier", currentCashierId);
                    cm.Parameters.AddWithValue("@product_id", id);
                    int count = Convert.ToInt32(cm.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show($"{card.ProductName} is already in the current order.", "Already Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        // 3. Insert new item into pending_cars (no price column needed here)
                        cm = new MySqlCommand(
                            "INSERT INTO pending_cars (cashier_id, product_id, quantity) VALUES (@cashier, @product_id, 1)", cn);
                    }
                    cm.Parameters.AddWithValue("@cashier", currentCashierId);
                    cm.Parameters.AddWithValue("@product_id", id);
                    cm.ExecuteNonQuery();

                    // 4. Decrement stock in the main inventory
                    cm = new MySqlCommand("UPDATE products SET prod_quantity = prod_quantity - 1 WHERE id = @id", cn);
                    cm.Parameters.AddWithValue("@id", id);
                    cm.ExecuteNonQuery();

                    LoadPendingItems(); // Update cart grid and totals
                    loadProducts();     // Refresh product card view
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding car to order: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        public void LoadPendingItems()
        {
            try
            {
                dataGridViewOrder.Rows.Clear(); // Assuming your cart DGV is named dataGridViewOrder

                cn = new MySqlConnection(dbcon.MyConnection());
                cn.Open();

                // Query: Joins pending_cars with products to get the car name/model and the CURRENT price.
                string query = @"
            SELECT 
                pc.id AS pending_id,
                p.prod_brand,
                p.prod_model,
                p.prod_price, -- Fetching price from products table
                pc.quantity
            FROM pending_cars pc
            JOIN products p ON pc.product_id = p.id
            WHERE pc.cashier_id = @cashier";

                cm = new MySqlCommand(query, cn);
                cm.Parameters.AddWithValue("@cashier", currentCashierId);

                MySqlDataReader dr = cm.ExecuteReader();

                decimal subTotals = 0;
                int totalItems = 0;

                while (dr.Read())
                {
                    string carName = $"{dr["prod_brand"].ToString()} {dr["prod_model"].ToString()}";

                    // Parse prod_price (VARCHAR) to DECIMAL
                    decimal price = decimal.Parse(dr["prod_price"].ToString());
                    int quantity = Convert.ToInt32(dr["quantity"]);
                    decimal lineTotal = price * quantity;

                    // Add row to the DataGridView (Ensure indices match your column setup!)
                    dataGridViewOrder.Rows.Add(
                        dr["pending_id"].ToString(),
                        carName,
                        dr["prod_model"].ToString(),
                        price.ToString("N2")
                        );

                    subTotals += lineTotal;
                    totalItems += quantity;
                }
                dr.Close();

                // Calculation of Totals
                decimal totalTax = subTotals * vat;
                decimal totalAmount = subTotals + totalTax;

                // Update UI Labels (e.g., label_items, label_total)
                label_items.Content = totalItems.ToString();
                label_total.Content = totalAmount.ToString("N2");
                cuiTextBoxPayment.Tag = totalAmount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cart: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }


        private void btn_complete_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewOrder.Rows.Count == 0) return;
            if (!decimal.TryParse(cuiTextBoxPayment.Tag?.ToString(), out decimal totalAmount))
            {
                MessageBox.Show("Internal Error: Could not determine total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Parsing the Payment Received from the Content (what the cashier typed)
            if (!decimal.TryParse(cuiTextBoxPayment.Content?.ToString(), out decimal paymentReceived))
            {
                MessageBox.Show("Please enter a valid numeric value for Payment Received.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal changeDue = paymentReceived - totalAmount;

            DialogResult result = MessageBox.Show(
                $"Total: ₱ {totalAmount:N2}\nReceived: ₱ {paymentReceived:N2}\nChange Due: ₱ {changeDue:N2}\n\nFinalize Transaction?",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cn = new MySqlConnection(dbcon.MyConnection());
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();
                int transaction_id = 0;

                try
                {
                    // A. Insert Transaction Record (Uses the three columns C# code expects)
                    // NOTE: This SQL relies on 'car', 'payment', etc. having NULL defaults in the DB!
                    cm = new MySqlCommand(
                        "INSERT INTO transactions (cashier_id, total, payment_received, change_due, transaction_date) " +
                        "VALUES (@cashier_id, @total, @received, @change, NOW()); SELECT LAST_INSERT_ID();", cn, transaction);

                    cm.Parameters.AddWithValue("@cashier_id", currentCashierId);
                    cm.Parameters.AddWithValue("@total", totalAmount);
                    cm.Parameters.AddWithValue("@received", paymentReceived);
                    cm.Parameters.AddWithValue("@change", changeDue);
                    transaction_id = Convert.ToInt32(cm.ExecuteScalar());

                    // B. Move Items (This part remains correct)
                    cm = new MySqlCommand(
                        @"INSERT INTO transaction_items (transaction_id, id, quantity, price) 
                  SELECT 
                      @transaction_id, 
                      pc.product_id, 
                      pc.quantity, 
                      CAST(p.prod_price AS DECIMAL(10, 2))
                  FROM pending_cars pc
                  JOIN products p ON pc.product_id = p.id
                  WHERE pc.cashier_id = @cashier_id", cn, transaction);

                    cm.Parameters.AddWithValue("@transaction_id", transaction_id);
                    cm.Parameters.AddWithValue("@cashier_id", currentCashierId);
                    cm.ExecuteNonQuery();

                    // C. Clear the Pending Cars
                    cm = new MySqlCommand("DELETE FROM pending_cars WHERE cashier_id = @cashier_id", cn, transaction);
                    cm.Parameters.AddWithValue("@cashier_id", currentCashierId);
                    cm.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show($"Sale Completed! Change Due: ₱ {changeDue:N2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cuiTextBoxPayment.Content = "";
                    LoadPendingItems();
                    loadProducts();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Transaction Failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
        }
        

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel and clear the entire order? Inventory will be restored.", "Cancel Order",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cn = new MySqlConnection(dbcon.MyConnection());
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // 1. Get items to return stock
                    MySqlCommand getItems = new MySqlCommand(
                        "SELECT product_id, quantity FROM pending_cars WHERE cashier_id = @cashier", cn, transaction);
                    getItems.Parameters.AddWithValue("@cashier", currentCashierId);
                    MySqlDataReader dr = getItems.ExecuteReader();

                    List<(string productId, int qty)> itemsToReturn = new List<(string, int)>();
                    while (dr.Read())
                    {
                        itemsToReturn.Add((dr["product_id"].ToString(), Convert.ToInt32(dr["quantity"])));
                    }
                    dr.Close();

                    // 2. Return stock to the main inventory (products table)
                    foreach (var item in itemsToReturn)
                    {
                        MySqlCommand updateStock = new MySqlCommand(
                            "UPDATE products SET prod_quantity = prod_quantity + @qty WHERE id = @product_id", cn, transaction);
                        updateStock.Parameters.AddWithValue("@qty", item.qty);
                        updateStock.Parameters.AddWithValue("@product_id", item.productId);
                        updateStock.ExecuteNonQuery();
                    }

                    // 3. Delete items from the pending_cars table
                    cm = new MySqlCommand("DELETE FROM pending_cars WHERE cashier_id = @cashier", cn, transaction);
                    cm.Parameters.AddWithValue("@cashier", currentCashierId);
                    cm.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Order cancelled and cart cleared. Inventory restored.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Clean up UI
                    cuiTextBoxPayment.Content = "";
                    LoadPendingItems();
                    loadProducts();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error cancelling order: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.ShowDialog();
        }
    }
}
