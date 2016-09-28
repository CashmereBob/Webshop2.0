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

        internal void DeleteMainProduct(string ID)
        {
            string query = $@"use [WebShopGr7]
                              DELETE FROM tbl_Product
                              WHERE tbl_Product.ID = {ID}";
            connection.OpenConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection._connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch { }
            finally { connection.CloseConnection(); }
            query = $@" use [WebShopGr7]
                        DELETE FROM tbl_Product_Attribute
                        WHERE tbl_Product_Attribute.ProductID = {ID}";
            connection.OpenConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection._connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch { }
            finally { connection.CloseConnection(); }
           
        }

        internal void DeleteSubProduct(string ID)
        {
           string query = $@" use [WebShopGr7]
                        DELETE FROM tbl_Product_Attribute
                        WHERE tbl_Product_Attribute.ID = {ID}";
            connection.OpenConnection();
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection._connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch { }
            finally { connection.CloseConnection(); }

        }
        internal List<ProductObject> GetOldestProducts(int HowManny)
        {
            List<ProductObject> result = new List<ProductObject>();
            string query = $@"select TOP {HowManny} 
                              tbl_Product_Attribute.ID, 
                              tbl_Product_Attribute.ProductID,
                              tbl_Product_Attribute.Quantity,
                              tbl_Product_Attribute.PriceB2B,
                              tbl_Product_Attribute.PriceB2C,
                              tbl_Product_Attribute.ArticleNumber,
                              tbl_Product_Attribute.DateMade ,
                              tbl_Product_Attribute.AttributeID1,
                              tbl_Product_Attribute.AttributeID2,
                              tbl_Product_Attribute.AttributeID3,
                              tbl_Product_Attribute.AttributeID4,
                              tbl_Product.Name,
                              tbl_Brand.Name as Brand,
                              tbl_Category.Name as Category,
                              tbl_Product.Description,
                              tbl_Product.ImgUrl
                              From tbl_Product_Attribute
                              INNER JOIN tbl_Product ON tbl_Product.ID = tbl_Product_Attribute.ProductID
                              INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                              INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
                              ORDER BY DateMade;
                              ";
            connection.OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductObject proObj = new ProductObject();
                        proObj.ID = int.Parse(dataReader["ID"].ToString());
                        proObj.productID = int.Parse(dataReader["ProductID"].ToString());
                        proObj.quantity = int.Parse(dataReader["Quantity"].ToString());
                        proObj.priceB2B = decimal.Parse(dataReader["PriceB2B"].ToString());
                        proObj.priceB2C = decimal.Parse(dataReader["PriceB2C"].ToString());
                        proObj.artNr = dataReader["ArticleNumber"].ToString();
                        proObj.DateMade = dataReader["DateMade"].ToString();

                        proObj.name = dataReader["Name"].ToString();
                        proObj.brandName = dataReader["Brand"].ToString();
                        proObj.category = dataReader["Category"].ToString();
                        proObj.description = dataReader["Description"].ToString();
                        proObj.imgURL = dataReader["ImgUrl"].ToString();

                        try { proObj.attribute1 = int.Parse(dataReader["AttributeID1"].ToString()); } catch { }
                        try { proObj.attribute2 = int.Parse(dataReader["AttributeID2"].ToString()); } catch { }
                        try { proObj.attribute3 = int.Parse(dataReader["AttributeID3"].ToString()); } catch { }
                        try { proObj.attribute4 = int.Parse(dataReader["AttributeID4"].ToString()); } catch { }


                        result.Add(proObj);
                    }
                }

            }



            connection.CloseConnection();
            return result;
        }
        internal List<ProductObject> GetNewestProducts(int HowManny)
        {
            List<ProductObject> result = new List<ProductObject>();
            string query = $@"select TOP {HowManny} 
                              tbl_Product_Attribute.ID, 
                              tbl_Product_Attribute.ProductID,
                              tbl_Product_Attribute.Quantity,
                              tbl_Product_Attribute.PriceB2B,
                              tbl_Product_Attribute.PriceB2C,
                              tbl_Product_Attribute.ArticleNumber,
                              tbl_Product_Attribute.DateMade ,
                              tbl_Product_Attribute.AttributeID1,
                              tbl_Product_Attribute.AttributeID2,
                              tbl_Product_Attribute.AttributeID3,
                              tbl_Product_Attribute.AttributeID4,
                              tbl_Product.Name,
                              tbl_Brand.Name as Brand,
                              tbl_Category.Name as Category,
                              tbl_Product.Description,
                              tbl_Product.ImgUrl
                              From tbl_Product_Attribute
                              INNER JOIN tbl_Product ON tbl_Product.ID = tbl_Product_Attribute.ProductID
                              INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                              INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID
                              ORDER BY DateMade DESC;
                              ";
            connection.OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductObject proObj = new ProductObject();
                        proObj.ID = int.Parse(dataReader["ID"].ToString());
                        proObj.productID = int.Parse(dataReader["ProductID"].ToString());
                        proObj.quantity = int.Parse(dataReader["Quantity"].ToString());
                        proObj.priceB2B = decimal.Parse(dataReader["PriceB2B"].ToString());
                        proObj.priceB2C = decimal.Parse(dataReader["PriceB2C"].ToString());
                        proObj.artNr = dataReader["ArticleNumber"].ToString();
                        proObj.DateMade = dataReader["DateMade"].ToString();

                        proObj.name = dataReader["Name"].ToString();
                        proObj.brandName = dataReader["Brand"].ToString();
                        proObj.category = dataReader["Category"].ToString();
                        proObj.description = dataReader["Description"].ToString();
                        proObj.imgURL = dataReader["ImgUrl"].ToString();

                        try { proObj.attribute1 = int.Parse(dataReader["AttributeID1"].ToString()); } catch { }
                        try { proObj.attribute2 = int.Parse(dataReader["AttributeID2"].ToString()); } catch { }
                        try { proObj.attribute3 = int.Parse(dataReader["AttributeID3"].ToString()); } catch { }
                        try { proObj.attribute4 = int.Parse(dataReader["AttributeID4"].ToString()); } catch { }


                        result.Add(proObj);
                    }
                }

            }



            connection.CloseConnection();
            return result;
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
        internal void removeAttribute(string text, ProductObject proObc)
        {
            int attributeID = -1;
            var attri = text.Split(' ');
            //Get the Attribute ID
            string query = $@"Select tbl_Attribute.ID from tbl_Attribute
                              Where tbl_Attribute.Name = '{attri[0]}' AND tbl_Attribute.Value = '{attri[1]}'";
            connection.OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        attributeID = (int.Parse(dataReader["ID"].ToString()));
                    }
                }
                dataReader.Close();
            }
            //Check all attribute spots and delete the spotted Attribute
            int nr = 1;
            while (nr < 5)
            {
                string AttributeID = "AttributeID" + nr;
                query = $@"SELECT {AttributeID} as focus From tbl_Product_Attribute
                           WHERE tbl_Product_Attribute.ID = {proObc.productID} AND {AttributeID} = {attributeID}";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection._connection))
                    {
                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                // IF not null= We found our guy!
                                if (dataReader["focus"] != null)
                                {
                                    dataReader.Close();
                                    query = $@"UPDATE tbl_Product_Attribute 
                                           SET
                                          {AttributeID} = null
                 
                                           WHERE tbl_Product_Attribute.ID = {proObc.productID}         
                    ";

                                    using (SqlCommand command2 = new SqlCommand(query, connection._connection))
                                    {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                    }
                }
                catch
                {

                }
                finally
                {
                    dataReader.Close();
                    nr++;
                }

            }

            connection.CloseConnection();
        }

        public ProductObject GetMainProduct(int ID)
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
                                      WHERE tbl_Product.ID={ID}
                                      ";
            try
            {
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
                            Result.priceB2B.ToString("#.##");
                            Result.priceB2C.ToString("#.##");
                        }
                    }
                }


            }
            catch { }
            finally
            {

                connection.CloseConnection();
            }
            return Result;
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
            try
            {
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
                            Result.priceB2B.ToString("#.##");
                            Result.priceB2C.ToString("#.##");
                        }
                    }
                }


            }
            catch { }
            finally
            {

                connection.CloseConnection();
            }
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
        internal List<string> GetDroppdownNames(string tbl)
        {
            List<string> result = new List<string>();
            //result.Add("Select");
            string query = $@"use[WebShopGr7]
                            select {tbl}.Name From {tbl}
                            group by Name";
            connection.OpenConnection();

            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {

                    while (dataReader.Read())
                    {
                        result.Add(dataReader["Name"].ToString());
                    }
                }
            }
            connection.CloseConnection();

            return result;
        }

        //################  Saves  ###############################
        // Saves the Base Product changes
        internal void SaveProduct_AttributeChanges(ProductObject proObc)
        {
            string query;
            connection.OpenConnection();
            int brandID = CheckBrand(proObc.brandName);
            int categoryID = CheckCategory(proObc.category);

            query = $@"";

            query = $@"UPDATE tbl_Product SET
                           Name ='{proObc.name}',
                           Description ='{proObc.description}',
                           BrandID =({brandID}),
                           CategoryID =({categoryID}),
                           ImgUrl ='{proObc.imgURL}'
                           WHERE tbl_Product.ID = {proObc.productID}           
                           ";

            SqlCommand command = new SqlCommand(query, connection._connection);
            command.ExecuteNonQuery();
            connection.CloseConnection();
        }
        internal int CheckBrand(string Brand)
        {
            int result = 0;

            string query = $@"Select tbl_Brand.ID from tbl_Brand
                       where tbl_Brand.Name = '{Brand}'";
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //Check if brand exists
                        if (dataReader["ID"] != null)
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }


                    }
                }
            }
            if (result == 0)
            {
                //Create the Brand
                query = $@"INSERT INTO tbl_Brand
                                    (Name) VALUES ('{Brand}')";
                using (SqlCommand command3 = new SqlCommand(query, connection._connection))
                {
                    command3.ExecuteNonQuery();
                }
                //Get the new brand+s ID
                query = $@"SELECT tbl_Brand.ID from tbl_Brand WHERE tbl_Brand.Name = '{Brand}'";
                using (SqlCommand command4 = new SqlCommand(query, connection._connection))
                {
                    using (dataReader = command4.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }
                    }
                }
            }

            return result;
        }
        internal int CheckCategory(string Category)
        {
            int result = 0;
            string query = $@"Select tbl_Category.ID from tbl_Category
                       where tbl_Category.Name = '{Category}'";
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //Check if brand exists
                        if (dataReader["ID"] != null)
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }
                    }
                }
            }
            if (result == 0)
            {
                //Create the Brand
                query = $@"INSERT INTO tbl_Category
                                    (Name) VALUES ('{Category}')";
                using (SqlCommand command3 = new SqlCommand(query, connection._connection))
                {
                    command3.ExecuteNonQuery();
                }
                //Get the new brand+s ID
                query = $@"SELECT tbl_Category.ID from tbl_Category WHERE tbl_Category.Name = '{Category}'";
                using (SqlCommand command4 = new SqlCommand(query, connection._connection))
                {
                    using (dataReader = command4.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }
                    }
                }
            }
            return result;
        }
        //Save New Attribute
        internal void addAttribute(ProductObject proObc, List<string> Attributes)
        {

            string query = "";
            int AttributeID = -1;
            int spotToFill = 0;
            foreach (var item in Attributes)
            {
                connection.OpenConnection();
                spotToFill++;
                var attri = item.Split(' ');
                bool exists = false;
                //Check if the attribute allready exists or not
                query = $@"use[WebShopGr7]
                           Select dbo.tbl_Attribute.ID From dbo.tbl_Attribute
                           WHERE dbo.tbl_Attribute.Name = '{attri[0]}' AND dbo.tbl_Attribute.Value= '{attri[1]}'";

                using (SqlCommand commandCheckAttri = new SqlCommand(query, connection._connection))
                {
                    using (dataReader = commandCheckAttri.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["ID"] != null)
                            {
                                AttributeID = int.Parse(dataReader["ID"].ToString());
                                exists = true;
                            }
                        }
                    }
                }
                if (exists)//Add Attribute to the Objekt
                {
                    string attriSpot = "";
                    if (spotToFill == 1) { attriSpot = "AttributeID1"; }
                    if (spotToFill == 2) { attriSpot = "AttributeID2"; }
                    if (spotToFill == 3) { attriSpot = "AttributeID3"; }
                    if (spotToFill == 4) { attriSpot = "AttributeID4"; }
                    query = $@"use[WebShopGr7]
                               UPDATE tbl_Product_Attribute SET 
                               {attriSpot} = {AttributeID}
                               WHERE tbl_Product_Attribute.ID ={proObc.productID} ";
                    using (SqlCommand command = new SqlCommand(query, connection._connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else //Create the Attribute and Add it to the objekt
                {
                    query = $@"use[WebShopGr7]
                               Insert into  tbl_Attribute(Name,Value) 
                               Values('" + attri[0] + "','" + attri[1] + "')";
                    using (SqlCommand command = new SqlCommand(query, connection._connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Get the ID from wat hwe created
                    query = $@"use[WebShopGr7]
                           Select dbo.tbl_Attribute.ID From dbo.tbl_Attribute
                           WHERE dbo.tbl_Attribute.Name = '{attri[0]}' AND dbo.tbl_Attribute.Value= '{attri[1]}'";

                    using (SqlCommand commandCheckAttri = new SqlCommand(query, connection._connection))
                    {
                        using (dataReader = commandCheckAttri.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                if (dataReader["ID"] != null)
                                {
                                    AttributeID = int.Parse(dataReader["ID"].ToString());

                                }
                            }
                        }
                    }
                    //Add it to the right spot on Tbl_Product_Attributes
                    string attriSpot = "";
                    if (spotToFill == 1) { attriSpot = "AttributeID1"; }
                    if (spotToFill == 2) { attriSpot = "AttributeID2"; }
                    if (spotToFill == 3) { attriSpot = "AttributeID3"; }
                    if (spotToFill == 4) { attriSpot = "AttributeID4"; }
                    query = $@"use[WebShopGr7]
                               UPDATE tbl_Product_Attribute SET 
                               {attriSpot} = {AttributeID}
                               WHERE tbl_Product_Attribute.ID ={proObc.productID} ";
                    using (SqlCommand command = new SqlCommand(query, connection._connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
                connection.CloseConnection();

            }
        }
        // Save the Product Attribute changes
        internal void saveProductChanges(ProductObject proObc)
        {
            connection.OpenConnection();
            string query = "";
            query = $@"UPDATE tbl_Product_Attribute SET 
                Quantity ='{proObc.quantity}',    
                PriceB2B = '{proObc.priceB2B}',
                PriceB2C = '{proObc.priceB2C}',           
                ArticleNumber = '{proObc.artNr}'       
                WHERE tbl_Product_Attribute.ID = {proObc.productID}
                ";
            SqlCommand command = new SqlCommand(query, connection._connection);
            command.ExecuteNonQuery();
            connection.CloseConnection();

        }
        //Add a new Product to DB
        public void AddProduct(ProductObject proObj, List<string> attributes)
        {
            connection.OpenConnection();
            //Brand
            int brandID = CheckBrand(proObj.brandName);
            //Category
            int categoryID = CheckCategory(proObj.category);
            //Product
            int productID = CheckProduct(proObj, brandID, categoryID);
            //Product_Attributes
            proObj.productID = CreateNew_TBL_ProductAttribute(productID, proObj);
            //Attributes
            connection.CloseConnection();
            addAttribute(proObj, attributes);
        }

        private int CreateNew_TBL_ProductAttribute(int productID, ProductObject proObj)
        {
            int result = 0;
            //Create the tbl_Product_Attribute
            string query = $@"INSERT INTO tbl_Product_Attribute
                            (ProductID,PriceB2B,PriceB2C,Quantity,ArticleNumber) VALUES 
                            ('{productID}','{proObj.priceB2B}','{proObj.priceB2C}','{proObj.quantity}','{proObj.artNr}')";
            SqlCommand command = new SqlCommand(query, connection._connection);
            command.ExecuteNonQuery();
            //Get the ID
            query = $@"SELECT tbl_Product_Attribute.ID FROM tbl_Product_Attribute
                       WHERE 
                       tbl_Product_Attribute.ProductID = {productID} AND
                       tbl_Product_Attribute.Quantity = {proObj.quantity} AND
                       tbl_Product_Attribute.PriceB2B = {proObj.priceB2B} AND
                       tbl_Product_Attribute.PriceB2C = {proObj.priceB2C} AND
                       tbl_Product_Attribute.ArticleNumber = '{proObj.artNr}'
                       ";
            using (SqlCommand command1 = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command1.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //Check if brand exists
                        if (dataReader["ID"] != null)
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }
                    }
                }
            }
            return result;
        }

        private int CheckProduct(ProductObject proObj, int brandID, int categoryID)
        {
            int result = 0;

            string query = $@"Select tbl_Product.ID from tbl_Product
                       where tbl_Product.Name = '{proObj.name}'AND 
                             tbl_Product.Description = '{proObj.description}' AND
                             tbl_Product.BrandID = '{brandID}' AND 
                             tbl_Product.ImgUrl = '{proObj.imgURL}' AND
                             tbl_Product.CategoryID = '{categoryID}'
";
            using (SqlCommand command = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //Check if brand exists
                        if (dataReader["ID"] != null)
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }


                    }
                }
            }
            if (result == 0)// Product dont exists so we need to make It!
            {
                query = $@" INSERT INTO tbl_Product
                            (Name,Description,BrandID,CategoryID,ImgUrl) VALUES 
                            ('{proObj.name}','{proObj.description}','{brandID}','{categoryID}','{proObj.imgURL}')";
                using (SqlCommand command = new SqlCommand(query, connection._connection))
                {
                    command.ExecuteNonQuery();
                }
                //Get the new Product's ID
                query = $@"Select tbl_Product.ID from tbl_Product
                       where tbl_Product.Name = '{proObj.name}'AND 
                             tbl_Product.Description = '{proObj.description}' AND
                             tbl_Product.BrandID = '{brandID}' AND
                             tbl_Product.CategoryID = '{categoryID}' AND
                             tbl_Product.ImgUrl = '{proObj.imgURL}' ";
                using (SqlCommand command = new SqlCommand(query, connection._connection))
                {
                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result = int.Parse(dataReader["ID"].ToString());
                        }
                    }
                }
            }

            return result;
        }

        internal List<ProductObject> GetProductByWhereList(string where)
        {
            List<ProductObject> list = new List<ProductObject>();


            try
            {
                connection.OpenConnection();

                string sql = @"Select tbl_Product.ID AS[ID], tbl_Product.Name AS[Name], tbl_Brand.Name AS[Brand], tbl_Product.ImgUrl AS [img], tbl_Category.Name AS[Category], tbl_Product_Attribute.[PriceB2B] " +
                             @"AS[B2B], tbl_Product_Attribute.[PriceB2C] AS[B2C], tbl_Product_Attribute.AttributeID1, tbl_Product_Attribute.AttributeID2, tbl_Product_Attribute.AttributeID3, tbl_Product_Attribute.AttributeID4 " +
                             @"From tbl_Product " +
                             @"INNER JOIN tbl_Brand " +
                             @"on tbl_Product.BrandID = tbl_Brand.ID " +
                             @"INNER JOIN tbl_Category " +
                             @"on tbl_Product.CategoryID = tbl_Category.ID " +
                             @"INNER JOIN tbl_Product_Attribute " +
                             @"on tbl_Product_Attribute.ProductID = tbl_Product.ID " +
                             $"{where}";

                SqlCommand myCommand = new SqlCommand(sql, connection._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        var product = new ProductObject();

                        product.productID = int.Parse(myDataReader["ID"].ToString());
                        product.name = myDataReader["Name"].ToString();
                        product.brandName = myDataReader["Brand"].ToString();
                        product.category = myDataReader["Category"].ToString();
                        product.imgURL = myDataReader["img"].ToString();
                        product.priceB2C = decimal.Parse(myDataReader["B2C"].ToString());
                        product.priceB2B = decimal.Parse(myDataReader["B2B"].ToString());

                        int atr = -1;

                        int.TryParse(myDataReader["AttributeID1"].ToString(), out atr);
                        product.attribute1 = atr;
                        int.TryParse(myDataReader["AttributeID2"].ToString(), out atr);
                        product.attribute2 = atr;
                        int.TryParse(myDataReader["AttributeID3"].ToString(), out atr);
                        product.attribute3 = atr;
                        int.TryParse(myDataReader["AttributeID4"].ToString(), out atr);
                        product.attribute4 = atr;

                        list.Add(product);
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
                connection.CloseConnection();
            }



        }
        internal int GetAttributeID(string key, string value)
        {

            int id = -1;

            try
            {
                connection.OpenConnection();

                string sql = @"Select ID " +
                                @"FROM tbl_Attribute " +
                                $"WHERE tbl_Attribute.Name = '{key}' AND tbl_Attribute.Value = '{value}'";
                SqlCommand myCommand = new SqlCommand(sql, connection._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        id = int.Parse(myDataReader["ID"].ToString());
                    }
                }



            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.CloseConnection();
            }



            return id;


        }
    }
}