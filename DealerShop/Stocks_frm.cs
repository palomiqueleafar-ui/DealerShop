using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class Stocks_frm : UserControl
    {
        MySqlConnection cn = new MySqlConnection(new DBConnection().MyConnection());
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();

            return path;
        }
        public Stocks_frm()
        {
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = true;
        }
        
        private void Stocks_frm_Load(object sender, EventArgs e)
        {
            int radius = 20;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = GetRoundedPath(rect, radius);
            this.Region = new Region(path);

            LoadProducts();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            addCar_frm addCar = new addCar_frm();

            // Refresh when addCar closes
            addCar.FormClosed += (s, args) => LoadProducts();

            addCar.ShowDialog();

        }

       

        private void LoadProducts()
        {
            
            try
            {
                using (MySqlConnection localCn = new MySqlConnection(dbcon.MyConnection()))
                {
                    localCn.Open();
                    string query = @"SELECT id, prod_brand, prod_model, prod_year, prod_color, prod_price, prod_quantity, image_path 
                         FROM products 
                         WHERE id = @id";   

                    MySqlDataAdapter da = new MySqlDataAdapter(query, localCn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
                  
            }
            
                catch (Exception ex)
            {
                MessageBox.Show("Error loading products:\n\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   

        

        private void add_btn_Click_1(object sender, EventArgs e)
        {
            addCar_frm addCar = new addCar_frm();

            // Refresh when addCar closes
            addCar.FormClosed += (s, args) => LoadProducts();

            addCar.ShowDialog();
        }

      

        private void del_btn_Click_1(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("Please select a product to delete.",
            //        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Get selected ID (assuming first column = id)
            //string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();

            //DialogResult result = MessageBox.Show(
            //    "Are you sure you want to delete this product?",
            //    "Confirm Delete",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question
            //);

            //if (result == DialogResult.Yes)
            //{
            //    try
            //    {
            //        cn.Open();
            //        string query = "DELETE FROM products WHERE id = @id";
            //        MySqlCommand cmd = new MySqlCommand(query, cn);
            //        cmd.Parameters.AddWithValue("@id", id);
            //        cmd.ExecuteNonQuery();
            //        cn.Close();

            //        MessageBox.Show("Product deleted successfully!",
            //            "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        LoadProducts(); // refresh table
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error deleting product:\n\n" + ex.Message,
            //                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void clear_btn_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will delete ALL products! Continue?", "Confirm Clear All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
);

            if (result == DialogResult.Yes)
            {
                try
                {
                    cn.Open();
                    string query = "DELETE FROM products";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("All products cleared!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProducts(); // refresh table
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error clearing products:\n\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
            }
        }

       

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
