using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class Search_Result : System.Web.UI.Page
    {
        ProductObject productObject = new ProductObject();
        Product product = new Product();
        int priceGroup = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchString = Request.QueryString["search"];
            Label_SearchString.Text = searchString;

            List<ProductObject> productObjectList = product.SearchProducts(searchString);
           
            if (productObjectList.Count == 0)
            {

            }
            else
            {
                CheckPricegroup();
                FillTheOlds(productObjectList);
            }
         
        }
        private void CheckPricegroup()
        {
            if (Session["User"] != null)
            {
                Users user = new Users();
                UserObject uo = user.GetUserById((int)Session["User"]);
                priceGroup = uo.priceGroup;
            }
        }
        protected void FillTheOlds(List<ProductObject> productObjectList)
        {
            foreach (var item in productObjectList)
            {            
                string price = string.Empty;

                if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
                if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

                productResult.InnerHtml +=
                                                     $"<div class=\"col-sm-6 col-md-4 col-lg-4\"> " +
                                                        $"<div class=\"thumbnail\"> " +
                                                          $"<img src = \"Pictures/REA.png\" alt=\"...\" > " +
                                                          $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
                                                            $"<img src = \"Pictures/REA.png\" alt=\"...\" > " +
                                                          $"<div class=\"caption\" > " +
                                                            $"<h3>{item.name}</h3> " +
                                                            $"<h4 class=\"green\" >{price} kr</h4>" +
                                                            $"<p>{item.brandName}</p> " +
                                                            $"<p><a href=\"/product.aspx?id={item.productID}\" class=\"btn btn-primary\" role=\"button\">Mer info</a></p> " +
                                                          $"</div> " +
                                                        $"</div> " +

                                                    $"</div>";
            }
        }
    }
}