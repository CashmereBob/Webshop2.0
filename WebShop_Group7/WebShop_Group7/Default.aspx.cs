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

            Dictionary<string, string> Attri;

            //1
            if (productList[0] != null)
            {
                Label_Name_new1.Text = productList[0].name;
                Image_new1.ImageUrl = productList[0].imgURL;
                Label_Brand_new1.Text = productList[0].brandName;
                Label_Cat_new1.Text = productList[0].category;
                //Attributes
                Label_Attri_new1.Text = "|";
                Attri = product.GetAttribute(productList[0]);
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
            }
            //2
            if (productList[0] != null)
            {
                Label_Name_new2.Text = productList[1].name;
                Image_new2.ImageUrl = productList[1].imgURL;
                Label_Brand_new2.Text = productList[1].brandName;
                Label_Cat_new2.Text = productList[1].category;
                //Attributes
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
            }
            //3
            if (productList[0] != null)
            {
                Label_Name_new3.Text = productList[2].name;
                Image_new3.ImageUrl = productList[2].imgURL;
                Label_Brand_new3.Text = productList[2].brandName;
                Label_Cat_new3.Text = productList[2].category;
                //Attributes
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
            }
            //4
            if (productList[0] != null)
            {
                Label_Name_new4.Text = productList[3].name;
                Image_new4.ImageUrl = productList[3].imgURL;
                Label_Brand_new4.Text = productList[3].brandName;
                Label_Cat_new4.Text = productList[3].category;
                //Attributes
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
            }
            //5
            if (productList[0] != null)
            {
                Label_Name_new5.Text = productList[4].name;
                Image_new5.ImageUrl = productList[4].imgURL;
                Label_Brand_new5.Text = productList[4].brandName;
                Label_Cat_new5.Text = productList[4].category;
                //Attributes
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
            }
            //6
            if (productList[0] != null)
            {
                Label_Name_new6.Text = productList[5].name;
                Image_new6.ImageUrl = productList[5].imgURL;
                Label_Brand_new6.Text = productList[5].brandName;
                Label_Cat_new6.Text = productList[5].category;
                //Attributes
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
            }
            //7
            if (productList[0] != null)
            {
                Label_Name_new7.Text = productList[6].name;
                Image_new7.ImageUrl = productList[6].imgURL;
                Label_Brand_new7.Text = productList[6].brandName;
                Label_Cat_new7.Text = productList[6].category;
                //Attributes
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
            }
            //8
            if (productList[0] != null)
            {
                Label_Name_new8.Text = productList[7].name;
                Image_new8.ImageUrl = productList[7].imgURL;
                Label_Brand_new8.Text = productList[7].brandName;
                Label_Cat_new8.Text = productList[7].category;
                //Attributes
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
            }
            //9
            if (productList[0] != null)
            {
                Label_Name_new9.Text = productList[8].name;
                Image_new9.ImageUrl = productList[8].imgURL;
                Label_Brand_new9.Text = productList[8].brandName;
                Label_Cat_new9.Text = productList[8].category;
                //Attributes
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
            SetPrice();
        }
        private void SetPrice()
        {
            if(productList[0] != null)
            {
                if (true) { Label_Price_new1.Text = productList[0].priceB2B.ToString("#.##"); }
                else { Label_Price_new1.Text = productList[0].priceB2C.ToString("#.##"); }
            }
            if (productList[1] != null)
            {
                if (true) { Label_Price_new2.Text = productList[1].priceB2B.ToString("#.##"); }
                else { Label_Price_new2.Text = productList[1].priceB2C.ToString("#.##"); }
            }
            if (productList[2] != null)
            {
                if (true) { Label_Price_new3.Text = productList[2].priceB2B.ToString("#.##"); }
                else { Label_Price_new3.Text = productList[2].priceB2C.ToString("#.##"); }
            }
            if (productList[3] != null)
            {
                if (true) { Label_Price_new4.Text = productList[3].priceB2B.ToString("#.##"); }
                else { Label_Price_new4.Text = productList[3].priceB2C.ToString("#.##"); }
            }
            if (productList[4] != null)
            {
                if (true) { Label_Price_new5.Text = productList[4].priceB2B.ToString("#.##"); }
                else { Label_Price_new5.Text = productList[4].priceB2C.ToString("#.##"); }
            }
            if (productList[5] != null)
            {
                if (true) { Label_Price_new6.Text = productList[5].priceB2B.ToString("#.##"); }
                else { Label_Price_new6.Text = productList[5].priceB2C.ToString("#.##"); }
            }
            if (productList[6] != null)
            {
                if (true) { Label_Price_new7.Text = productList[6].priceB2B.ToString("#.##"); }
                else { Label_Price_new7.Text = productList[6].priceB2C.ToString("#.##"); }
            }
            if (productList[7] != null)
            {
                if (true) { Label_Price_new8.Text = productList[7].priceB2B.ToString("#.##"); }
                else { Label_Price_new8.Text = productList[7].priceB2C.ToString("#.##"); }
            }
            if (productList[8] != null)
            {
                if (true) { Label_Price_new9.Text = productList[8].priceB2B.ToString("#.##"); }
                else { Label_Price_new9.Text = productList[8].priceB2C.ToString("#.##"); }
            }     
        }
    }
}