using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
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

            string price = string.Empty;

            ProductObject product = proDal.GetProduct(id);

            Dictionary<string, List<string>> attributes = GetAllAtributes(id);

            head.InnerHtml = $"<h2>{product.name}</h2><h3>{product.brandName}</h3><h4>{product.category}</h4>";
            img.InnerHtml = $"<div class=\"thumbnail\"><img src = \"{product.imgURL}\" alt=\"{product.name}\" ></div>";

            StringBuilder str = new StringBuilder();

            str.Append($"<h3>Produktbeskrivning</h3><p>{product.description}</p>");

            str.Append($"<h4 class=\"text-right\">");

            if (attributes != null)
            {
                foreach (KeyValuePair<string, List<string>> atr in attributes)
                {
                    str.Append($" {atr.Key}: <select> ");

                    foreach (string value in atr.Value)
                    {
                        str.Append($" <option value=\"{proDal.GetAttributeID(atr.Key, value)}\">{value}</option> ");
                    }
                    str.Append("</select>");
                }
            }

            str.Append("</h4>");
            

            

            if (pricegroup == 1) { price = product.priceB2C.ToString("#,##"); }
            if (pricegroup == 2) { price = product.priceB2B.ToString("#,##"); }

            str.Append($"<h2 class=\"text-right\" >{price}kr</h2><p class=\"text-right\" ><i>moms: {(int.Parse(price) * 0.25)}kr</i></p>");
            str.Append($"<p class=\"text-right\"><a href =\"/product.aspx?id={id}\" class=\"btn btn-success\" role=\"button\">Lägg i varukorg</a></p>");



            description.InnerHtml = str.ToString();
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

    }
}