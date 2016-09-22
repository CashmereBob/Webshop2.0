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
                    dataTable.Columns.AddRange(new DataColumn[9]
                    {
                       new DataColumn("ID"),
                       new DataColumn("ArticleNr"),
                       new DataColumn("Name"),
                       new DataColumn("CategoryID"),          
                       new DataColumn("BrandID"),
                       new DataColumn("Description"),
                       new DataColumn("b2bPrice"),
                       new DataColumn("b2cPrice"),
                       new DataColumn("boolAttribute"),
                    });

                    //                    string query = "SELECT * FROM tbl_Product";
                    string test = $@"select tbl_Product.ID,tbl_Product.Name,tbl_Category.Name AS category,tbl_Brand.Name as theBrand,tbl_Product.Description  from tbl_Product
                    INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
                    INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID";

                    string test2 = $@"Select 
tbl_Product.ID,
tbl_Product_Attribute.ArticleNumber,
tbl_Product.Name,
tbl_Category.Name AS category,
tbl_Brand.Name AS theBrand, 
tbl_Product.Description,
tbl_Product_Attribute.PriceB2B as b2b,
tbl_Product_Attribute.PriceB2C AS b2c
From tbl_Product

INNER JOIN tbl_Product_Attribute ON tbl_Product_Attribute.ProductID = tbl_Product.ID
INNER JOIN tbl_Brand ON tbl_Brand.ID = tbl_Product.BrandID
INNER JOIN tbl_Category ON tbl_Category.ID = tbl_Product.CategoryID";
               
                    using (SqlCommand command = new SqlCommand(test2, connection._connection))
                    {
                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var id = int.Parse(dataReader["ID"].ToString());
                                int articlenr;
                                try {  articlenr = int.Parse(dataReader["ArticleNumber"].ToString()); } catch  {  articlenr = 0; }
                                var name = dataReader["Name"].ToString();
                                var categoryid = dataReader["category"].ToString();                                                                                                         
                                var brandid = dataReader["theBrand"].ToString();
                                var description = dataReader["Description"].ToString();
                                var buissniesPrice = (dataReader["b2b"].ToString()+" kr");
                                var customPrice =    (dataReader["b2c"].ToString()+" kr");
                              
                                //1new DataColumn("ID"),
                                //2new DataColumn("ArticleNr"),
                                //3new DataColumn("Name"),
                                //4new DataColumn("CategoryID"),          
                                //5new DataColumn("BrandID"),
                                //6new DataColumn("Description"),
                                //7new DataColumn("b2bPrice"),
                                //8new DataColumn("b2cPrice"),
                                //9new DataColumn("boolAttribute"),
                             

                                dataTable.Rows.Add(id, articlenr, name, categoryid, brandid,
                                description, buissniesPrice, customPrice, false);
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

        public Dictionary<string, List<string>> GetAttribute(ProductObject product)
        {
            var dict = new Dictionary<string, List<string>>();
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
                                    @"FROM tbl_Attribute" +
                                    $"WHERE ID = '{art}'";


                    SqlCommand myCommand = new SqlCommand(sql, connection._connection);


                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {

                            if (dict.ContainsKey(myDataReader["name"].ToString())) {
                                dict[myDataReader["name"].ToString()].Add(myDataReader["Value"].ToString());
                            }
                            dict.Add(myDataReader["name"].ToString(), new List<string>() { myDataReader["Value"].ToString() });
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
    }
}