using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Users
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllUsers()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("User"))
                {
                    dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ID"), new DataColumn("Firstname"), new DataColumn("Lastname"),
                    new DataColumn("Email"),new DataColumn("Pricegroup")});

                    string sql = "Select * From tbl_User";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        
                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var fname = myDataReader["Firstname"].ToString();
                            var lname = myDataReader["Lastname"].ToString();
                            var mail = myDataReader["Email"].ToString();
                            var pricegroup = int.Parse(myDataReader["Pricegroup"].ToString());




                            dt.Rows.Add(id, fname,lname,mail,pricegroup);
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
