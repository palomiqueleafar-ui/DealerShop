using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DealerShop
{
    internal class DBConnection
    {
        public string MyConnection()
        {

            return "server=localhost;uid=root;password=leafarpalomique;database=dealershopdb;";
        }

    }
}
