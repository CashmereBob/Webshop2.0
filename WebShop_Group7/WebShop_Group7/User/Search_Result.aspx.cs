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
        int priceGroup = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchString = Request.QueryString["search"];
            Label_SearchString.Text = searchString;
            Panel_SearchFailed.Visible = false;
            List<ProductObject> productNameSearchList = product.SearchName("tbl_Product.Name", searchString);
            List<ProductObject> brandSearchList = product.SearchName("tbl_Brand.Name", searchString);
            List<ProductObject> categorySearchList = product.SearchName("tbl_Category.Name", searchString);
            List<ProductObject> descriptionSearchList = product.SearchName("tbl_Product.Description", searchString);
            CheckPricegroup();

            //Check ProductName Search list
            if (productNameSearchList.Count == 0)
            {
                Panel_NameSearch.Visible = false;
            }
            else
            {
                FillSearchName(productNameSearchList);
            }
            //Check BrandSearchList
            if (brandSearchList.Count == 0)
            {
                Panel_BrandSearch.Visible = false;
            }
            else
            {
                FillSearchBrand(brandSearchList);
            }
            //Check CategoryList
            if (categorySearchList.Count == 0)
            {
                Panel_CategorySearch.Visible = false;
            }
            else
            {
                FillSearchCategory(categorySearchList);
            }
            //Check Description
            if (descriptionSearchList.Count == 0)
            {
                Panel_DivSearch.Visible = false;
            }
            else
            {
                FillSearchDiv(descriptionSearchList);
            }
            if (productNameSearchList.Count == 0 && brandSearchList.Count == 0 && categorySearchList.Count == 0 && descriptionSearchList.Count == 0)
            {
                Panel_SearchFailed.Visible = true;
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
        protected void FillSearchName(List<ProductObject> productObjectList)
        {
            NameResult.InnerHtml = "";

            foreach (var item in productObjectList)
            {
                string price = string.Empty;

                if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
                if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

                NameResult.InnerHtml +=
                                                     $"<div class=\"col-sm-6 col-md-4 col-lg-3\"> " +
                                                        $"<div class=\"thumbnail\"> " +
                                                  
                                                          $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
                                                      
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
        protected void FillSearchBrand(List<ProductObject> productObjectList)
        {
            BrandResult.InnerHtml = "";

            foreach (var item in productObjectList)
            {
                string price = string.Empty;

                if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
                if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

                BrandResult.InnerHtml +=
                                                     $"<div class=\"col-sm-6 col-md-4 col-lg-3\"> " +
                                                        $"<div class=\"thumbnail\"> " +
                                                 
                                                          $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
                                                      
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
        protected void FillSearchCategory(List<ProductObject> productObjectList)
        {
            CategoryResult.InnerHtml = "";

            foreach (var item in productObjectList)
            {
                string price = string.Empty;

                if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
                if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

                CategoryResult.InnerHtml +=
                                                     $"<div class=\"col-sm-6 col-md-4 col-lg-3\"> " +
                                                        $"<div class=\"thumbnail\"> " +
                                               
                                                          $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
                                                     
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
        protected void FillSearchDiv(List<ProductObject> productObjectList)
        {
            Div_DivResult.InnerHtml = "";

            foreach (var item in productObjectList)
            {
                string price = string.Empty;

                if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
                if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

                Div_DivResult.InnerHtml +=
                                                     $"<div class=\"col-sm-6 col-md-4 col-lg-3\"> " +
                                                        $"<div class=\"thumbnail\"> " +

                                                          $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
                                                     
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