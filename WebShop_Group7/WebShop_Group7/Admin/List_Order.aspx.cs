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
    public partial class List_Order : System.Web.UI.Page
    {
        Order ord = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            {
                Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            }
                DataTable dt = ord.ListAllOrders();
                ViewState["dt"] = dt;
                this.BindGrid();
        }

        protected void BindGrid()
        {
            GridViewOrder.DataSource = ViewState["dt"] as DataTable;
            GridViewOrder.DataBind();
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
           
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewOrder.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string name = (row.Cells[0].Controls[0] as TextBox).Text;
            string country = (row.Cells[1].Controls[0] as TextBox).Text;
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows[row.RowIndex]["Name"] = name;
            dt.Rows[row.RowIndex]["Country"] = country;
            ViewState["dt"] = dt;
            GridViewOrder.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            GridViewOrder.EditIndex = -1;
            this.BindGrid();
        }
    }
}