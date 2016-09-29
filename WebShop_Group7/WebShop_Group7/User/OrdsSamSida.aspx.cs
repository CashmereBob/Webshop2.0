using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class OrdsSamSida : System.Web.UI.Page
    {
        OrderObject orderObject;
        UserObject userObject;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderObject = Session["Cart"] as OrderObject;
            userObject = orderObject.usr;


            Label1.Text = userObject.firstName;
        }
    }
}