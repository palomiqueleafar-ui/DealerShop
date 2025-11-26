using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class Admin_DashBoard : Form
    {
        private string userRole;
        public Admin_DashBoard(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;
        }

        private void Admin_DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            Inverntory_System inventoryForm = new Inverntory_System();
            inventoryForm.Show();
        }
    }
}
