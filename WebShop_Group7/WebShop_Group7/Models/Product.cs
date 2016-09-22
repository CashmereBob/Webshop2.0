using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class Product
    {
        DBConnection connection = new DBConnection();
        SqlDataReader dataReader;

        public DataTable GetAllToDataTable()
        {
            DataTable dataTable = new DataTable("Product");
            try
            {
                connection.OpenConnection();
                using (dataTable)
                {
                    dataTable.Columns.AddRange(new DataColumn[5]
                    {   new DataColumn("ID"),
                        new DataColumn("Name"),
                        new DataColumn("Description"),
                        new DataColumn("BrandID"),
                        new DataColumn("CategoryID"),
                      
                    });

                    //                    string query = "SELECT * FROM tbl_Product";
                    string test = $@"select tbl_Product.ID,tbl_Product.Name,tbl_Category.Name AS category,tbl_Brand.Name as theBrand,tbl_Product.Description  from tbl_Product
                    INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                    INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID";

                    string test2 = $@"select 
tbl_Product.ID,
tbl_Product.Name,
tbl_Category.Name AS Category,
tbl_Brand.Name as Brand,
tbl_Product.Description,
tbl_Product_Attribute.PriceB2C as B2C  
from tbl_Product

INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
INNER JOIN tbl_Product_Attribute On tbl_Product_Attribute.ProductID = tbl_Product.ID";

                    using (SqlCommand command = new SqlCommand(test, connection._connection))
                    {
                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var id = int.Parse(dataReader["ID"].ToString());
                                var categoryid = dataReader["category"].ToString();
                                var name = dataReader["Name"].ToString();
                                var description = dataReader["Description"].ToString();
                                var brandid = dataReader["theBrand"].ToString();
                              

                                dataTable.Rows.Add(id, name, description, brandid, categoryid);
                            }

                            return dataTable;
                        }
                    }


                }
            }
            catch
            {
                return dataTable;
            }
            finally
            {
                connection.CloseConnection();
                dataReader.Close();
            }

        }
    }
}