using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;


namespace WebShop_Group7.User
{
    public partial class User_page : System.Web.UI.Page
    {
        Users userDal = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) //Kontrollerar om det finns en User session.
            {
                Response.Redirect("~/"); //Om inte gå tillbaka till startsida.
            }

            
                if (!IsPostBack)
                {
                    EditUser((int)Session["User"]);
                }
            }
            
        protected void EditUser(int id)
        {
            UserObject user = userDal.GetUserById(id);
            TextBox_firstName.Text = user.firstName;
            TextBox_lastName.Text = user.lastName;
            TextBox_company.Text = user.company;
            TextBox_adress.Text = user.adress;
            TextBox_postalCode.Text = user.postalCode;
            TextBox_city.Text = user.city;
            TextBox_phone.Text = user.telephone;
            TextBox_mobile.Text = user.mobile;
            TextBox_mail.Text = user.email;
           




        }
        protected void UpdateUser(int id)
        {
            UserObject updatedUser = new UserObject();
            updatedUser.firstName = TextBox_firstName.Text;
            updatedUser.lastName = TextBox_lastName.Text;
            updatedUser.company = TextBox_company.Text;
            updatedUser.adress = TextBox_adress.Text;
            updatedUser.postalCode = TextBox_postalCode.Text;
            updatedUser.city = TextBox_city.Text;
            updatedUser.telephone = TextBox_phone.Text;
            updatedUser.mobile = TextBox_mobile.Text;
            updatedUser.email = TextBox_mail.Text;

            if (!string.IsNullOrWhiteSpace(TextBox_UserPassword.Text) || string.IsNullOrWhiteSpace(TextBox_UserPasswordAgain.Text))
            {
                if (TextBox_UserPassword.Text == TextBox_UserPasswordAgain.Text)
                {
                    UserService passwordService = new UserService();
                    updatedUser.salt = passwordService.CreateSalt(10);
                    updatedUser.password = passwordService.GenerateSHA256Hash(TextBox_UserPassword.Text, updatedUser.salt);
                    userDal.UpdateUser(updatedUser, (int)Session["User"]);
                    Response.Redirect("~/");
                }
                else
                {
                    Lable_Passwordmatch.Text = "Lösenorden matchar inte, fyll i båda matchande för att skapa inloggning till användare.";
                    return;
                }
                Response.Redirect("~/User/User_Page.aspx");
            }
        }
        protected void SendUpdatedUser(object sender, EventArgs e)
        {
            UpdateUser((int)Session["User"]);
        }
            
    }
}