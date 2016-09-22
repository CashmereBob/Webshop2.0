using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Pages
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllPages()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Page"))
                {
                    dt.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("Name")});

                    string sql = "Select * From tbl_Page";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var name = myDataReader["Name"].ToString();
                           




                            dt.Rows.Add(id, name);
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