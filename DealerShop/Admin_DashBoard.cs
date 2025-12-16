using System;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class Admin_DashBoard : Form
    {
        private string userRole;
        public Admin_DashBoard(string userRole)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userRole = userRole;
        }

        private void ShowUserControl(UserControl userControl)
        {
            adminPanel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            adminPanel.Controls.Add(userControl);
        }


        private void dash_btn_Click(object sender, EventArgs e)
        {
            frmDashboard dashboardControl = new frmDashboard();
            ShowUserControl(dashboardControl);
        }

        private void inventory_btn_Click_1(object sender, EventArgs e)
        {
            frmInventory inventoryControl = new frmInventory();
            ShowUserControl(inventoryControl);
        }

        private void btn_Transaction_Click(object sender, EventArgs e)
        {
            Sales trasanctionControl = new Sales();
            ShowUserControl(trasanctionControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 login = new Form1(); 
                login.Show();
                this.Hide();
            }
        }
    }
}
