using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7
{
    public partial class category : System.Web.UI.Page
    {
        Product prudDal = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = string.Empty;
            
            if (Request.QueryString["id"] != null)
            {
                where = $"WHERE tbl_Category.ID = '{Request.QueryString["id"]}'";
            }

            List<ProductObject> products = prudDal.GetProductByWhereList(where);

                AddCategorys(products);
                
            }

            if (Request.QueryString["filter"] != null) {
                GetProducts();
            }

        }

        private void GetProducts()
        {
            List<string> param = Request.QueryString["filter"].Split(':').ToList();
            List<int> attributes = new List<int>();

            foreach(string value in param)
            {
                if (!string.IsNullOrEmpty(value)) { 
                attributes.Add(int.Parse(value));
                }
            }

            List<ProductObject> products = new List<ProductObject>();

            StringBuilder str = new StringBuilder();
            foreach (int atr in attributes)
            {
                str.Append($"WHERE tbl_Product_Attribute.AttributeID1 = '{atr}' ");
                str.Append($"OR tbl_Product_Attribute.AttributeID2 = '{atr}' ");
                str.Append($"OR tbl_Product_Attribute.AttributeID3 = '{atr}' ");
                str.Append($"OR tbl_Product_Attribute.AttributeID3 = '{atr}' ");

                List<ProductObject> productsTEMP = prudDal.GetProductByWhereList(str.ToString());

                foreach (ProductObject prud in productsTEMP)
                {
                    products.Add(prud);
                }

            }

            foreach (ProductObject prod in products) {
                productCont.InnerHtml += " " + prod.name;
            }
        }

        public void AddCategorys(List<ProductObject> products)
        {
            Dictionary<string, List<string>> attributes = new Dictionary<string, List<string>>();

            foreach (ProductObject product in products) {

                Dictionary<string, string> attribute= prudDal.GetAttribute(product);
                foreach (KeyValuePair<string, string> values in attribute)
                {
                    if (attributes.ContainsKey(values.Key))
                    {
                        if (!attributes[values.Key].Contains(values.Value))
                        {
                            attributes[values.Key].Add(values.Value);
                        }


                    } else
                    {
                        attributes.Add(values.Key, new List<string>() { values.Value });
                    }
                }
            }

            foreach (KeyValuePair<string, List<string>> value in attributes) {
                filternav.InnerHtml += $"<li class=\"sidebar-brand\">{value.Key}</li>";

                foreach (string atr in value.Value)
                {
                    filternav.InnerHtml += $"<li><input type=\"checkbox\" class=\"filter\" name=\"{atr}\" value =\"{prudDal.GetAttributeID(value.Key, atr)}\"> {atr}</li>";



                }

            }

            


    }
    }
}