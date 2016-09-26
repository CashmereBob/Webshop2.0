using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class Edit_Product : System.Web.UI.Page
    {
        Product product = new Product();
        ProductObject proObc;
        
        Image img = new Image();
        string attributes = "";     
        int id;
        int ProductID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            {
                Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            }
            ProductID = int.Parse(Request.QueryString["id"]);
            id = ProductID;
            proObc = product.GetProduct(ProductID);
            proObc.productID = ProductID;
            LoadValues(ProductID);
            FillDroppDowns();
        }

        private void FillDroppDowns()
        {
            FillDroppdownListAttributeName();

        }
        private void FillDroppdownListAttributeName()
        {
            //attributeNames = product.GetDroppdownNames("tbl_Attribute");
            //DropDownList_AttributeName.DataSource = from i in attributeNames
            //                                        select new ListItem()
            //                                        {
            //                                            Text = i,
            //                                            Value = i
            //                                        };
            //DropDownList_AttributeName.DataBind();
        }

        private void LoadValues(int ProductID)
        {
            Image_Product.ImageUrl = proObc.imgURL;
            Label_ProductNameHeader.Text = proObc.name;
            Label_ArticleNumber.Text = proObc.artNr;
            Label_ProductName.Text = proObc.name;
            TextBox_Description.Text = proObc.description;
            Label_Quantity.Text = proObc.quantity.ToString();
            Label_Brand.Text = proObc.brandName;
            Label_Category.Text = proObc.category;
            Label_PriceB2B.Text = proObc.priceB2B.ToString() + "kr";
            Label_PriceB2C.Text = proObc.priceB2C.ToString() + "kr";

            GetAttributePanels(ProductID);


        }
       private void GetAttributePanels(int ProductID)
        {
            attributes = product.GetAttributes(ProductID);
            var attributeArray = attributes.Split('\t');
            try { Label_Attribute1.Text = attributeArray[0]; } catch { }
            try { Label_Attribute2.Text = attributeArray[1]; } catch { }
            try { Label_Attribute3.Text = attributeArray[2]; } catch { }
            try { Label_Attribute4.Text = attributeArray[3]; } catch { }
            SetPanelsTrue();
            if (Label_Attribute1.Text == "")
            {
                Panel_Attribute1.Visible = false;
            }
            if (Label_Attribute2.Text == "")
            {
                Panel_Attribute2.Visible = false;
            }
            if (Label_Attribute3.Text == "")
            {
                Panel_Attribute3.Visible = false;
            }
            if (Label_Attribute4.Text == "")
            {
                Panel_Attribute4.Visible = false;
            }
            if (Label_Attribute1.Text != "" && Label_Attribute2.Text != "" && Label_Attribute3.Text != "" && Label_Attribute4.Text != "" )
            {
                Panel_Add_Attributes.Visible = false;
            }
        }
        private void SetPanelsTrue()
        {
            Panel_Add_Attributes.Visible = true;
            Panel_Attribute1.Visible = true;
            Panel_Attribute2.Visible = true;
            Panel_Attribute3.Visible = true;
            Panel_Attribute4.Visible = true;
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TextBox1_ArticleNumber.Text)) { proObc.artNr = TextBox1_ArticleNumber.Text; }
            if (!string.IsNullOrWhiteSpace(TextBox_Quantity.Text)) { proObc.quantity = int.Parse(TextBox_Quantity.Text); }
            if (!string.IsNullOrWhiteSpace(TextBox_PriceB2C.Text)) { proObc.priceB2C = decimal.Parse(TextBox_PriceB2C.Text); }
            else { proObc.priceB2C =removeKR(Label_PriceB2C.Text); }
            if (!string.IsNullOrWhiteSpace(TextBox_PriceB2B.Text)) { proObc.priceB2B = decimal.Parse(TextBox_PriceB2B.Text); }
            else { proObc.priceB2B = removeKR(Label_PriceB2B.Text); }
         
       
            product.saveProductChanges(proObc);
            LoadValues(id);
            FillDroppDowns();
            ClearAllTextBoxes();
            GetAttributePanels(ProductID);
        }

        private decimal removeKR(string text)
        {
          var here =  text.Split(',');
           int pars = int.Parse(here[0]);
           return (decimal)pars;
        }

        private void ClearAllTextBoxes()
        {
            TextBox1_ArticleNumber.Text = "";
            TextBox_Quantity.Text = "";
            TextBox_AttributeValue.Text = "";
            TextBox_PriceB2C.Text = "";
            TextBox_PriceB2B.Text = "";
        }

        protected void Button_AddAttribute_Click(object sender, EventArgs e)
        {
            List<string> Attributes = FillAttributeList();
            if (Panel_Attribute1.Visible == false) { Attributes.Add(TextBox_AttributeName.Text + " " + TextBox_AttributeValue.Text); }
            else if (Panel_Attribute2.Visible == false) { Attributes.Add( TextBox_AttributeName.Text + " " + TextBox_AttributeValue.Text); }
            else if (Panel_Attribute3.Visible == false) { Attributes.Add( TextBox_AttributeName.Text + " " + TextBox_AttributeValue.Text); }
            else if (Panel_Attribute4.Visible == false) { Attributes.Add( TextBox_AttributeName.Text + " " + TextBox_AttributeValue.Text); }
            else { Response.Write("You cant have more then 4 attributes"); return; }
            TextBox_AttributeName.Text = "";
            TextBox_AttributeValue.Text = "";
            product.addAttribute(proObc,Attributes);
            GetAttributePanels(ProductID);
        }
        private List<string> FillAttributeList()
        {
            List<string> result = new List<string>();
            if (Panel_Attribute1.Visible == true) { result.Add(Label_Attribute1.Text); }
            if (Panel_Attribute2.Visible == true) { result.Add(Label_Attribute2.Text); }
            if (Panel_Attribute3.Visible == true) { result.Add(Label_Attribute3.Text); }
            if (Panel_Attribute4.Visible == true) { result.Add(Label_Attribute4.Text); }
            return result;
        }

        protected void Button_RemoveAttribute1_Click(object sender, EventArgs e)
        {
            Panel_Attribute1.Visible = false; ;
            product.removeAttribute(Label_Attribute1.Text, proObc);
            Label_Attribute1.Text = "";
            GetAttributePanels(ProductID);
        }

        protected void Button_RemoveAttribute2_Click(object sender, EventArgs e)
        {
            Panel_Attribute2.Visible = false; ;
            product.removeAttribute(Label_Attribute2.Text, proObc);
            Label_Attribute2.Text = "";
            GetAttributePanels(ProductID);
        }

        protected void Button_RemoveAttribute3_Click(object sender, EventArgs e)
        {
            Panel_Attribute3.Visible = false; 
            product.removeAttribute(Label_Attribute3.Text, proObc);
            Label_Attribute3.Text = "";
            GetAttributePanels(ProductID);
        }

        protected void Button_RemoveAttribute4_Click(object sender, EventArgs e)
        {
            Panel_Attribute4.Visible = false; 
            product.removeAttribute(Label_Attribute4.Text, proObc);
            Label_Attribute4.Text = "";
            GetAttributePanels(ProductID);
        }
    }
}