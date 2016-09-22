using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Carrier
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllCarriers()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Carrier"))
                {
                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Carrier"), new DataColumn("Service"),
                    new DataColumn("Price")});

                    string sql = "Select * From tbl_Carrier";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var carrier = myDataReader["Carrier"].ToString();
                            var service = myDataReader["Service"].ToString();
                            var price = decimal.Parse(myDataReader["Price"].ToString());




                            dt.Rows.Add(id, carrier, service, price);
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