using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadConsole.DBHelper
{
    public class MySqlConnectionHelper
    {
        public static MySqlConnection OpenConnection(string connectionStr)
        {
            MySqlConnection conn = new MySqlConnection(connectionStr);
            conn.Open();

            return conn;
        }

    }
}
