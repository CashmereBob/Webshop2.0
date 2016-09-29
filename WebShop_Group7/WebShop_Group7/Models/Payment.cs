using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Payment
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllPayments()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Payment"))
                {
                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Provider"), new DataColumn("Service"),
                    new DataColumn("Price")});

                    string sql = "Select * From tbl_Payment";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var provider = myDataReader["Provider"].ToString();
                            var service = myDataReader["Service"].ToString();
                            var price = decimal.Parse(myDataReader["Price"].ToString());




                            dt.Rows.Add(id, provider, service, price);
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

        internal List<PaymentObject> GetAllPayments()
        {
            List<PaymentObject> result = new List<PaymentObject>();
            try
            {
                db.OpenConnection();

                    string sql = "Select * From tbl_Payment";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);


                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {

                        PaymentObject p = new PaymentObject();
                        p.paymentId = int.Parse(myDataReader["ID"].ToString());
                        p.service = myDataReader["Service"].ToString();
                        p.price = decimal.Parse(myDataReader["Price"].ToString());
                        p.service = myDataReader["Provider"].ToString();
                        result.Add(p);

                    }
                    return result;
          
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

        public PaymentObject GetPaymentById(int id) 
{

            PaymentObject payment = new PaymentObject();

            try
            {
                db.OpenConnection();

                string sql = $"Select * From tbl_Payment WHERE ID = '{id}'";
                SqlCommand myCommand = new SqlCommand(sql, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        payment.paymentId = int.Parse(myDataReader["ID"].ToString());
                        payment.payment = myDataReader["Provider"].ToString();
                        payment.service = myDataReader["Service"].ToString();
                        payment.price = decimal.Parse(myDataReader["Price"].ToString());
                    }
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



            return payment;


        }
        public void DeletePayment(int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"DELETE FROM tbl_Payment WHERE id = '{id}'";
                SqlCommand insertCmd = new SqlCommand(sql, db._connection);
                insertCmd.ExecuteNonQuery();

            }
            catch
            {
                //TODO exeption
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public void AddPayment(PaymentObject payment)
        {
            try
            {
                db.OpenConnection();

                string sql = $"Insert Into tbl_Payment (Provider, Service, Price ) Values('{payment.payment}', '{payment.service}', '{payment.price}' )";

                SqlCommand insertCmd = new SqlCommand(sql, db._connection);
                insertCmd.ExecuteNonQuery();

            }
            catch
            {
                //TODO exeption
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public void UppdatePayment(PaymentObject payment, int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"UPDATE tbl_Payment SET Provider = '{payment.payment}', Service = '{payment.service}', Price = '{payment.price}' WHERE ID = '{id}'";

                SqlCommand insertCmd = new SqlCommand(sql, db._connection);
                insertCmd.ExecuteNonQuery();

            }
            catch
            {
                //TODO Exeption
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }

}
