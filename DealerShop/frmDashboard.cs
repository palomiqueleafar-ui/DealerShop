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
    public partial class frmDashboard : UserControl
    {
        MySqlConnection cn = new MySqlConnection();
        DBConnection dbcon = new DBConnection();
        public frmDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            cn = new MySqlConnection(dbcon.MyConnection());
            cn.Open();
            MySqlDataReader dr;

            try
            {
                // 1. Available Cars Stock (Sum of prod_quantity)
                string stockQuery = "SELECT SUM(prod_quantity) AS total_stock FROM products";
                MySqlCommand cmStock = new MySqlCommand(stockQuery, cn);

                dr = cmStock.ExecuteReader();
                if (dr.Read())
                {
                    // Check for null result (if no products)
                    label_stocks.Text = dr["total_stock"] == DBNull.Value ? "0" : dr["total_stock"].ToString();
                }
                dr.Close();

                // 2. Sales Today (Count of transactions for the current date)
                string salesTodayQuery = "SELECT COUNT(transaction_id) AS sales_count FROM transactions WHERE DATE(transaction_date) = CURDATE()";
                MySqlCommand cmSalesToday = new MySqlCommand(salesTodayQuery, cn);

                dr = cmSalesToday.ExecuteReader();
                if (dr.Read())
                {
                    label_Sales.Text = dr["sales_count"].ToString();
                }
                dr.Close();

                // 3. Total Income / Total Sales (Sum of total for all time)
                // Assuming "TOTAL INCOME" and "TOTAL REVENUE" both refer to the cumulative sales amount.
                string totalIncomeQuery = "SELECT SUM(total) AS total_amount FROM transactions";
                MySqlCommand cmTotalIncome = new MySqlCommand(totalIncomeQuery, cn);

                dr = cmTotalIncome.ExecuteReader();
                if (dr.Read())
                {
                    decimal totalIncome = dr["total_amount"] == DBNull.Value ? 0m : Convert.ToDecimal(dr["total_amount"]);
                    // Set both labels to the same value, formatted as currency (₱)
                    label_Income.Text = totalIncome.ToString("N2");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Dashboard data: " + ex.Message, "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }
    }
}
