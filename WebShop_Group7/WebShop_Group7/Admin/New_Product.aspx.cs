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
            throw new NotImplementedException();
        }

        protected void Button_NewProductIMG_Click(object sender, EventArgs e)
        {
            Image_Product.ImageUrl = TextBox_ImgUlr.Text;
            Label_ImgUrl.Text = TextBox_ImgUlr.Text;
            TextBox_ImgUlr.Text = "";
        }
    }
}