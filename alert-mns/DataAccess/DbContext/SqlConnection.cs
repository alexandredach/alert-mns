using MySql.Data.MySqlClient;
using System.Data;

namespace alert_mns.Database
{
    public class SqlConnection
    {
        public string ConnectionString { get; set; }

        public SqlConnection(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public object ExecuteScalar(string query)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteScalar();
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                DataTable dataTable = new DataTable();
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
        }
        public int ExecuteNonQuery(string query)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
