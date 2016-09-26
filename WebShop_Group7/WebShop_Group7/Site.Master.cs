using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebShop_Group7.Models;
using System.Data.SqlClient;

namespace WebShop_Group7
{
  
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        Users userDal = new Users();

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            UserPages.Visible = false;

            if (Session["User"] != null)
            {
                UserObject user = userDal.GetUserById((int)Session["User"]);

                UserPages.Visible = true;
                login.Visible = false;
                label_user.Text = $"Välkommen tillbaka {user.firstName}";
            }

            if (!IsPostBack)
            {

                Pages pageDal = new Pages();

                foreach (PageObject page in pageDal.ListAllPagesList())
                {
                    if (page.name != "Startpage")
                    {
                        pageMeny.InnerHtml += $"<li><a href=\"page.aspx?id={page.pageId}\">{page.name}</a></li>";
                    }
                }

                Brand brandDal = new Brand();

                foreach (BrandObject brand in brandDal.ListAllBrandsList())
                {

                    brandMenu.InnerHtml += $"<li><a href=\"brand.aspx?id={brand.brandID}\">{brand.name}</a></li>";

                }
                brandMenu.InnerHtml += $"<li role = \"separator\" class=\"divider\" ></li><li><a href = \"brand.aspx\" >Alla</a></li>";

                Category categoryDal = new Category();

                foreach (CategoryObject category in categoryDal.ListAllCategoryList())
                {

                    categoryMenu.InnerHtml += $"<li><a href=\"category.aspx?id={category.categoryID}\">{category.name}</a></li>";

                }
                categoryMenu.InnerHtml += $"<li role = \"separator\" class=\"divider\" ></li><li><a href = \"category.aspx\" >Alla</a></li>";
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void Button_login_Click(object sender, EventArgs e)
        {
            var usrInput = TextBox_User.Text; //Plockar in användarnamnet från textbox
            var passInput = TextBox_Password.Text; //Plockar in lösenordet från textbox


            //Tomma variabler som ska innehålla värden hämtade från databasen (Om användarnamnet är registrerat)
            string saltFromDb = string.Empty;
            string passwordFromDb = string.Empty;
            int userID = -1;

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
                        userID = int.Parse(myDataReader["ID"].ToString()); 
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
            if (Login.GenerateSHA256Hash(passInput, saltFromDb) == passwordFromDb && !string.IsNullOrWhiteSpace(passInput)) //Kontrollerar om det inmatade lösenordet tillsammans med det lagrade saltet blir samma som det lagrade lösenordet samt kollar om användaren har adminrättigheter.
            {
                Session["User"] = userID; //Skapar en Admin session
                Response.Redirect($"~/");

            }
            else
            {
                //TODO - Medela att lösenordet eller användarnamnet  var fel
            }
        }

        protected void LinkButton_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/login.aspx");

        }
    }

}