using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class frmInventory : UserControl
    {
        MySqlConnection cn = new MySqlConnection(new DBConnection().MyConnection());
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();

        public frmInventory()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            dataGridView1.Rows.Clear();

            // Reset the ID of the DataGridView to avoid issues with row indexing
            int i = 0;

            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                // 1. SQL SELECT Command
                // Ensure you select all the columns you need for the grid.
                string query = @"SELECT id, prod_brand, prod_model, prod_year, prod_color, prod_price, prod_quantity, image_path, date_added
                         FROM products 
                         ORDER BY prod_brand ASC";

                cm.Connection = cn;
                cm.CommandText = query;
                cm.Parameters.Clear(); // Ensure no parameters from previous commands interfere

                MySqlDataReader dr = cm.ExecuteReader();

                
                

                // 2. Read Data and Populate DataGridView
                while (dr.Read())
                {
                    i += 1;
                    string rawDate = dr.GetDateTime("date_added").ToString();
                    string formattedDate = DateTime.Parse(rawDate).ToShortDateString();
                    string imagePath = dr["image_path"].ToString();
                    
                    int rowIndex = dataGridView1.Rows.Add(
                        dr["id"].ToString(),             // 0. The unique ID (used for Edit/Delete)
                        dr["prod_brand"].ToString(),     // 1. Brand
                        dr["prod_model"].ToString(),     // 2. Model
                        dr["prod_year"].ToString(),      // 3. Year
                        dr["prod_color"].ToString(),     // 4. Color
                        dr["prod_price"].ToString(),     // 5. Price
                        dr["prod_quantity"].ToString(),   // 6. Quantity
                        imagePath,
                        formattedDate // Note: image_path is typically not displayed but used for the edit form
                    );

                    // 3. Low Stock Alert Logic (Optional, based on your previous example)
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products:\n\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {

            addCar_frm addCar = new addCar_frm();
            addCar.DataSaved += AddCar_DataSaved;
            addCar.TopLevel = false;
            panel1.Controls.Add(addCar);
            addCar.BringToFront();
            addCar.Show();
        }
        private void AddCar_DataSaved(object sender, EventArgs e)
        {
            // Kapag tinawag, i-refresh ang DataGridView
            LoadProducts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the name of the column that was clicked
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Get the ID of the product from the selected row (Assumed to be column index 0)
            // We need this ID for both Edit and Delete actions.
            string productId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            // --- 1. HANDLE DELETE ACTION (colDelete) ---
            if (colName == "colDelete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed)
                            cn.Open();

                       
                        cm = new MySqlCommand("DELETE FROM products WHERE id = @id", cn);
                        cm.Parameters.Clear();
                        cm.Parameters.AddWithValue("@id", productId);
                        cm.ExecuteNonQuery();

                        MessageBox.Show("Product has been successfully deleted.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // After successful deletion, refresh the list
                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                            cn.Close();
                    }
                }
            }
            if (colName == "colEdit")
            {
                
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string brand = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string model = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string year = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string color = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string price = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                string quantity = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                // ** IMPORTANT: Dapat na-add mo na ang Hidden Column (index 7) sa DataGridView **
                // Tingnan ang previous instructions para dito.
                string imagePath = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                // 2. Ipakita ang addCar_frm para sa pag-edit
                addCar_frm editCar = new addCar_frm();

                // ** I-subscribe ang DataSaved Event (para mag-refresh ang grid pagkatapos mag-update) **
                editCar.DataSaved += AddCar_DataSaved;

                // 3. I-load ang data sa edit form at i-set ang mode sa UPDATE
                // Kailangan mong idagdag ang LoadRecord method sa addCar_frm (tingnan sa ibaba)
                editCar.LoadRecord(id, brand, model, year, color, price, quantity, imagePath);
                editCar.TopLevel = false;
                panel1.Controls.Add(editCar);

                // Ipakita ang form
                
                editCar.BringToFront();
                editCar.Show();
            }


        }
    }
}
