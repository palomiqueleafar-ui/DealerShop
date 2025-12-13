using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class Cashier : Form
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();

        private string userRole;
        public Cashier(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }
    }
}
