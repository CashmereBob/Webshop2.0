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

        decimal low = 0;
        decimal high = 0;
        int pricegroup = 1;


        Product prudDal = new Product();
        Users usrDal = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var where = string.Empty;

                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    where = $"WHERE tbl_Category.ID = '{Request.QueryString["id"]}'";
                }

                List<ProductObject> products = prudDal.GetProductByWhereList(where);

                AddCategorys(products);

            }


            GetProducts();


        }

        private void GetProducts()
        {
            List<string> vals = null;
            decimal valueOne = low;
            decimal valueTwo = high;

            if (!string.IsNullOrWhiteSpace(Request.QueryString["value"]))
            {
                vals = new List<string>();
                vals = Request.QueryString["value"].Split(',').ToList();
                valueOne = int.Parse(vals[0]);
                valueTwo = int.Parse(vals[1]);
            }


            if (!string.IsNullOrWhiteSpace(Request.QueryString["filter"]))
            {
                AddProductsAttribute((int)valueOne, (int)valueTwo);
            } else
            {
                AddProductValue((int)valueOne, (int)valueTwo);
            }


        }

        public void AddCategorys(List<ProductObject> products)
        {


            Dictionary<string, List<string>> attributes = new Dictionary<string, List<string>>();
            try
            {
                foreach (ProductObject product in products)
                {

                    Dictionary<string, string> attribute = prudDal.GetAttribute(product);
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

                foreach (KeyValuePair<string, List<string>> value in attributes)
                {
                    filternav.InnerHtml += $"<li class=\"sidebar-brand\">{value.Key}</li>";

                    foreach (string atr in value.Value)
                    {
                        filternav.InnerHtml += $"<li><input type=\"checkbox\" class=\"filter\" name=\"{atr}\" value =\"{prudDal.GetAttributeID(value.Key, atr)}\"> {atr}</li>";



                    }

                }
            }
            catch { }



            filternav.InnerHtml += $"<li class=\"sidebar-brand\">Prisintervall</li>";

            UserObject usr = null;
            if (Session["User"] != null)
            {
                usr = usrDal.GetUserById((int)Session["User"]);
            }

            if (usr != null)
            {
                pricegroup = usr.priceGroup;
            }

            try
            {
                foreach (ProductObject product in products)
                {

                    if (pricegroup == 1)
                    {
                        if (product.priceB2C < low || low == 0) { low = product.priceB2C; }
                        if (product.priceB2C > high) { high = product.priceB2C; }
                    }
                    if (pricegroup == 2)
                    {
                        if (product.priceB2B < low || low == 0) { low = product.priceB2B; }
                        if (product.priceB2B > high) { high = product.priceB2B; }
                    }


                }
            }
            catch { }

            List<string> str = null;
            decimal valueOne = low;
            decimal valueTwo = high;

            if (!string.IsNullOrWhiteSpace(Request.QueryString["value"]))
            {
                str = new List<string>();
                str = Request.QueryString["value"].Split(',').ToList();
                valueOne = int.Parse(str[0]);
                valueTwo = int.Parse(str[1]);
            }




            filternav.InnerHtml += $"<li><input id=\"ex2\" type=\"text\" class=\"span2\" value=\"\" data-slider-min=\"{(int)low}\" data-slider-max=\"{(int)high}\" data-slider-step=\"5\" data-slider-value=\"[{(int)valueOne}, {(int)valueTwo}]\" /></ li>";

        }

        public void AddProductsAttribute(int lowerValue, int higherValue)
        {
            List<int> attributes = new List<int>();
            List<ProductObject> products = new List<ProductObject>();
            List<string> param = Request.QueryString["filter"].Split(':').ToList();


            foreach (string value in param)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    attributes.Add(int.Parse(value));
                }
            }


            foreach (int atr in attributes)
            {
                StringBuilder str = new StringBuilder();

                str.Append($"WHERE (tbl_Product_Attribute.AttributeID1 = '{atr}' ");
                str.Append($"OR tbl_Product_Attribute.AttributeID2 = '{atr}' ");
                str.Append($"OR tbl_Product_Attribute.AttributeID3 = '{atr}' ");
                str.Append($"OR tbl_Product_Attribute.AttributeID3 = '{atr}') ");

                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    str.Append($"AND tbl_Category.ID = '{Request.QueryString["id"]}' ");
                }
                if (pricegroup == 1)
                {
                    str.Append($"AND tbl_Product_Attribute.PriceB2C >= '{lowerValue}' AND tbl_Product_Attribute.PriceB2C <= '{higherValue}' ");
                }
                if (pricegroup == 2)
                {
                    str.Append($"AND tbl_Product_Attribute.PriceB2B >= '{lowerValue}' AND tbl_Product_Attribute.PriceB2B <= '{higherValue}' ");
                }

                List<ProductObject> productsTEMP = prudDal.GetProductByWhereList(str.ToString());

                foreach (ProductObject prud in productsTEMP)
                {
                    products.Add(prud);
                }

            }

            DrawProducts(products);

        }

        public void AddProductValue(int lowerValue, int higherValue)
        {
            List<ProductObject> products = new List<ProductObject>();
            StringBuilder str = new StringBuilder();

            str.Append($"WHERE ");


            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                str.Append($"tbl_Category.ID = '{Request.QueryString["id"]}' ");
            }

            if (pricegroup == 1)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    str.Append($"AND tbl_Product_Attribute.PriceB2C >= '{lowerValue}' AND tbl_Product_Attribute.PriceB2C <= '{higherValue}' ");
                } else
                {
                    str.Append($"tbl_Product_Attribute.PriceB2C >= '{lowerValue}' AND tbl_Product_Attribute.PriceB2C <= '{higherValue}' ");
                }
            }
            if (pricegroup == 2)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    str.Append($"AND tbl_Product_Attribute.PriceB2B >= '{lowerValue}' AND tbl_Product_Attribute.PriceB2B <= '{higherValue}' ");
                }
                else
                {
                    str.Append($"tbl_Product_Attribute.PriceB2B >= '{lowerValue}' AND tbl_Product_Attribute.PriceB2B <= '{higherValue}' ");
                }
            }

            List<ProductObject> productsTEMP = prudDal.GetProductByWhereList(str.ToString());

            foreach (ProductObject prud in productsTEMP)
            {
                products.Add(prud);
            }

                DrawProducts(products);

        }

        public void DrawProducts(List<ProductObject> product)
        {
            List<ProductObject> newProduct = new List<ProductObject>();

            foreach (ProductObject prod in product) {
                if (newProduct.Count() == 0)
                {
                    newProduct.Add(prod);
                }
                else
                {
                    bool add = true;

                    foreach (ProductObject newProd in newProduct)
                    {
                        if (prod.productID == newProd.productID) { add = false; }
                    }

                    if (add)
                    {
                        newProduct.Add(prod);
                    }
                }
            }

            foreach (ProductObject prod in newProduct) {

                string price = string.Empty;

                if (pricegroup == 1) { price = prod.priceB2C.ToString("#,##"); }
                if (pricegroup == 2) { price = prod.priceB2B.ToString("#,##"); }

                productCont.InnerHtml += $"<div class=\"col-sm-6 col-md-4 col-lg-3\"> " +
                                        $"<div class=\"thumbnail\"> " +
                                          $"<img src = \"{prod.imgURL}\" alt=\"...\" > " +
                                          $"<div class=\"caption\" > " +
                                            $"<h3>{prod.name}</h3> " +
                                            $"<h4 class=\"green\" >{price} kr</h4>" + 
                                            $"<p>{prod.brandName}</p> " +
                                            $"<p><a href = \"#\" class=\"btn btn-primary\" role=\"button\" >Mer info</a></p> " +
                                          $"</div> " +
                                        $"</div> " +
                                      $"</div>";

            }
        }
    }
}
