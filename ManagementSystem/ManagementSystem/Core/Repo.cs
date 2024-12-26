using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Data.Common;
using System.Reflection.Emit;

namespace ManagementSystem.Core
{
    internal class Repo
    {
        private SqlConnection _connection;
        private readonly string _connString;
        public Repo(string connString)
        {
            _connString = connString;
        }

        public SqlConnection SqlConnectionFunc()
        {
            SqlConnection connection = new SqlConnection(_connString);

            return connection;
        }

        public DataTable GetData()
        {
            _connection = SqlConnectionFunc();
            {
                try
                {
                    _connection.Open();
                    string sql = "SELECT * FROM dbo.myTable";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public void DeleteData()
        {
            _connection = SqlConnectionFunc();
            {
                try
                {
                    _connection.Open();
                    string sql = "SELECT * FROM dbo.myTable";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
                    adapter.DeleteCommand = new SqlCommand("DELETE FROM myTable WHERE No = @No", _connection);
                    adapter.DeleteCommand.Parameters.Add("@No", SqlDbType.Int, 4, "No");
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        if (row["No"].ToString() == "1")
                        {
                            row.Delete();
                        }
                    }
                    adapter.Update(table);
                 }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    _connection.Close();
                }

            }

        }
    }
}
