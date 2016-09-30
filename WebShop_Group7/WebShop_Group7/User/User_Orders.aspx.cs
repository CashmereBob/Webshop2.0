using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;
using System.Data;

namespace WebShop_Group7.User
{
    public partial class User_Orders : System.Web.UI.Page
    {
        Order ord = new Order();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/");
            }
            DataTable dt = ord.ListUserOrder(Convert.ToInt32(Session["User"]));
            ViewState["dt"] = dt;
            this.PrintGrid();
        }
        protected void PrintGrid()
        {
            GridViewOrder.DataSource = ViewState["dt"] as DataTable;
            GridViewOrder.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewOrder.EditIndex = e.NewEditIndex;
            this.PrintGrid();
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            var ID = row.Cells[0].Text;
            Response.Redirect($"~/Admin/Edit_Order.aspx?id={ID}");
        }
    }
}