using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAcougue
{
    public class Conexao
    {
        public class MySqlConnectionManager
        {
            private MySqlConnection connection;
            private string server;
            private string database;
            private string uid;
            private string password;

            public string LastError { get; private set; }

            public MySqlConnectionManager()
            {
                Initialize();
            }

            private void Initialize()
            {
                server = "localhost";
                database = "acougue";
                uid = "root";
                password = "1234";

                string connectionString = $"Server={server}; DATABASE={database}; UID={uid}; PASSWORD={password}";
                connection = new MySqlConnection(connectionString);
            }

            public bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    LastError = ex.Message;
                    return false;
                }
            }

            public bool CloseConnection()
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    LastError = ex.Message;
                    return false;
                }
            }

            public MySqlConnection GetConnect()
            {
                return connection;
            }
        }
    }
}
