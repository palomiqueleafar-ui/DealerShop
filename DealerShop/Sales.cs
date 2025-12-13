using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class Sales : UserControl
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        DBConnection dbcon = new DBConnection();
        public Sales()
        {
            InitializeComponent();
            LoadTransaction();
        }

        private void LoadTransaction()
        {
            dataGridView1.Rows.Clear();

            cn = new MySqlConnection(dbcon.MyConnection());
            cn.Open();

            string query = @"SELECT t.transaction_id, t.car, t.total, t.amount_tendered, t.change_amount, t.date AS date_sold, u.username AS cashier_name
            FROM transactions t JOIN users u ON t.cashier_id = u.id ORDER BY t.transaction_id DESC";

            cm = new MySqlCommand(query, cn);
            MySqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {

                dataGridView1.Rows.Add(
                        dr["transaction_id"].ToString(),
                        dr["car"].ToString(),            
                        dr["total"].ToString(),
                        dr["amount_tendered"].ToString(),
                        dr["change_amount"].ToString(),
                        dr["cashier_name"].ToString(),
                        dr["date_sold"].ToString()
                    );
            }
            dr.Close();
            cn.Close();
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }
    }
}
