using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class DBConnection
    {
        public SqlConnection _connection = new SqlConnection();
        private string _connectionString = @"Data Source = (local); Network Library = DBMSSOCN; Initial Catalog = WebShopGr7; User ID =grupp7; password = 1234567; integrated Security = true";
        


        public DBConnection()
        {
            AddAdmin();
        }

        public void OpenConnection()
        {
            _connection.ConnectionString = _connectionString;
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void AddAdmin()
        {
            var admin = new List<int>();
            try
            {
                OpenConnection();
                string sql1 = "Select * From tbl_User";
                SqlCommand myCommand = new SqlCommand(sql1, _connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        admin.Add(int.Parse(myDataReader["ID"].ToString()));
                    }
                }
                myCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {

                CloseConnection();
            }

            if (admin.Count() < 1) { 
            try
            {
                OpenConnection();
                var user = new UserService();

                var salt = user.CreateSalt(10);
                var password = user.GenerateSHA256Hash("password", salt);

                string sql = $"Insert Into tbl_User (Firstname, Lastname, Adress, Postalcode, City, Email, Telephone, Mobilephone, Password, Salt, Pricegroup, Company, Admin) Values('Admin', 'Admin', 'Admin', 'Admin', 'Admin', 'Admin', 'Admin', 'Admin', '{password}', '{salt}', '1', 'Admin', '1' )";

                SqlCommand insertCmd = new SqlCommand(sql, _connection);
                insertCmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                CloseConnection();
            }
            }
        }

        public string ConnectionStatus()
        {
            
            
            var databas = _connection.Database;
            
            
            return databas;
        }
    }
}