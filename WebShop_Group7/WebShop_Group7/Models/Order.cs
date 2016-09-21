using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Order
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllOrders()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Order"))
                {
                    dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("UserID") });

                    string sql = "Select * From tbl_Order";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);

                    


                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        var hepp = "hej";
                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var user = myDataReader["UserID"].ToString();

                            dt.Rows.Add(id, user);
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
