using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Carrier
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllCarriers()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Carrier"))
                {
                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Carrier"), new DataColumn("Service"),
                    new DataColumn("Price")});

                    string sql = "Select * From tbl_Carrier";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var carrier = myDataReader["Carrier"].ToString();
                            var service = myDataReader["Service"].ToString();
                            var price = decimal.Parse(myDataReader["Price"].ToString());




                            dt.Rows.Add(id, carrier, service, price);
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

        internal List<CarrierObject> GetAllCarriers()
        {
            List<CarrierObject> result = new List<CarrierObject>();     
            string query; 
            try
            {
                query = $@"SELECT tbl_Carrier.ID FROM tbl_Carrier";
                db.OpenConnection();
                SqlCommand myCommand = new SqlCommand(query, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        result.Add(GetCarrierById(int.Parse(myDataReader["ID"].ToString())));
                    }
                }
            }
            catch { }
            finally { db.CloseConnection(); }
            return result;
        }

        public CarrierObject GetCarrierById(int id)
        {
            CarrierObject carrier = new CarrierObject();

            try
            {
                db.OpenConnection();

                string sql = $"Select * From tbl_Carrier WHERE ID = '{id}'";
                SqlCommand myCommand = new SqlCommand(sql, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        carrier.carrierId = int.Parse(myDataReader["ID"].ToString());
                        carrier.carrier = myDataReader["Carrier"].ToString();
                        carrier.service = myDataReader["Service"].ToString();
                        carrier.price = decimal.Parse(myDataReader["Price"].ToString());
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



            return carrier;
        }

        public void DeleteCarrier(int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"DELETE FROM tbl_Carrier WHERE id = '{id}'";
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

        public void AddCarrier(CarrierObject carrier)
        {
            try
            {
                db.OpenConnection();

                string sql = $"Insert Into tbl_Carrier (Carrier, Service, Price ) Values('{carrier.carrier}', '{carrier.service}', '{carrier.price}' )";

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

        public void UppdateCarier(CarrierObject carrier, int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"UPDATE tbl_Carrier SET Carrier = '{carrier.carrier}', Service = '{carrier.service}', Price = '{carrier.price}' WHERE ID = '{id}'";

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