using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Users
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllUsers()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("User"))
                {
                    dt.Columns.AddRange(new DataColumn[6] { new DataColumn("ID"), new DataColumn("Name"),
                    new DataColumn("Email"),new DataColumn("Pricegroup"), new DataColumn("Registered"), new DataColumn("Admin")});

                    string sql = "Select * From tbl_User";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        
                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var name = myDataReader["Firstname"].ToString() +" " + myDataReader["Lastname"].ToString();
                            var mail = myDataReader["Email"].ToString();
                            var pricegroup = int.Parse(myDataReader["Pricegroup"].ToString());
                            string registered = "Nej";
                            string admin = "Nej";

                            if(!string.IsNullOrWhiteSpace(myDataReader["Password"].ToString())) { registered = "Ja"; }
                            if ((bool)myDataReader["Admin"]) { admin = "Ja"; }


                            dt.Rows.Add(id,name,mail,pricegroup, registered, admin);
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
        public void AddUser(UserObject usr)
        {
            try
            {
                db.OpenConnection();

                string sql = $"Insert Into tbl_User (Firstname, Lastname, Adress, Postalcode, City, Email, Telephone, Mobilephone, Password, Salt, Pricegroup, Company, Admin) Values('{usr.firstName}', '{usr.lastName}', '{usr.adress}', '{usr.postalCode}', '{usr.city}', '{usr.email}', '{usr.telephone}', '{usr.mobile}', '{usr.password}', '{usr.salt}', '{usr.priceGroup}', '{usr.company}', '{usr.admin}' )";

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

        public UserObject GetUserById(int id) {

            UserObject user = new UserObject();

            try
            {
                db.OpenConnection();

                    string sql = $"Select * From tbl_User WHERE ID = '{id}'";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);

                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            user.userId = int.Parse(myDataReader["ID"].ToString());
                        user.admin = (bool)myDataReader["Admin"];
                        user.company = myDataReader["Company"].ToString();
                        user.firstName = myDataReader["Firstname"].ToString();
                        user.lastName = myDataReader["Lastname"].ToString();
                        user.adress = myDataReader["Adress"].ToString();
                        user.postalCode = myDataReader["Postalcode"].ToString();
                        user.city = myDataReader["City"].ToString();

                        user.email = myDataReader["Email"].ToString();
                        user.telephone = myDataReader["Telephone"].ToString();
                        user.mobile = myDataReader["Mobilephone"].ToString();

                        user.priceGroup = int.Parse(myDataReader["Pricegroup"].ToString());




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



            return user;
        }

        public void UpdateUser(UserObject usr, int id) {


            try
            {
                db.OpenConnection();

                string sql = string.Empty;

                if (string.IsNullOrWhiteSpace(usr.password))
                {
                    sql = $"UPDATE tbl_User SET Firstname = '{usr.firstName}', Lastname = '{usr.lastName}', Adress = '{usr.adress}', Postalcode = '{usr.postalCode}', City = '{usr.city}', Email = '{usr.email}', Telephone = '{usr.telephone}', Mobilephone = '{usr.mobile}', Pricegroup = '{usr.priceGroup}', Company = '{usr.company}', Admin = '{usr.admin}' WHERE ID = '{id}'";
                } else
                {
                    sql = $"UPDATE tbl_User SET Firstname = '{usr.firstName}', Lastname = '{usr.lastName}', Adress = '{usr.adress}', Postalcode = '{usr.postalCode}', City = '{usr.city}', Email = '{usr.email}', Telephone = '{usr.telephone}', Mobilephone = '{usr.mobile}', Password = '{usr.password}', Salt = '{usr.salt}', Pricegroup = '{usr.priceGroup}', Company = '{usr.company}', Admin = '{usr.admin}' WHERE ID = '{id}'";

                }

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

        public void DeleteUser(int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"DELETE FROM tbl_User WHERE id = '{id}'";
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
    }
}
