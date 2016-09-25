using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class Brand
    {
        DBConnection db = new DBConnection();

        public List<BrandObject> ListAllBrandsList()
        {
            var list = new List<BrandObject>();

            try
            {
                db.OpenConnection();

                string sql = "Select * From tbl_Brand";
                SqlCommand myCommand = new SqlCommand(sql, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        var brand = new BrandObject();

                        brand.brandID = int.Parse(myDataReader["ID"].ToString());
                        brand.name = myDataReader["Name"].ToString();
                        

                        list.Add(brand);
                    }
                }

                return list;


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