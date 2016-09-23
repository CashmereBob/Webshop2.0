using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{

    public partial class List_Products : System.Web.UI.Page
    {

        Product products;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            //{
            //    Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            //}
            products = new Product();
          
            DataTable dt = products.GetAllToDataTable();
            ViewState["dt"] = dt;
            BindGrid();
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
    }
}