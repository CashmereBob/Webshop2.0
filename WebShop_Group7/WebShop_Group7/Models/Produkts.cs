using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebShop_Group7.Models
{
    public class Produkts
    {
       DBConnection connection = new DBConnection();
        SqlDataReader dataReader;

        public DataTable GetAllToDataTable(string query)
        {
            try { 
            connection.OpenConnection();                                   
            DataTable dataTable = new DataTable();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);        
            }
           
            return dataTable;
            }
            catch { }
            finally
            {
                connection.CloseConnection();
                dataReader.Close();
            }

            return null;
        }
    }
}