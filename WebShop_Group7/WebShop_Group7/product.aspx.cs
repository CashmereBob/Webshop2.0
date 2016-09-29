using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;


namespace WebShop_Group7
{
    public partial class product : System.Web.UI.Page
    {
        Users usrDal = new Users();
        Product proDal = new Product();
        int pricegroup = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                UserObject usr = usrDal.GetUserById((int)Session["User"]);
                pricegroup = usr.priceGroup;
            }

            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    DrawProduct(int.Parse(Request.QueryString["id"]));
                }
            }
            else
            {
                Response.Redirect("~/category.aspx");
            }


        }

        protected void DrawProduct(int id)
        {

            decimal price = 0;
            decimal vat = 0;

            ProductObject product = proDal.GetMainProduct(id);

            Dictionary<string, List<string>> attributes = GetAllAtributes(id);

            head.InnerHtml = $"<h2>{product.name}</h2><h3>{product.brandName}</h3><h4>{product.category}</h4>";
            img.InnerHtml = $"<div class=\"thumbnail\"><img src = \"{product.imgURL}\" alt=\"{product.name}\" ></div>";

            prodbesk.InnerHtml = product.description;
            int counter = 0;

            if (attributes != null)
            {
                foreach (KeyValuePair<string, List<string>> atr in attributes)
                {
                    
                    if (counter == 0) { atr1lable.InnerHtml = atr.Key; }
                    if (counter == 1) { atr2lable.InnerHtml = atr.Key; }
                    if (counter == 2) { atr3lable.InnerHtml = atr.Key; }
                    if (counter == 3) { atr4lable.InnerHtml = atr.Key; }

                    foreach (string value in atr.Value)
                    {

                        if (counter == 0) { atr1.Items.Insert(0, new ListItem(value, proDal.GetAttributeID(atr.Key, value).ToString())); }
                        if (counter == 1) { atr2.Items.Insert(0, new ListItem(value, proDal.GetAttributeID(atr.Key, value).ToString())); }
                        if (counter == 2) { atr3.Items.Insert(0, new ListItem(value, proDal.GetAttributeID(atr.Key, value).ToString())); }
                        if (counter == 3) { atr4.Items.Insert(0, new ListItem(value, proDal.GetAttributeID(atr.Key, value).ToString())); }

                    }
                    
                    counter++;
                }
            }
            if (counter == 0) { atr1.Visible = false; atr1lable.Visible = false; atr2.Visible = false; atr2lable.Visible = false; atr3.Visible = false; atr3lable.Visible = false; atr4.Visible = false; atr4lable.Visible = false; }
            if (counter == 1) { atr2.Visible = false; atr2lable.Visible = false; atr3.Visible = false; atr3lable.Visible = false; atr4.Visible = false; atr4lable.Visible = false; }
            if (counter == 2) { atr3.Visible = false; atr3lable.Visible = false; atr4.Visible = false; atr4lable.Visible = false; }
            if (counter == 3) { atr4.Visible = false; atr4lable.Visible = false; }


            if (pricegroup == 1) { price = product.priceB2C; }
            if (pricegroup == 2) { price = product.priceB2B; }

            vat = Decimal.Multiply(price, 0.25M);

            pris.InnerHtml = price.ToString("#.##");
            moms.InnerHtml = vat.ToString("#.##");
            
        }


        protected Dictionary<string, List<string>> GetAllAtributes(int id)
        {
            List<ProductObject> subProducts = proDal.GetProductByWhereList($"WHERE tbl_Product.ID = '{id}'");
            Dictionary<string, List<string>> attributes = new Dictionary<string, List<string>>();

            if (subProducts != null)
            {
                foreach (ProductObject sub in subProducts)
                {
                    Dictionary<string, string> attribute = proDal.GetAttribute(sub);
                    if (attribute != null)
                    {
                        foreach (KeyValuePair<string, string> values in attribute)
                        {
                            if (attributes.ContainsKey(values.Key))
                            {
                                if (!attributes[values.Key].Contains(values.Value))
                                {
                                    attributes[values.Key].Add(values.Value);
                                }


                            }
                            else
                            {
                                attributes.Add(values.Key, new List<string>() { values.Value });
                            }
                        }
                    }


                }

            }
            return attributes;
        }

        protected void Button_addtocart_Click(object sender, EventArgs e)
        {
            

            HiddenField hdnID = (HiddenField)Page.Master.FindControl("Cart");

            OrderObject cart = (OrderObject)Session["Cart"];

            if (!string.IsNullOrWhiteSpace(hdnID.Value)) {
                

                cart = JsonConvert.DeserializeObject<OrderObject>(hdnID.Value);

            }


            var attribute1 = "IS NULL";
            var attribute2 = "IS NULL";
            var attribute3 = "IS NULL";
            var attribute4 = "IS NULL";

            if (!string.IsNullOrWhiteSpace(atr1.SelectedValue)) { attribute1 = $"= '{atr1.SelectedValue}'"; }
            if (!string.IsNullOrWhiteSpace(atr2.SelectedValue)) { attribute2 = $"= '{atr2.SelectedValue}'"; }
            if (!string.IsNullOrWhiteSpace(atr3.SelectedValue)) { attribute3 = $"= '{atr3.SelectedValue}'"; }
            if (!string.IsNullOrWhiteSpace(atr4.SelectedValue)) { attribute4 = $"= '{atr4.SelectedValue}'"; }

            List<ProductObject> prod = proDal.GetProductByWhereList($@"WHERE tbl_Product.ID = '{int.Parse(Request.QueryString["id"])}' AND (AttributeID1 {attribute1} OR AttributeID2 {attribute1} OR AttributeID3 {attribute1} OR AttributeID4 {attribute1})
             AND (AttributeID1 {attribute2} OR AttributeID2 {attribute2} OR AttributeID3 {attribute2} OR AttributeID4 {attribute2})
             AND (AttributeID1 {attribute3} OR AttributeID2 {attribute3} OR AttributeID3 {attribute3} OR AttributeID4 {attribute3})
             AND (AttributeID1 {attribute4} OR AttributeID2 {attribute4} OR AttributeID3 {attribute4} OR AttributeID4 {attribute4})");


            

            foreach (ProductObject prud in prod)
            {
                bool inCart = false;
                int quantity = 0;
                if (cart.products != null) { 
                foreach (ProductObject cartProduct in cart.products)
                {
                        
                    if (cartProduct.ID == prud.ID) {
                            quantity = cartProduct.quantity + int.Parse(ant.Text);
                            inCart = true;
                            cartProduct.quantity = quantity;
                        }
                    
                }
                }

                if (!inCart) { 
                prud.quantity = int.Parse(ant.Text);
                cart.AddProduct(prud);
                } 
            }

            cart.priceGroup = pricegroup;
            cart.sum = cart.CalculatePrice();

            Session["Cart"] = cart;
            var JsonObj = JsonConvert.SerializeObject(cart);

            hdnID.Value = JsonObj;



            (this.Master as SiteMaster).BuildCart();
        }


    }
}