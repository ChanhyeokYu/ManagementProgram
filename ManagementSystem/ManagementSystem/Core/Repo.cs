using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace ManagementSystem.Core
{
    internal class Repo
    {
        private readonly string _connString;
        public Repo(string connString)
        {
            _connString = connString;
        }

        public DataTable GetData()
        {
            SqlConnection connection = new SqlConnection(_connString);
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM dbo.myTable";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }


    }
}
