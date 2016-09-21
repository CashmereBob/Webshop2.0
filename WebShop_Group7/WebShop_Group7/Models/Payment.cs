using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Payment
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllPayments()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Payment"))
                {
                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Provider"), new DataColumn("Service"),
                    new DataColumn("Price")});

                    string sql = "Select * From tbl_Payment";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var provider = myDataReader["Provider"].ToString();
                            var service = myDataReader["Service"].ToString();
                            var price = decimal.Parse(myDataReader["Price"].ToString());




                            dt.Rows.Add(id, provider, service, price);
                        }
                    }
                    myCommand.ExecuteNonQuery();
                    return dt;
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                db.CloseConnection();
            }
        }

    }
}