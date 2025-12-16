using MySql.Data.MySqlClient;  
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class Form1 : Form
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();
        public Form1()
        {
            InitializeComponent();
            cn = new MySqlConnection(dbcon.MyConnection());

            txtPassword.UseSystemPasswordChar = true;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                cn.Open();

                cm = new MySqlCommand("SELECT * FROM users WHERE username=@username AND password_=@password", cn);
                cm.Parameters.AddWithValue("@username", username);
                cm.Parameters.AddWithValue("@password", password);

                MySqlDataReader dr = cm.ExecuteReader();

                if (dr.Read())
                {
                    int cashierId = Convert.ToInt32(dr["id"]);
                    string role = dr["role"].ToString();

                    MessageBox.Show("Login Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // 1. If the role is Admin, open the Admin Dashboard
                        Admin_DashBoard dashboard = new Admin_DashBoard(role); 
                        dashboard.Show();
                        this.Hide();
                    }
                    else if (role.Equals("Cashier", StringComparison.OrdinalIgnoreCase))
                    {
                        // 2. If the role is Cashier, open the Cashier Form
                        frmCashier cashier = new frmCashier(cashierId);
                        cashier.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Handle any other unexpected roles
                        MessageBox.Show("Login successful, but unauthorized role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(170, 23, 42, 55);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }
    }      
}

