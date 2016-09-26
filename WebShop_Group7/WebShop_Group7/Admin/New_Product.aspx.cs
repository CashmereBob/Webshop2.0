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
        List<string> attributes = new List<string>();
        Product product = new Product();
        int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ID = int.Parse(Request.QueryString["id"]);
            }
            catch { ID = -1; }
            if (ID > 0)
            {
                RemakePage();
            }
        }

        private void RemakePage()
        {
            throw new NotImplementedException();
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            ProductObject proObj = new ProductObject();
            FillValues(proObj);
            product.AddProduct(proObj, attributes);
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
            proObj.priceB2B = int.Parse(TextBox_B2B.Text);
            proObj.priceB2C = int.Parse(TextBox_B2C.Text);
            if (!string.IsNullOrWhiteSpace(TextBox_Attribute1_Name.Text) && !string.IsNullOrWhiteSpace(TextBox_Attribute1_Value.Text)) { attributes.Add(TextBox_Attribute1_Name.Text + " " + TextBox_Attribute1_Value.Text); }
            if (!string.IsNullOrWhiteSpace(TextBox_Attribute2_Name.Text) && !string.IsNullOrWhiteSpace(TextBox_Attribute2_Value.Text)) { attributes.Add(TextBox_Attribute2_Name.Text + " " + TextBox_Attribute2_Value.Text); }
            if (!string.IsNullOrWhiteSpace(TextBox_Attribute3_Name.Text) && !string.IsNullOrWhiteSpace(TextBox_Attribute3_Value.Text)) { attributes.Add(TextBox_Attribute3_Name.Text + " " + TextBox_Attribute3_Value.Text); }
            if (!string.IsNullOrWhiteSpace(TextBox_Attribute4_Name.Text) && !string.IsNullOrWhiteSpace(TextBox_Attribute4_Value.Text)) { attributes.Add(TextBox_Attribute4_Name.Text + " " + TextBox_Attribute4_Value.Text); }
        }

        protected void Button_NewProductIMG_Click(object sender, EventArgs e)
        {
            Image_Product.ImageUrl = TextBox_ImgUlr.Text;
            Label_ImgUrl.Text = TextBox_ImgUlr.Text;
            TextBox_ImgUlr.Text = "";
        }
    }
}