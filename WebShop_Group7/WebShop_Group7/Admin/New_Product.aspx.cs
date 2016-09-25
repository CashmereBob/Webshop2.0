using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class New_Product : System.Web.UI.Page
    {
        Product product = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            ProductObject proObj = new ProductObject();
            FillValues(proObj);
            product.AddProduct(proObj);
        }

        private void FillValues(ProductObject proObj)
        {
            proObj.name = TextBox_ProductName.Text;
            proObj.artNr = TextBox1_ArticleNumber.Text;
            proObj.brandName = TextBox_Brand.Text;
            proObj.category = TextBox_Category.Text;
            proObj.description = TextBox_Description.Text;
            proObj.imgURL = TextBox_ImgUlr.Text;
            proObj.quantity = int.Parse(TextBox_Quantity.Text);
            proObj.priceB2B = 1;
            proObj.priceB2C = 1;
        }

        protected void Button_NewProductIMG_Click(object sender, EventArgs e)
        {
            Image_Product.ImageUrl = TextBox_ImgUlr.Text;
            Label_ImgUrl.Text = TextBox_ImgUlr.Text;
            TextBox_ImgUlr.Text = "";
        }
    }
}