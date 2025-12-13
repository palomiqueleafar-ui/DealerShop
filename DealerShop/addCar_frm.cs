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
        public event EventHandler DataSaved;
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();
        private Action loadProducts;
        private string _productId = "";
        private string _currentImagePath = "";
        public addCar_frm()
        {
            InitializeComponent();

            cn = new MySqlConnection(dbcon.MyConnection());
        }

        protected virtual void OnDataSaved(EventArgs e)
        {
            // Tiyakin na may subscribers bago tawagin
            DataSaved?.Invoke(this, e);
        }

        public void LoadRecord(string id, string brand, string model, string year, string color, string price, string quantity, string imagePath)
        {
            // I-store ang ID para sa UPDATE query
            _currentImagePath = imagePath;
            _productId = id;

            // I-populate ang textboxes
            savebtn_brand.Text = brand;
            savebtn_model.Text = model;
            savebtn_year.Text = year;
            savebtn_color.Text = color;
            savebtn_price.Text = price;
            savebtn_quantity.Text = quantity;
            saveCars_imageView.ImageLocation = imagePath;

            if (File.Exists(imagePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);

                            // I-set ang Image property MULA SA MEMORY
                            saveCars_imageView.Image = Image.FromStream(ms);

                            // ** TANGGALIN ITO: saveCars_imageView.ImageLocation = imagePath; **
                            // Ito ang naglo-lock sa file!
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not load image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saveCars_imageView.Image = null;
                    saveCars_imageView.ImageLocation = null;
                }
            }
            else
            {
                saveCars_imageView.Image = null;
                saveCars_imageView.ImageLocation = null;
            }

            
            save_btn.Visible = false;
            btn_Update.Visible = true;

            
            this.Text = "Edit Product Information";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                DateTime dateToday = DateTime.Now;

                // ========== SAVE IMAGE ==========
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = Path.Combine("Product_Directory", savebtn_brand.Text.Trim() + ".jpg");
                string path = Path.Combine(baseDirectory, relativePath);

                string directoryPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                File.Copy(saveCars_imageView.ImageLocation, path, true);

                // ========== INSERT DATA  ==========
                string insertData = "INSERT INTO products (prod_brand, prod_model, prod_year, prod_color, prod_price, prod_quantity, image_path, date_added) " +
                "VALUES (@prod_brand, @prod_model, @prod_year, @prod_color, @prod_price, @prod_quantity, @image_path, @date_added)";

                using (MySqlCommand insertCmd = new MySqlCommand(insertData, cn))
                {
                    insertCmd.Parameters.AddWithValue("@prod_brand", savebtn_brand.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_model", savebtn_model.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_year", savebtn_year.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_color", savebtn_color.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_price", savebtn_price.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@prod_quantity", savebtn_quantity.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@image_path", path);
                    insertCmd.Parameters.AddWithValue("@date_added", dateToday);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product saved successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                OnDataSaved(EventArgs.Empty);


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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Tiyakin na ang _productId ay na-set sa iyong LoadRecord method
            if (string.IsNullOrEmpty(_productId))
            {
                MessageBox.Show("Error: Product ID not set for update.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1. INPUT VALIDATION
                if (string.IsNullOrEmpty(savebtn_brand.Text.Trim()) ||
                    string.IsNullOrEmpty(savebtn_model.Text.Trim()) ||
                    string.IsNullOrEmpty(savebtn_year.Text.Trim()) ||
                    string.IsNullOrEmpty(savebtn_price.Text.Trim()) ||
                    string.IsNullOrEmpty(savebtn_quantity.Text.Trim()) ||
                    string.IsNullOrEmpty(saveCars_imageView.ImageLocation))
                {
                    MessageBox.Show("Please complete all product fields and import an image!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cn.State == ConnectionState.Closed)
                    cn.Open();

                // 2. SAVE IMAGE (Image Path Logic is correct for copying the file)
                string prodBrand = savebtn_brand.Text.Trim();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = Path.Combine("Product_Directory", prodBrand + ".jpg");
                string imagePath = Path.Combine(baseDirectory, relativePath);

                string directoryPath = Path.GetDirectoryName(imagePath);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                if (saveCars_imageView.Image != null)
                {
                    // Ito ang magre-release ng lock sa file.
                    // Kailangan itong gawin bago ang File.Copy
                    saveCars_imageView.Image.Dispose();
                }

                // Copy the new image over the old one (if imported)
                File.Copy(saveCars_imageView.ImageLocation, imagePath, true);


                // ** 3. MALING SQL AYUSIN: Palitan ang INSERT ng UPDATE **
                string updateData = @"UPDATE products SET 
                              prod_brand = @prod_brand, 
                              prod_model = @prod_model, 
                              prod_year = @prod_year, 
                              prod_color = @prod_color, 
                              prod_price = @prod_price, 
                              prod_quantity = @prod_quantity, 
                              image_path = @image_path 
                              WHERE id = @id"; // <--- DAPAT MAY WHERE CLAUSE!

                cm.Connection = cn;
                cm.CommandText = updateData;
                cm.Parameters.Clear();

                // 4. PARAMETER ASSIGNMENT
                cm.Parameters.AddWithValue("@prod_brand", prodBrand);
                cm.Parameters.AddWithValue("@prod_model", savebtn_model.Text.Trim());
                cm.Parameters.AddWithValue("@prod_year", savebtn_year.Text.Trim());
                cm.Parameters.AddWithValue("@prod_color", savebtn_color.Text.Trim());
                cm.Parameters.AddWithValue("@prod_price", savebtn_price.Text.Trim());
                cm.Parameters.AddWithValue("@prod_quantity", savebtn_quantity.Text.Trim());
                cm.Parameters.AddWithValue("@image_path", imagePath);
                cm.Parameters.AddWithValue("@id", _productId);

                // 5. EXECUTION
                cm.ExecuteNonQuery();

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during update:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        private void addCar_frm_Load(object sender, EventArgs e)
        {

        }
    }
}
        
   
