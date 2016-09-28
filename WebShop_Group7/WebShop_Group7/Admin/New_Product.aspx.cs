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
        ProductObject proObj = new ProductObject();
        int ID;
        bool makeSub;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            {
                Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            }
            try
            {
                ID = int.Parse(Request.QueryString["id"]);
            }
            catch { ID = -1; }
            if (ID > 0)
            {
            
                proObj = product.GetMainProduct(ID);
              
                proObj.productID = ID;
                RemakePage();
                makeSub = true;

            }
            else
            {
                makeSub = false;
                TextBox_B2B.TextMode =TextBoxMode.Number;
                TextBox_B2C.TextMode = TextBoxMode.Number;
            }
        }

        private decimal GetB2C(int iD)
        {
            throw new NotImplementedException();
        }

        private decimal GetB2B(int iD)
        {
            throw new NotImplementedException();
        }

        private void RemakePage()
        {
            Image_Product.ImageUrl = proObj.imgURL;
            //Name
            TextBox_ProductName.Text = proObj.name;
            TextBox_ProductName.Enabled = false;
            //Category
            TextBox_Category.Text = proObj.category;
            TextBox_Category.Enabled = false;
            //Brand
            TextBox_Brand.Text = proObj.brandName;
            TextBox_Brand.Enabled = false;
            //Img
            TextBox_ImgUlr.Text = proObj.imgURL;
            TextBox_ImgUlr.Enabled = false;
            Button_NewProductIMG.Visible = false;
            //Description
            TextBox_Description.Text = proObj.description;
            TextBox_Description.Enabled = false;
            //Price B2B      
            TextBox_B2B.Text = proObj.priceB2B.ToString("#.##");
            TextBox_B2B.Enabled = false;
            //Price B2C
            TextBox_B2C.Text = proObj.priceB2C.ToString("#.##");
            TextBox_B2C.Enabled = false;
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {       
            FillValues(proObj);
            product.AddProduct(proObj, attributes, makeSub);
            Response.Redirect("~/Admin/List_Products.aspx");
            Response.Write("Product created");
        }

        private void FillValues(ProductObject proObj)
        {
            proObj.name = TextBox_ProductName.Text;        
            proObj.artNr = TextBox1_ArticleNumber.Text;           
            proObj.brandName = TextBox_Brand.Text;         
            proObj.category = TextBox_Category.Text;         
            proObj.description = TextBox_Description.Text;         
            proObj.imgURL = Label_ImgUrl.Text;        
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