using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class Varukorg : System.Web.UI.Page
    {
        Users users = new Users();
        Order order = new Order();
        Carrier carrier = new Carrier();
        List<CarrierObject> carriers;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUserTextboxVisible();
            // OrderObject orderObject = Session["Cart"] as OrderObject;
            OrderObject orderObject = order.GetOrder(1);
            //UserObject user = orderObject.usr;
            UserObject user = users.GetUserById(3);
            carriers = carrier.GetAllCarriers();
            FillUserInfo(user);
            FillOrderInfo(order);
        }

        private void FillOrderInfo(Order order)
        {
           
        }

        private void FillUserInfo(UserObject user)
        {
            UserHeadingFirstName.InnerHtml = "<strong>Förnamn</strong>";
            UserHeadingLastName.InnerHtml = "<strong>Efternamn</strong>";
            UserHeadingEmail.InnerHtml = "<strong>Email</strong>";



            if (users.GetUserById(user.userId) == null)
            {
                //User dont exists
                TextBox_FirstNameValue.Visible = true;
                TextBox_LastNameValue.Visible = true;
               TextBox_EmailValue.Visible = true;

            }
           else
            {
                FirstNameValue.InnerHtml = user.firstName;
                LastNameValue.InnerHtml = user.lastName;
                EmailValue.InnerHtml = user.email;
               //User exists!
               if (user.priceGroup == 1)
                {
                    //B2C   
                                
                }
               else
                {
                    //B2B
                    UserHeadingComany.InnerHtml = "<strong>Företag</strong>";
                    CompanyValue.InnerHtml = user.company;


                }
            }
        }
        private void SetUserTextboxVisible()
        {
            TextBox_FirstNameValue.Visible = false;
            TextBox_LastNameValue.Visible = false;
            TextBox_EmailValue.Visible = false;
        }
    }
}