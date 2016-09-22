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
    }
}