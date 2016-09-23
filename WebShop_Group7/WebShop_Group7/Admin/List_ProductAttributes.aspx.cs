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
        Product products;
        int ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            //{
            //    Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            //}
            products = new Product();
            ProductID = int.Parse(Request.QueryString["id"]);
            DataTable dt = products.GetListProductAttributes(ProductID);
            ViewState["dt"] = dt;
            BindGrid();
            SetValues();
        }

        private void SetValues()
        {
            Label_ProductName.Text = products.GetAValue("tbl_Product", "Name", ProductID);
            Label_ProductCategory.Text = products.GetAValue("tbl_Category", "Name", ProductID);
            Label_ProductBrand.Text = products.GetAValue("tbl_Brand", "Name", ProductID);
            Label_ProductDescription.Text = products.GetAValue("tbl_Product", "Description", ProductID);
        }

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