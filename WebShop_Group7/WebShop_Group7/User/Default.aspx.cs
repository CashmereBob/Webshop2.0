﻿using System;
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
        int priceGroup = 1;
        Pages pageDal = new Pages();
        Product product = new Product();
        List<ProductObject> productList;
        List<ProductObject> productList_Old;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) { panel_left1.Visible = false; panel_left2.Visible = true; }
            PageObject page = pageDal.GetStartPage();
            PageObject page2 = pageDal.GetWelcome();
            
            if (!IsPostBack)
            {
                content.InnerHtml = page.content;
                welcome.InnerHtml = page2.content;
                
                CheckPricegroup();
                productList = product.GetNewestProducts(6);
                FillTheNews(productList);

                productList_Old = product.GetOldestProducts(3);
                FillTheOlds(productList_Old);
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

        protected void FillTheNews(List<ProductObject> newProduct)
        {
            foreach (var item in newProduct)
            {

                string price = string.Empty;

                if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
                if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

                productCont.InnerHtml += $"<div class=\"col-sm-6 col-md-4 col-lg-4\"> " +
                                                        $"<div class=\"thumbnail\"> " +
                                                          $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
                                                          $"<div class=\"caption\" > " +
                                                            $"<h3>{item.name}</h3> " +
                                                            $"<h4 class=\"green\" >{price} kr</h4>" +
                                                            $"<p>{item.brandName}</p> " +
                                                            $"<p><a href=\"/User/product.aspx?id={item.productID}\" class=\"btn btn-primary\" role=\"button\">Mer info</a></p> " +
                                                          $"</div> " +
                                                        $"</div> " +
                                                      $"</div>";
            }
        }
        protected void FillTheOlds(List<ProductObject> oldProduct)
        {
            //foreach (var item in oldProduct)
            //{

            //    string price = string.Empty;

            //    if (priceGroup == 1) { price = item.priceB2C.ToString("#,##"); }
            //    if (priceGroup == 2) { price = item.priceB2B.ToString("#,##"); }

            //    SpecialOffers.InnerHtml += 
            //                                         $"<div class=\"col-sm-12 col-md-12 col-lg-10\"> " +
            //                                            $"<div class=\"thumbnail\"> " +
            //                                              $"<img src = \"Pictures/REA.png\" alt=\"...\" > " +
            //                                              $"<img src = \"{item.imgURL}\" alt=\"...\" > " +
            //                                                $"<img src = \"Pictures/REA.png\" alt=\"...\" > " +
            //                                              $"<div class=\"caption\" > " +
            //                                                $"<h3>{item.name}</h3> " +
            //                                                $"<h4 class=\"green\" >{price} kr</h4>" +
            //                                                $"<p>{item.brandName}</p> " +
            //                                                $"<p><a href=\"/product.aspx?id={item.productID}\" class=\"btn btn-primary\" role=\"button\">Mer info</a></p> " +
            //                                              $"</div> " +
            //                                            $"</div> " +

            //                                        $"</div>";
            //}

            PageObject page = pageDal.GetOffers();
            SpecialOffers.InnerHtml = page.content;
        }
    }
}