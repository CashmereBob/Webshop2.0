using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7
{
    public partial class _Default : Page
    {
        
        Pages pageDal = new Pages();
        Product product = new Product();
        List<ProductObject> productList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) { Panel_Login.Visible = false; Panel_SpecialOffers.Visible = true; }
                PageObject page = pageDal.GetStartPage();
            content.InnerHtml = page.content;    
              
            productList = product.GetNewestProducts();
            FillNews(productList);
        }

        private void FillNews(List<ProductObject> productList)
        {
            Label_Name_new1.Text = productList[0].name;
            Label_Name_new2.Text = productList[1].name;
            Label_Name_new3.Text = productList[2].name;
            Label_Name_new4.Text = productList[3].name;
            Label_Name_new5.Text = productList[4].name;
            Label_Name_new6.Text = productList[5].name;
            Label_Name_new7.Text = productList[6].name;
            Label_Name_new8.Text = productList[7].name;
            Label_Name_new9.Text = productList[8].name;
        }
    }
}