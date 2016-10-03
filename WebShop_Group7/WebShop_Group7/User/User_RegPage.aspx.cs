using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;


namespace WebShop_Group7.User
{
    public partial class User_RegPage : System.Web.UI.Page
    {
        Users userDal = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        protected void addNewUser(object sender, EventArgs e)
        {
            UserObject newUser = new UserObject();

            newUser.firstName = TextBox_UserFirstName.Text;
            newUser.lastName = TextBox_UserLastName.Text;
            newUser.adress = TextBox_UserAdress.Text;
            newUser.postalCode = TextBox_UserZipCode.Text;
            newUser.city = TextBox_UserCity.Text;
            newUser.email = TextBox_UserEmail.Text;
            newUser.telephone = TextBox_UserPhone.Text;
            newUser.mobile = TextBox_UserMobilePhone.Text;
            newUser.company = TextBox_UserCompay.Text;
            newUser.priceGroup = 1;
            newUser.admin = false;

            if (!string.IsNullOrWhiteSpace(TextBox_UserPassword.Text) || string.IsNullOrWhiteSpace(TextBox_UserPasswordAgain.Text))
            {
                if (TextBox_UserPassword.Text == TextBox_UserPasswordAgain.Text)
                {
                    UserService passwordService = new UserService();
                    newUser.salt = passwordService.CreateSalt(10);
                    newUser.password = passwordService.GenerateSHA256Hash(TextBox_UserPassword.Text, newUser.salt);
                    userDal.AddUser(newUser);
                    Response.Redirect("~/");
                }
                else
                {
                    Lable_Passwordmatch.Text = "Lösenorden matchar inte, fyll i båda matchande för att skapa inloggning till användare.";
                }
            }
            



                

            

        }

       
    }
}