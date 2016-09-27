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
            //Names
            Label_Name_new1.Text = productList[0].name;
            Label_Name_new2.Text = productList[1].name;
            Label_Name_new3.Text = productList[2].name;
            Label_Name_new4.Text = productList[3].name;
            Label_Name_new5.Text = productList[4].name;
            Label_Name_new6.Text = productList[5].name;
            Label_Name_new7.Text = productList[6].name;
            Label_Name_new8.Text = productList[7].name;
            Label_Name_new9.Text = productList[8].name;
            //Img
            Image_new1.ImageUrl = productList[0].imgURL;
            Image_new2.ImageUrl = productList[1].imgURL;
            Image_new3.ImageUrl = productList[2].imgURL;
            Image_new4.ImageUrl = productList[3].imgURL;
            Image_new5.ImageUrl = productList[4].imgURL;
            Image_new6.ImageUrl = productList[5].imgURL;
            Image_new7.ImageUrl = productList[6].imgURL;
            Image_new8.ImageUrl = productList[7].imgURL;
            Image_new9.ImageUrl = productList[8].imgURL;
            //Price
            SetPrice();
            //Brand
            Label_Brand_new1.Text = productList[0].brandName;
            Label_Brand_new2.Text = productList[1].brandName;
            Label_Brand_new3.Text = productList[2].brandName;
            Label_Brand_new4.Text = productList[3].brandName;
            Label_Brand_new5.Text = productList[4].brandName;
            Label_Brand_new6.Text = productList[5].brandName;
            Label_Brand_new7.Text = productList[6].brandName;
            Label_Brand_new8.Text = productList[7].brandName;
            Label_Brand_new9.Text = productList[8].brandName;
            //Category
            Label_Cat_new1.Text = productList[0].category;
            Label_Cat_new2.Text = productList[1].category;
            Label_Cat_new3.Text = productList[2].category;
            Label_Cat_new4.Text = productList[3].category;
            Label_Cat_new5.Text = productList[4].category;
            Label_Cat_new6.Text = productList[5].category;
            Label_Cat_new7.Text = productList[6].category;
            Label_Cat_new8.Text = productList[7].category;
            Label_Cat_new9.Text = productList[8].category;
            //Attributes
            //1
            Label_Attri_new1.Text = "|";
            Dictionary<string, string> Attri = product.GetAttribute(productList[0]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new1.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

            
            }
            //2
            Label_Attri_new2.Text = "|";
             Attri = product.GetAttribute(productList[1]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new2.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

           
            }
            //3
            Label_Attri_new3.Text = "|";
            Attri = product.GetAttribute(productList[2]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new3.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

            
            }
            //4
            Label_Attri_new4.Text = "|";
            Attri = product.GetAttribute(productList[3]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new4.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

           
            }
            //5
            Label_Attri_new5.Text = "|";
            Attri = product.GetAttribute(productList[4]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new5.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

         
            }
            //6
            Label_Attri_new6.Text = "|";
            Attri = product.GetAttribute(productList[5]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new6.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

            
            }
            //7
            Label_Attri_new7.Text = "|";
            Attri = product.GetAttribute(productList[6]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new7.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

             
            }
            //8
            Label_Attri_new8.Text = "|";
            Attri = product.GetAttribute(productList[7]);
            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new8.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

             
            }
            //9
            Label_Attri_new9.Text = "|";
            Attri = product.GetAttribute(productList[8]);

            try
            {
                foreach (var item in Attri)
                {
                    Label_Attri_new9.Text += item.Key + ": " + item.Value + " | ";
                }
            }
            catch (Exception)
            {

                
            }

        }
        private void SetPrice()
        {
            if (true)
            {
                //Price B2B
                Label_Price_new1.Text = productList[0].priceB2B.ToString("#.##");
                Label_Price_new2.Text = productList[1].priceB2B.ToString("#.##");
                Label_Price_new3.Text = productList[2].priceB2B.ToString("#.##");
                Label_Price_new4.Text = productList[3].priceB2B.ToString("#.##");
                Label_Price_new5.Text = productList[4].priceB2B.ToString("#.##");
                Label_Price_new6.Text = productList[5].priceB2B.ToString("#.##");
                Label_Price_new7.Text = productList[6].priceB2B.ToString("#.##");
                Label_Price_new8.Text = productList[7].priceB2B.ToString("#.##");
                Label_Price_new9.Text = productList[8].priceB2B.ToString("#.##");
            }
            else
            {
                //Price B2C
                Label_Price_new1.Text = productList[0].priceB2C.ToString("#.##");
                Label_Price_new2.Text = productList[1].priceB2C.ToString("#.##");
                Label_Price_new3.Text = productList[2].priceB2C.ToString("#.##");
                Label_Price_new4.Text = productList[3].priceB2C.ToString("#.##");
                Label_Price_new5.Text = productList[4].priceB2C.ToString("#.##");
                Label_Price_new6.Text = productList[5].priceB2C.ToString("#.##");
                Label_Price_new7.Text = productList[6].priceB2C.ToString("#.##");
                Label_Price_new8.Text = productList[7].priceB2C.ToString("#.##");
                Label_Price_new9.Text = productList[8].priceB2C.ToString("#.##");
            }
        }
    }
}