using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login(object sender, EventArgs e) //Metod som validerar inloggning och skapar session
        {
            var usrInput = TextBox_AdminUserName.Text; //Plockar in användarnamnet från textbox
            var passInput = TextBox_AdminPassword.Text; //Plockar in lösenordet från textbox
            

            //Tomma variabler som ska innehålla värden hämtade från databasen (Om användarnamnet är registrerat)
            string saltFromDb = string.Empty;
            string passwordFromDb = string.Empty;
            bool isAdminFromDb = false;

            DBConnection db = new DBConnection(); //Initierar en DBConnection class för att kunna koppla upp mot databasen

            //Try catch där vi försöker läsa värden från databasen.
            try
            {
                db.OpenConnection(); // Öppnar databasen
                string sql1 = $"Select * From tbl_User Where Email = '{usrInput}'"; //Skapar en variabel innehållandes vår query, Denna queryn väljer alla kolumner från table tbl_User där kolumnen Email är samma som det inmatade användarnamnet.
                SqlCommand myCommand = new SqlCommand(sql1, db._connection); //Skapar upp vårt kommando med vår conenctionstring och vår query.

                using (SqlDataReader myDataReader = myCommand.ExecuteReader()) //Tar emot svaret från databasen.
                {
                    while (myDataReader.Read()) //Loopar igenom alla träffar
                    {
                        saltFromDb = myDataReader["Salt"].ToString(); //Lägger användarens Salt i SaltFromDb variabeln
                        passwordFromDb = myDataReader["Password"].ToString(); //Lägger användarens Password i passwordFromDb variabeln
                        isAdminFromDb = (bool)myDataReader["Admin"]; //Lägger in boolvärdet från användarens Admin status i isAdminFromDb variabeln,
                    }
                }
                //myCommand.ExecuteNonQuery(); //Executar vårt command.
            }
            catch
            {
                //TODO - Fixa exeption
            }
            finally
            {
                db.CloseConnection(); //Stänger alltid connection oavsett vad som händer i try catch.

            }

            var Login = new UserService(); //Skapar upp en instance av UserService för att validera insamlade uppgifter.
            if (Login.GenerateSHA256Hash(passInput, saltFromDb) == passwordFromDb && isAdminFromDb) //Kontrollerar om det inmatade lösenordet tillsammans med det lagrade saltet blir samma som det lagrade lösenordet samt kollar om användaren har adminrättigheter.
            {
                Session["Admin"] = usrInput; //Skapar en Admin session
                Response.Redirect("List_Order.aspx"); //Skickar vidare till Admin Startsida.
            }
            else
            {
                //TODO - Medela att lösenordet eller användarnamnet  var fel
            }
        }



    }
    }
