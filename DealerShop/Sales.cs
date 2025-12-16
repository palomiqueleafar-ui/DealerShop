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

            try
            {
                cn = new MySqlConnection(dbcon.MyConnection());
                cn.Open();

                // REVISED QUERY: Joins transactions (t), users (u), transaction_items (ti), and products (p)
                // to get the full sale details and the car name.
                string query = @"
            SELECT 
                t.transaction_id,
                GROUP_CONCAT(CONCAT(p.prod_brand, ' ', p.prod_model) SEPARATOR ', ') AS car_name, -- Concatenate all items in the transaction
                t.total,
                t.payment_received,  -- Use the corrected column name
                t.change_due,        -- Use the corrected column name
                t.transaction_date AS date_sold, -- Use the corrected column name
                u.username AS cashier_name
            FROM transactions t 
            JOIN users u ON t.cashier_id = u.id 
            JOIN transaction_items ti ON t.transaction_id = ti.transaction_id
            JOIN products p ON ti.id = p.id
            GROUP BY t.transaction_id, t.total, t.payment_received, t.change_due, t.transaction_date, u.username
            ORDER BY t.transaction_id DESC";

                cm = new MySqlCommand(query, cn);
                MySqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    dataGridView1.Rows.Add(
                        dr["transaction_id"].ToString(),
                        dr["car_name"].ToString(),           // Using the concatenated car name
                        dr["total"].ToString(),
                        dr["payment_received"].ToString(),   // Using the correct column
                        dr["change_due"].ToString(),         // Using the correct column
                        dr["cashier_name"].ToString(),
                        dr["date_sold"].ToString()           // Using the correct column
                    );
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
