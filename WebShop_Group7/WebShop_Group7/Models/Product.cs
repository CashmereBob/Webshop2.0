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
                    dataTable.Columns.AddRange(new DataColumn[12]
                    {  new DataColumn("ID"),
                       new DataColumn("ArticleNr"),
                       new DataColumn("Name"),
                       new DataColumn("CategoryID"),
                       new DataColumn("AttributeType"),
                       new DataColumn("AttributeValue"),
                       new DataColumn("BrandID"),
                       new DataColumn("Description"),
                       new DataColumn("b2bPrice"),
                       new DataColumn("b2cPrice"),
                       new DataColumn("quant"),
                       new DataColumn("img")
                    });

                    //                    string query = "SELECT * FROM tbl_Product";
                    string test = $@"select tbl_Product.ID,tbl_Product.Name,tbl_Category.Name AS category,tbl_Brand.Name as theBrand,tbl_Product.Description  from tbl_Product
                    INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                    INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID";

                    string test2 = $@"select 
tbl_Product.ID,
tbl_Product_Attribute.ArticleNumber,
tbl_Product.Name,
tbl_Category.Name AS category,
tbl_Attribute.Name AS theType,
tbl_Attribute.Value AS value,
tbl_Brand.Name as theBrand,
tbl_Product.Description,
tbl_Product_Attribute.PriceB2B as b2b,
tbl_Product_Attribute.PriceB2C as b2c,

tbl_Product_Attribute.Quantity,
tbl_Product.ImgUrl



from tbl_Product

INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
INNER JOIN tbl_Product_Attribute ON tbl_Product_Attribute.ProductID = tbl_Product.ID
INNER JOIN tbl_Attribute ON tbl_Attribute.ID = tbl_Product_Attribute.AttributeID1";

                    using (SqlCommand command = new SqlCommand(test2, connection._connection))
                    {
                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var id = int.Parse(dataReader["ID"].ToString());
                                var articlenr = int.Parse(dataReader["ArticleNumber"].ToString());
                                var name = dataReader["Name"].ToString();
                                var categoryid = dataReader["category"].ToString();
                                var attriType = dataReader["theType"].ToString();
                                var attriValue = dataReader["value"].ToString();
                                var brandid = dataReader["theBrand"].ToString();
                                var description = dataReader["Description"].ToString();                   
                                var buissniesPrice = double.Parse(dataReader["b2b"].ToString());
                                var customPrice = double.Parse(dataReader["b2c"].ToString());
                                var quant = int.Parse(dataReader["Quantity"].ToString());
                                var imgurl = dataReader["ImgUrl"].ToString();

                                dataTable.Rows.Add(id, articlenr, name, categoryid, attriType, attriValue, brandid,
                                description , buissniesPrice, customPrice, quant, imgurl);
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