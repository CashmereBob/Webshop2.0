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
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderObject orderObject = Session["Cart"] as OrderObject;
            UserObject user = orderObject.usr;
        }
    }
}