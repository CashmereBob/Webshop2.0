using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7
{
    public partial class page : System.Web.UI.Page
    {
        Pages pageDal = new Pages();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null) { 
            PageObject page = pageDal.GetPageById(int.Parse(Request.QueryString["id"]));
            content.InnerHtml = page.content;
            } else
            {
                Response.Redirect($"~/");
            }
        }
    }
}