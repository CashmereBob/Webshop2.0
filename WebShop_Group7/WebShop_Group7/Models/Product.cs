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

        public DataTable GetListProductAttributes(int pID)
        {
            DataTable dataTable = new DataTable("Product");
            try
            {
                connection.OpenConnection();
                using (dataTable)
                {
                    dataTable.Columns.AddRange(new DataColumn[10]
                    {
                       new DataColumn("ID"),
                       new DataColumn("ArticleNr"),
                       new DataColumn("Name"),
                       new DataColumn("CategoryID"),
                       new DataColumn("BrandID"),
                       new DataColumn("Description"),
                       new DataColumn("b2bPrice"),
                       new DataColumn("b2cPrice"),
                       new DataColumn("quant"),
                       new DataColumn("Attribute")

                    });

                    string test2 = $@"Select 
                                         tbl_Product_Attribute.ID,
                                      tbl_Product_Attribute.ArticleNumber,
                                      tbl_Product.Name,
                                      tbl_Category.Name AS category,
                                      tbl_Brand.Name AS theBrand, 
                                      tbl_Product.Description,
                                      tbl_Product_Attribute.PriceB2B as b2b,
                                      tbl_Product_Attribute.PriceB2C AS b2c,
                                      tbl_Product_Attribute.Quantity,
                                      dbo.CheckAttributeAmount(tbl_Product.ID) as nrAttribute,
	                                 dbo.CheckAttributeAmount(tbl_Product.ID) as nrAttribute,
									 dbo.GetAttributes(tbl_Product_Attribute.AttributeID1)  as a1,
									 dbo.GetAttributes( tbl_Product_Attribute.AttributeID2) as a2,
									 dbo.GetAttributes( tbl_Product_Attribute.AttributeID3) as a3,
									 dbo.GetAttributes(tbl_Product_Attribute.AttributeID4)  as a4
                                      
                                      From tbl_Product
                                      
                                      INNER JOIN tbl_Product_Attribute ON tbl_Product_Attribute.ProductID = tbl_Product.ID
                                      INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                                      INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
                                       WHERE tbl_Product_Attribute.ProductID = {pID}
                                      ";

                    using (SqlCommand command = new SqlCommand(test2, connection._connection))
                    {
                        using (dataReader = command.ExecuteReader())
                        {

                            while (dataReader.Read())
                            {

                                var id = int.Parse(dataReader["ID"].ToString());
                                var quant = int.Parse(dataReader["Quantity"].ToString());
                                string articlenr;
                                try { articlenr = dataReader["ArticleNumber"].ToString(); } catch { articlenr = ""; }
                                var name = dataReader["Name"].ToString();
                                var categoryid = dataReader["category"].ToString();
                                var brandid = dataReader["theBrand"].ToString();
                                var description = dataReader["Description"].ToString();
                                var buissniesPrice = (dataReader["b2b"].ToString() + " kr");
                                var customPrice = (dataReader["b2c"].ToString() + " kr");
                                string attributes = "";
                                try { attributes += (dataReader["a1"].ToString() + Environment.NewLine); } catch { }
                                try { attributes += (dataReader["a2"].ToString() + Environment.NewLine); } catch { }
                                try { attributes += (dataReader["a3"].ToString() + Environment.NewLine); } catch { }
                                try { attributes += (dataReader["a4"].ToString() + Environment.NewLine); } catch { }





                                dataTable.Rows.Add(id, articlenr, name, categoryid, brandid,
                                    description, buissniesPrice, customPrice, quant, attributes);

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
        public DataTable GetListProducts()
        {
            DataTable dataTable = new DataTable("Product");
            try
            {
                connection.OpenConnection();
                using (dataTable)
                {
                    dataTable.Columns.AddRange(new DataColumn[8]
                    {
                       new DataColumn("ID"),

                       new DataColumn("Name"),
                       new DataColumn("CategoryID"),
                       new DataColumn("BrandID"),
                       new DataColumn("Description"),
                       new DataColumn("b2bPrice"),
                       new DataColumn("b2cPrice"),
                       new DataColumn("Attribute")

                    });

                    string test2 = $@"Select 
                                      tbl_Product.ID,
                               
                                      tbl_Product.Name,
                                      tbl_Category.Name AS category,
                                      tbl_Brand.Name AS theBrand, 
                                      tbl_Product.Description,
                                      tbl_Product_Attribute.PriceB2B as b2b,
                                      tbl_Product_Attribute.PriceB2C AS b2c,
                                      dbo.CheckAttributeAmount(tbl_Product.ID) as nrAttribute
                                      
                                      From tbl_Product
                                      
                                      INNER JOIN tbl_Product_Attribute ON tbl_Product_Attribute.ProductID = tbl_Product.ID
                                      INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                                      INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID";

                    using (SqlCommand command = new SqlCommand(test2, connection._connection))
                    {
                        using (dataReader = command.ExecuteReader())
                        {
                            int oldId = -1;
                            while (dataReader.Read())
                            {
                                if (oldId != int.Parse(dataReader["ID"].ToString()))
                                {


                                    var id = int.Parse(dataReader["ID"].ToString());


                                    var name = dataReader["Name"].ToString();
                                    var categoryid = dataReader["category"].ToString();
                                    var brandid = dataReader["theBrand"].ToString();
                                    var description = dataReader["Description"].ToString();
                                    var buissniesPrice = (dataReader["b2b"].ToString() + " kr");
                                    var customPrice = (dataReader["b2c"].ToString() + " kr");
                                    string attributes = (dataReader["nrAttribute"].ToString());

                                    oldId = id;
                                    dataTable.Rows.Add(id, name, categoryid, brandid,
                                    description, buissniesPrice, customPrice, attributes);
                                }
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
        public ProductObject GetProduct(int ID)
        {
            ProductObject Result = new ProductObject();



            string query = $@" Select 
                                       tbl_Product_Attribute.ID,
                                      tbl_Product_Attribute.ArticleNumber,
                                      tbl_Product.Name as productName,
                                      tbl_Category.Name AS category,
                                      tbl_Brand.Name AS theBrand, 
                                      tbl_Product.Description,
                                      tbl_Product_Attribute.PriceB2B as b2b,
                                      tbl_Product_Attribute.PriceB2C AS b2c,
									  tbl_Product.ImgUrl,
									  tbl_Product_Attribute.Quantity
                                      
                                      From tbl_Product
                                      
                                      INNER JOIN tbl_Product_Attribute ON tbl_Product_Attribute.ProductID = tbl_Product.ID
                                      INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                                      INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
                                      WHERE tbl_Product_Attribute.ID={ID}
                                      ";

            connection.OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Result.productID = int.Parse(dataReader["ID"].ToString());
                        Result.name = dataReader["productName"].ToString();
                        Result.description = dataReader["Description"].ToString();
                        Result.priceB2B = decimal.Parse(dataReader["b2b"].ToString());
                        Result.priceB2C = decimal.Parse(dataReader["b2c"].ToString());
                        Result.brandName = dataReader["theBrand"].ToString();
                        Result.category = dataReader["category"].ToString();
                        try { Result.imgURL = dataReader["ImgUrl"].ToString(); } catch { Result.imgURL = ""; }
                        Result.quantity = int.Parse(dataReader["Quantity"].ToString());
                        Result.artNr = dataReader["ArticleNumber"].ToString();
                    }
                }
            }
            connection.CloseConnection();
            return Result;
        }
        public string GetAValue(string table, string value, int id)
        {
            string result = "";
            string query = $@"SELECT 
                              {table}.{value} as here
                           
                              FROM tbl_Product
                              INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                              INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
                              WHERE tbl_Product.ID = '{id}'";
            connection.OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {

                    while (dataReader.Read())
                    {
                        result = dataReader["here"].ToString();
                    }
                }
            }
            connection.CloseConnection();
            return result;
        }
        public Dictionary<string, string> GetAttribute(ProductObject product)
        {
            var dict = new Dictionary<string, string>();
            var list = new List<int>();

            if (product.attribute1 > 0)
            {
                list.Add(product.attribute1);
            }

            if (product.attribute2 > 0)
            {
                list.Add(product.attribute2);
            }

            if (product.attribute3 > 0)
            {
                list.Add(product.attribute3);
            }

            if (product.attribute4 > 0)
            {
                list.Add(product.attribute4);
            }



            try
            {
                connection.OpenConnection();

                foreach (int art in list)
                {
                    string sql = @"SELECT Name, Value " +
                                    @"FROM tbl_Attribute " +
                                    $"WHERE ID = '{art}'";


                    SqlCommand myCommand = new SqlCommand(sql, connection._connection);


                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            dict.Add(myDataReader["Name"].ToString(), myDataReader["Value"].ToString());
                        }
                    }


                }
                return dict;
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.CloseConnection();
            }




        }
        public string GetAttributes(int id)
        {
            string result = "";
            string query = $@"select
	                                 dbo.GetAttributes(tbl_Product_Attribute.AttributeID1)  as a1,
									 dbo.GetAttributes( tbl_Product_Attribute.AttributeID2) as a2,
									 dbo.GetAttributes( tbl_Product_Attribute.AttributeID3) as a3,
									 dbo.GetAttributes(tbl_Product_Attribute.AttributeID4)  as a4
									 from tbl_Product_Attribute
									 WHERE tbl_Product_Attribute.ID = '{id}'";


            connection.OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string attributes = "";
                        try { attributes += (dataReader["a1"].ToString() + '\t'); } catch { }
                        try { attributes += (dataReader["a2"].ToString() + '\t'); } catch { }
                        try { attributes += (dataReader["a3"].ToString() + '\t'); } catch { }
                        try { attributes += (dataReader["a4"].ToString() + '\t'); } catch { }
                        result = attributes;
                    }
                }
            }
            connection.CloseConnection();

            return result;
        }
    }
}