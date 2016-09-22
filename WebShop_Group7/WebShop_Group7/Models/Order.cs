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
                    dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ID"), new DataColumn("Firstname"), new DataColumn("Lastname") });

                    string sql = @"Select tbl_Order.ID AS [orderID], tbl_User.Firstname AS [Firstname], tbl_User.Lastname AS [Lastname] " +
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
                                    @"ON tbl_Order.PaymentID = tbl_Payment.ID";

                    SqlCommand myCommand = new SqlCommand(sql, db._connection);


                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            int orderID = int.Parse(myDataReader["orderID"].ToString());
                            string firstname = myDataReader["Firstname"].ToString();
                            string lastname = myDataReader["Lastname"].ToString();

                            dt.Rows.Add(orderID, firstname, lastname);
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

        //public OrderObject GetOrder(int id)
        //{
        //    OrderObject order = new OrderObject();

        //    try
        //    {
        //        db.OpenConnection();

               
                   

        //            string sql = @"Select tbl_Order.ID AS [orderID], tbl_User.Firstname AS [Firstname], tbl_User.Lastname AS [Lastname] " +
        //                            @"From[tbl_Order_Product-Attribute] " +
        //                            @"INNER JOIN tbl_Order " +
        //                            @"ON[tbl_Order_Product-Attribute].OrderID = tbl_Order.ID " +
        //                            @"INNER JOIN tbl_Product_Attribute " +
        //                            @"ON[tbl_Order_Product-Attribute].ProductAttributeID = tbl_Product_Attribute.ID " +
        //                            @"INNER JOIN tbl_User " +
        //                            @"ON tbl_Order.UserID = tbl_User.ID " +
        //                            @"INNER JOIN tbl_Carrier " +
        //                            @"ON tbl_Order.CarrierID = tbl_Carrier.ID " +
        //                            @"INNER JOIN tbl_Payment " +
        //                            @"ON tbl_Order.PaymentID = tbl_Payment.ID";

        //            SqlCommand myCommand = new SqlCommand(sql, db._connection);


        //            using (SqlDataReader myDataReader = myCommand.ExecuteReader())
        //            {

        //                while (myDataReader.Read())
        //                {
        //                    int orderID = int.Parse(myDataReader["orderID"].ToString());
        //                    string firstname = myDataReader["Firstname"].ToString();
        //                    string lastname = myDataReader["Lastname"].ToString();

                            
        //                }
        //            }
        //            myCommand.ExecuteNonQuery();

        //        return dt;
                

        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db.CloseConnection();
        //    }
        //}

    }
}
