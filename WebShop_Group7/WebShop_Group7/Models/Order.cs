using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Order
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllOrders()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Order"))
                {
                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Date"), new DataColumn("Firstname"), new DataColumn("Lastname") });

                    string sql = @"Select tbl_Order.ID AS[orderID], tbl_User.Firstname AS[Firstname], tbl_User.Lastname AS[Lastname], tbl_Order.[Date] " +
                                    @"From tbl_Order " +
                                    @"INNER JOIN tbl_User " +
                                    @"ON tbl_Order.UserID = tbl_User.ID " +
                                    @"INNER JOIN tbl_Carrier " +
                                    @"ON tbl_Order.CarrierID = tbl_Carrier.ID " +
                                    @"INNER JOIN tbl_Payment " +
                                    @"ON tbl_Order.PaymentID = tbl_Payment.ID " +
                                    @"ORDER BY tbl_Order.[Date] DESC, [orderID], [Firstname], [Lastname]";


        SqlCommand myCommand = new SqlCommand(sql, db._connection);


                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            int orderID = int.Parse(myDataReader["orderID"].ToString());
                            string firstname = myDataReader["Firstname"].ToString();
                            string lastname = myDataReader["Lastname"].ToString();
                            string date = myDataReader["Date"].ToString();

                            dt.Rows.Add(orderID, date, firstname, lastname);
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

        public OrderObject GetOrder(int id)
        {
            OrderObject order = new OrderObject();
           
            

            try
            {
                db.OpenConnection();

                string sql = @"Select tbl_Order.ID AS[orderID], tbl_User.Firstname AS[firstName], tbl_User.Lastname AS[lastName], tbl_User.Pricegroup AS[priceGroup], " +
                                @"tbl_User.Company AS[company], tbl_User.Adress AS[adress], tbl_User.Postalcode AS[postalCode], tbl_User.City AS[city], " +
                                @"tbl_User.Pricegroup AS[priceGroup], tbl_User.Telephone AS[telephone], tbl_User.Mobilephone AS[mobile], tbl_User.Email AS[email], " +
                                @"tbl_Product_Attribute.PriceB2B AS[priceB2B], tbl_Product_Attribute.PriceB2C AS[priceB2C], tbl_Product_Attribute.ArticleNumber AS[ArtNr], " +
                                @"[tbl_Order_Product-Attribute].Quantity AS[quantity], tbl_Product.Name AS[productName], tbl_User.Pricegroup AS[priceGroup], tbl_Carrier.Carrier AS [carrier], " +
                                @"tbl_Carrier.[Service] AS [carrierSevice], tbl_Carrier.Price AS[carrierPrice], tbl_User.Pricegroup AS[priceGroup], " +
                                @"tbl_Payment.Provider AS [payment], tbl_Payment.[Service] AS [paymentService], tbl_payment.Price AS[paymentPrice], " +
                                @"tbl_Product_Attribute.AttributeID1 AS[attribute1], tbl_Product_Attribute.AttributeID2 AS[attribute2], tbl_Product_Attribute.AttributeID3 AS[attribute3], tbl_Product_Attribute.AttributeID4 AS[attribute4], tbl_Order.Date " +
                                @"From[tbl_Order_Product-Attribute] " +
                                @"INNER JOIN tbl_Order " +
                                @"ON[tbl_Order_Product-Attribute].OrderID = tbl_Order.ID " +
                                @"INNER JOIN tbl_Product_Attribute " +
                                @"ON[tbl_Order_Product-Attribute].ProductAttributeID = tbl_Product_Attribute.ID " +
                                @"INNER JOIN tbl_User " +
                                @"ON tbl_Order.UserID = tbl_User.ID " +
                                @"INNER JOIN tbl_Carrier " +
                                @"ON tbl_Order.CarrierID = tbl_Carrier.ID " +
                                @"INNER JOIN tbl_Payment " +
                                @"ON tbl_Order.PaymentID = tbl_Payment.ID " +
                                @"INNER JOIN tbl_Product " +
                                @"ON tbl_Product_Attribute.ProductID = tbl_Product.ID " +
                                $"WHERE orderID = '{id}'";

                SqlCommand myCommand = new SqlCommand(sql, db._connection);


                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        decimal num = -1;

                        order.orderId = int.Parse(myDataReader["orderID"].ToString());
                        order.priceGroup = int.Parse(myDataReader["priceGroup"].ToString());
                        order.company = myDataReader["company"].ToString();
                        order.firstName = myDataReader["firstName"].ToString();
                        order.lastName = myDataReader["lastName"].ToString();
                        order.adress = myDataReader["adress"].ToString();
                        order.postalCode = myDataReader["postalCode"].ToString();
                        order.city = myDataReader["city"].ToString();
                        order.date = myDataReader["Date"].ToString();

                        order.telephone = myDataReader["telephone"].ToString();
                        order.mobile = myDataReader["mobile"].ToString();
                        order.email = myDataReader["email"].ToString();

                        ProductObject prod = new ProductObject();
                        prod.artNr = myDataReader["ArtNr"].ToString();
                        prod.name = myDataReader["productName"].ToString();
                        prod.quantity = int.Parse(myDataReader["quantity"].ToString());

                        decimal.TryParse(myDataReader["priceB2B"].ToString(), out num);
                        prod.priceB2B = num;
                        decimal.TryParse(myDataReader["priceB2C"].ToString(), out num);
                        prod.priceB2C = num;


                        order.carrier = myDataReader["carrier"].ToString();
                        order.carrierService = myDataReader["carrierSevice"].ToString();
                        decimal.TryParse(myDataReader["carrierPrice"].ToString(), out num);
                        order.carrierPrice = num;

                        order.payment = myDataReader["payment"].ToString();
                        order.paymentService = myDataReader["paymentService"].ToString();
                        decimal.TryParse(myDataReader["paymentPrice"].ToString(), out num);
                        order.paymentPrice = num;

                        int atr = -1;

                        int.TryParse(myDataReader["attribute1"].ToString(), out atr);
                        prod.attribute1 = atr;

                        int.TryParse(myDataReader["attribute2"].ToString(), out atr);
                        prod.attribute2 = atr;

                        int.TryParse(myDataReader["attribute3"].ToString(), out atr);
                        prod.attribute3 = atr;

                        int.TryParse(myDataReader["attribute4"].ToString(), out atr);
                        prod.attribute4 = atr;

                        order.AddProduct(prod);
                    }
                }


            return order;


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

        public DataTable GetProducts(OrderObject ord)
        {
            using (DataTable dt = new DataTable("Products"))
            {
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("ArtNr"), new DataColumn("name"), new DataColumn("attribut"), new DataColumn("price"), new DataColumn("quantity"), new DataColumn("sum") });


                foreach (ProductObject product in ord.products)
                {
                    string attribut = string.Empty;

                    var productDB = new Product();

                    Dictionary<string, string> atribut = productDB.GetAttribute(product);

                    foreach (KeyValuePair<string, string> atr in atribut)
                    {
                        
                            attribut += atr.Value + " ";
                                
                    }

                    decimal sum = -1;
             
                        if (ord.priceGroup == 2)
                        {
                            sum += product.priceB2B;
                        }
                        if (ord.priceGroup == 1)
                        {
                            sum += product.priceB2C;
                        }

                    decimal prodSum = sum * product.quantity;

                    dt.Rows.Add(product.artNr, product.name, attribut, sum.ToString("#.##"), product.quantity, prodSum.ToString("#.##"));
                }

                return dt;
            }
        }

    }
}
