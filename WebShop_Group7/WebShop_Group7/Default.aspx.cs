using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7
{
    public partial class _Default : Page
    {
        Pages pageDal = new Pages();
        protected void Page_Load(object sender, EventArgs e)
        {
            PageObject page = pageDal.GetStartPage();
            content.InnerHtml = page.content;
        }
    }
}