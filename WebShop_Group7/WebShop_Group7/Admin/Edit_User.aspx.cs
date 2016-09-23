using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class Edit_User : System.Web.UI.Page
    {
        Users userDal = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            {
                Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            }

            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    EditUser(int.Parse(Request.QueryString["id"]));
                }
            } else
            {
                CheckBox_delete.Visible = false;
                Label_delete.Visible = false;
            }

        }

        protected void AddNewUser()
        {
            UserObject user = new UserObject();
            user.admin = CheckBox_admin.Checked;
            user.company = TextBox_company.Text;
            user.firstName = TextBox_firstName.Text;
            user.lastName = TextBox_lastName.Text;
            user.adress = TextBox_adress.Text;
            user.postalCode = TextBox_postalCode.Text;
            user.city = TextBox_city.Text;

            user.email = TextBox_mail.Text;
            user.telephone = TextBox_phone.Text;
            user.mobile = TextBox_mobile.Text;

            user.priceGroup = int.Parse(RADIO_pricegroup.SelectedValue);

            if (!string.IsNullOrWhiteSpace(TextBox_password01.Text) || !string.IsNullOrWhiteSpace(TextBox_password02.Text))
            {
                if (TextBox_password01.Text == TextBox_password02.Text)
                {
                    UserService validate = new UserService();
                    user.salt = validate.CreateSalt(10);
                    user.password = validate.GenerateSHA256Hash(TextBox_password01.Text, user.salt);
                    userDal.AddUser(user);
                    Response.Redirect("~/Admin/List_Users.aspx");
                }
                else
                {
                    Lable_Passwordmatch.Text = "Lösenorden matchar inte, fyll i båda matchande för att skapa inloggning till användare.";
                }
            } else
            {
                userDal.AddUser(user);
                Response.Redirect("~/Admin/List_Users.aspx");
            }
                

        }

        protected void UpdateUser(int id)
        {
            UserObject user = new UserObject();
            user.admin = CheckBox_admin.Checked;
            user.company = TextBox_company.Text;
            user.firstName = TextBox_firstName.Text;
            user.lastName = TextBox_lastName.Text;
            user.adress = TextBox_adress.Text;
            user.postalCode = TextBox_postalCode.Text;
            user.city = TextBox_city.Text;

            user.email = TextBox_mail.Text;
            user.telephone = TextBox_phone.Text;
            user.mobile = TextBox_mobile.Text;

            var grupp = int.Parse(RADIO_pricegroup.SelectedValue);

            user.priceGroup = grupp;

            if (!string.IsNullOrWhiteSpace(TextBox_password01.Text) || !string.IsNullOrWhiteSpace(TextBox_password02.Text))
            {
                if (TextBox_password01.Text == TextBox_password02.Text)
                {
                    UserService validate = new UserService();
                    user.salt = validate.CreateSalt(10);
                    user.password = validate.GenerateSHA256Hash(TextBox_password01.Text, user.salt);
                    userDal.UpdateUser(user, id);
                    Response.Redirect("~/Admin/List_Users.aspx");
                }
                else
                {
                    Lable_Passwordmatch.Text = "Lösenorden matchar inte, fyll i båda matchande för att skapa inloggning till användare.";
                }
            }
            else
            {
                userDal.UpdateUser(user, id);
                Response.Redirect("~/Admin/List_Users.aspx");
            }


        }

        protected void EditUser(int id)
        {
            UserObject user = userDal.GetUserById(id);

            if (user.admin == true) { CheckBox_admin.Checked = true; }


            TextBox_company.Text = user.company;
            TextBox_firstName.Text = user.firstName;
            TextBox_lastName.Text = user.lastName;
            TextBox_adress.Text = user.adress;
            TextBox_postalCode.Text = user.postalCode;
            TextBox_city.Text = user.city;

            TextBox_mail.Text = user.email;
            TextBox_phone.Text = user.telephone;
            TextBox_mobile.Text = user.mobile;

            RADIO_pricegroup.SelectedValue = user.priceGroup.ToString();

        }

        protected void Button_submitUser_Click(object sender, EventArgs e)
        {
            if (CheckBox_delete.Checked == true)
            {
                userDal.DeleteUser(int.Parse(Request.QueryString["id"]));
                Response.Redirect("~/Admin/List_Users.aspx");
            }

            if (Request.QueryString["id"] == null)
            {
                AddNewUser();
            }
            else
            {
                UpdateUser(int.Parse(Request.QueryString["id"]));
            }
        }
    }
}