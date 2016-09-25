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
            try { 
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
            catch  {   }
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
            string query = $@"UPDATE tbl_Product SET
                           Name ='{proObc.name}',
                           Description ='{proObc.description}',
                           BrandID =(select tbl_Brand.ID from tbl_Brand where tbl_Brand.Name = '{proObc.brandName}'),
                           CategoryID =(select tbl_Category.ID from tbl_Category where tbl_Category.Name = '{proObc.category}'),
                           ImgUrl ='{proObc.imgURL}'
                           WHERE tbl_Product.ID = {proObc.productID}           
                           ";
            connection.OpenConnection();
            SqlCommand command = new SqlCommand(query, connection._connection);
            command.ExecuteNonQuery();
            connection.CloseConnection();
        }
        //Save New Attribute
        internal void addAttribute(ProductObject proObc, List<string> Attributes)
        {
            //FIX Attributes.. comming is as a string with Name+" "+Value. Check if there is one allready, otherwise clreate one, 
            //then add it to the product!
            //int productID = -1;
            connection.OpenConnection();
            string query = "";
            foreach (var item in Attributes)
            {
                var attri = item.Split(' ');
                bool exists = false;
                query = $@"Select tbl_Attributes.ID From tbl_Attributes
                        WHERE tbl_Attributes.Name = '{attri[0]}' AND tbl_Attributes.Value= '{attri[1]}'
                        ";

                using (SqlCommand commandCheckAttri = new SqlCommand(query, connection._connection))
                {
                    using (dataReader = commandCheckAttri.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["ID"] != null) { exists = true; }
                        }
                    }
                }
                if (exists) { }//Add ID to a list or maby to the Objekt direktly?
                else { }//Create the Attribute and get the ID from it to the list OR to the Objekt?
            }
        }
        // Save the Product Attribute changes
        internal void saveProductChanges(ProductObject proObc)
        {
            connection.OpenConnection();
            string query = "";

            //Fill tbl_Product_Attribute  Price,Attributes Missing
          
            query = $@"UPDATE tbl_Product_Attribute SET 
                Quantity ='{proObc.quantity}',    
                PriceB2B = '{proObc.priceB2B}',
                PriceB2C = '{proObc.priceB2C}',           
                ArticleNumber = '{proObc.artNr}'       
                WHERE tbl_Product_Attribute.ID = {proObc.productID}
                ";
            SqlCommand command = new SqlCommand(query, connection._connection);
            command.ExecuteNonQuery();

            //Get Product ID
            //query = $@"SELECT tbl_Product_Attribute.ProductID as prodID FROM tbl_Product_Attribute WHERE tbl_Product_Attribute.ID = {proObc.productID} ";

            //using (SqlCommand command2 = new SqlCommand(query, connection._connection))
            //{
            //    using (dataReader = command2.ExecuteReader())
            //    {

            //        while (dataReader.Read())
            //        {
            //            productID = int.Parse(dataReader["prodID"].ToString());
            //        }
            //    }
            //}

            ////Fill tbl_Product 
            //query = $@" USE [WebShopGr7]
            //                    UPDATE tbl_Product SET 
            //                    BrandID = (select tbl_Brand.ID from tbl_Brand where tbl_Brand.Name = '{proObc.brandName}'),
            //                    CategoryID = (select tbl_Category.ID from tbl_Category where tbl_Category.Name = '{proObc.category}'),
            //                    Name = '{proObc.name}', 
            //                    Description = '{proObc.description}',          
            //                    ImgUrl = '{proObc.imgURL}'       
            //                    WHERE tbl_Product.ID = '{productID}'
            //    ";

            //SqlCommand command3 = new SqlCommand(query, connection._connection);
            //command3.ExecuteNonQuery();



            connection.CloseConnection();

        }
        //Add a new Product to DB
        public void AddProduct(int nrAttributes, string name, string articleNr, int quant, string brandID, string categoryID, string description,
                             string imgUrl, int atributeID1, int atributeID2, int atributeID3, int atributeID4, decimal priceb2b,
                             decimal priceb2c)
        {
            int ProductID = 0;
            connection.OpenConnection();
            //New Brand

            //New Category

            //New Product
            string sql = $@"Insert into  tbl_Product (Name,Description,BrandID,CategoryID,ImgUrl) 
            Values('" + name + "','" + description + "','" + brandID + "','" + categoryID + "','" + imgUrl + "')";
            using (SqlCommand command = new SqlCommand(sql, connection._connection))
            {
                command.ExecuteNonQuery();
            }
            //New Attributes


            //New Product_Attribute
            string query = $@"Insert into  tbl_Product_Attribute (AttributeID1,AttributeID2,AttributeID3,AttributeID4,ProductID,Quantity,PriceB2B,PriceB2C,ArticleNumber) 
            Values('" + atributeID1 + "','" + atributeID2 + "','" + atributeID3 + "','" + atributeID4 + "','"
            + ProductID + "','" + quant + "','" + priceb2b + "','" + priceb2c + "','" + articleNr + "')";
            using (SqlCommand command = new SqlCommand(sql, connection._connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}