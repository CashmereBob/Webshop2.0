﻿using System;
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
            int brandID;
            connection.OpenConnection();
            //Check brand
            query = $@"Select tbl_Brand.ID from tbl_Brand
                       where tbl_Brand.Name = '{proObc.brandName}'";
            using (SqlCommand command1 = new SqlCommand(query, connection._connection))
            {
                using (dataReader = command1.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //Check if brand exists
                        if (dataReader["ID"] != null)
                        {
                            brandID = int.Parse(dataReader["ID"].ToString());
                        }
                        else
                        {
                            //Create the Brand
                            query = $@"INSERT INTO tbl_Brand
                                    (Name) VALUES ('{proObc.brandName}')";
                            using (SqlCommand command3 = new SqlCommand(query, connection._connection))
                            {
                                command3.ExecuteNonQuery();
                            }
                            //Get the new brand+s ID
                            query = $@"SELECT tbl_Brand.ID from tbl_Brand WHERE Brand.Name = '{proObc.brandName}'";
                            using (SqlCommand command4 = new SqlCommand(query, connection._connection))
                            {
                                using (dataReader = command4.ExecuteReader())
                                {
                                    while (dataReader.Read())
                                    {
                                        //HERE I AM!!!
                                    }
                                }
                            }
                        }
                    }
                }
                //Check Category
                query = $@"";

                query = $@"UPDATE tbl_Product SET
                           Name ='{proObc.name}',
                           Description ='{proObc.description}',
                           BrandID =(select tbl_Brand.ID from tbl_Brand where tbl_Brand.Name = '{proObc.brandName}'),
                           CategoryID =(select tbl_Category.ID from tbl_Category where tbl_Category.Name = '{proObc.category}'),
                           ImgUrl ='{proObc.imgURL}'
                           WHERE tbl_Product.ID = {proObc.productID}           
                           ";

                SqlCommand command = new SqlCommand(query, connection._connection);
                command.ExecuteNonQuery();
                connection.CloseConnection();
            }
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

                //{
                //    //Check Wath spot to put the Attribute on
                //    query = $@"use[WebShopGr7]
                //               Select tbl_Product_Attribute.AttributeID1,
                //               tbl_Product_Attribute.AttributeID2,
                //               tbl_Product_Attribute.AttributeID3,
                //               tbl_Product_Attribute.AttributeID4 FROM tbl_Product_Attribute
                //               WHERE tbl_Product_Attribute.ID = 1";
                //    using (SqlCommand commandCheckSpot = new SqlCommand(query, connection._connection))
                //    {
                //        using (dataReader = commandCheckSpot.ExecuteReader())
                //        {
                //            while (dataReader.Read())
                //            {
                //                if (dataReader["AttributeID1"] == null) { spotToFill = "AttributeID1"; }
                //                else if (dataReader["AttributeID2"] == null) { spotToFill = "AttributeID2"; }
                //                else if (dataReader["AttributeID3"] == null) { spotToFill = "AttributeID3"; }
                //                else if (dataReader["AttributeID4"] == null) { spotToFill = "AttributeID4"; }
                //            }
                //        }
                //    }
                //}
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
        public void AddProduct(ProductObject proObj,List<string> attributes)
        {
          
            connection.OpenConnection();
            //Brand

            //Category
            
            //Attributes

            //Product

            //Product_Attributes
            
        }
    }
}