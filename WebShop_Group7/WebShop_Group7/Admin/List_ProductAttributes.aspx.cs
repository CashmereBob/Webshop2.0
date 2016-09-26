using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class List_ProductAttributes : System.Web.UI.Page
    {
        ProductObejct product = new ProductObejct();
        ProductObject proObc;
        int ProductID;
        //List<string> brandNames;
        //List<string> categoryNames;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            //{
            //    Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            //}    

            ProductID = int.Parse(Request.QueryString["id"]);
            GetProduct();
            DataTable dt = product.GetListProductAttributes(ProductID);
            ViewState["dt"] = dt;
            BindGrid();
            SetValues();
         
        }
        protected void Button_Save_Click(object sender, EventArgs e)
        {
          
            if (!string.IsNullOrWhiteSpace(TextBox_ProductName.Text)) { proObc.name = TextBox_ProductName.Text; }
            if (!string.IsNullOrWhiteSpace(TextBox_Brand.Text)) { proObc.brandName = TextBox_Brand.Text; }
            if (!string.IsNullOrWhiteSpace(TextBox_Category.Text)) { proObc.category = TextBox_Category.Text; }
            if (!string.IsNullOrWhiteSpace(TextBox_ImgUrl.Text)) { proObc.imgURL = TextBox_ImgUrl.Text; }
            if (!string.IsNullOrWhiteSpace(TextBox_ProductNewDescription.Text)) { proObc.description = TextBox_ProductNewDescription.Text; }

            product.SaveProduct_AttributeChanges(proObc);
            GetProduct();
            CLearTextBoxes();
            DataTable dt = product.GetListProductAttributes(ProductID);
            ViewState["dt"] = dt;
            BindGrid();
            SetValues();
        }
        //protected void itemSelected(object sender, EventArgs e)
        //{
        //    Response.Write("HELLO!!");
        //        if (DropDownList_Category.SelectedItem.Text != "Select") { proObc.category = DropDownList_Category.SelectedItem.Text; }
        //    if (DropDownList_Brand.SelectedValue != "Select") { proObc.brandName = DropDownList_Brand.SelectedValue; }
        //}

        private void CLearTextBoxes()
        {
            TextBox_ImgUrl.Text = "";
            TextBox_ProductName.Text = "";        
            TextBox_ProductNewDescription.Text = "";
            TextBox_Brand.Text = "";
            TextBox_Category.Text = "";
        }

        private void SetValues()
        {
            Label_ProductName.Text = proObc.name;
            Label_ProductCategory.Text = proObc.category;
            Label_ProductBrand.Text = proObc.brandName;
            Label_imgURL.Text = proObc.imgURL;
            TextBox_ProductDescription.Text = proObc.description;
           
        }
        private void GetProduct()
        {
            proObc = product.GetMainProduct(ProductID);
            proObc.productID = ProductID;
        }
        //private void FillDroppdownListBrandName()
        //{
        //    brandNames = product.GetDroppdownNames("tbl_Brand");
            
        //    DropDownList_Brand.DataSource = from i in brandNames
        //                                    select new ListItem()
        //                                    {
        //                                        Text = i,
        //                                        Value = i
        //                                    };
        //    DropDownList_Brand.DataBind();
            

        //}
        //private void FillDropDownList_CategoryName()
        //{
        //    categoryNames = product.GetDroppdownNames("tbl_Category");
        //    DropDownList_Category.DataSource = from i in categoryNames
        //                                       select new ListItem()
        //                                       {
        //                                           Text = i,
        //                                           Value = i
        //                                       };
        //    DropDownList_Category.DataBind();      
        //}
        protected void BindGrid()
        {
            GridView_Products.DataSource = ViewState["dt"] as DataTable;
            GridView_Products.DataBind();

        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            var ID = row.Cells[0].Text; // Lägger Värdet från första raden i ID
            Response.Redirect($"~/Admin/Edit_Product.aspx?id={ID}");//SKickar med variablen ID till Edit
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/New_Product.aspx");
        }
    }
}