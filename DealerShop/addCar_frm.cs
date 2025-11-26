using MySql.Data.MySqlClient;
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

namespace DealerShop
{
    public partial class addCar_frm : Form
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();

        public addCar_frm()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.MyConnection());
        }

        private void import_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    saveCars_imageView.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                // ========== SAVE IMAGE ==========
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = Path.Combine("Product_Directory", savebtn_brand.Text.Trim() + ".jpg");
                string path = Path.Combine(baseDirectory, relativePath);

                string directoryPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                File.Copy(saveCars_imageView.ImageLocation, path, true);

                // ========== INSERT DATA  ==========
                string insertData = "INSERT INTO products (prod_brand, prod_model, prod_year, prod_color, prod_price, prod_quantity, image_path) " +
    "VALUES (@prod_brand, @prod_model, @prod_year, @prod_color, @prod_price, @prod_quantity, @image_path)";

                using (MySqlCommand insertCmd = new MySqlCommand(insertData, cn))
                {
                    insertCmd.Parameters.AddWithValue("@prod_brand", savebtn_brand.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_model", savebtn_model.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_year", savebtn_year.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_color", savebtn_color.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_price", savebtn_price.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_quantity", savebtn_quantity.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@image_path", path);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product saved successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed!\n\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();  
            }
        }
    }
}
