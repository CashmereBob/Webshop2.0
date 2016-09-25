using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class Category
    {
        DBConnection db = new DBConnection();
        public List<CategoryObject> ListAllCategoryList()
        {
            var list = new List<CategoryObject>();

            try
            {
                db.OpenConnection();

                string sql = "Select * From tbl_Category";
                SqlCommand myCommand = new SqlCommand(sql, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        var category = new CategoryObject();

                        category.categoryID = int.Parse(myDataReader["ID"].ToString());
                        category.name = myDataReader["Name"].ToString();


                        list.Add(category);
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