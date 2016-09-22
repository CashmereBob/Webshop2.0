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
    public partial class List_Payment : System.Web.UI.Page
    {
        Payment pay = new Payment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            {
                Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            }


            DataTable dt = pay.ListAllPayments();
            ViewState["dt"] = dt;
            this.BindGrid();

        }

        protected void BindGrid()
        {
            GridView_Payment.DataSource = ViewState["dt"] as DataTable;
            GridView_Payment.DataBind();
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_Payment.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            var ID = row.Cells[0].Text;
            Response.Redirect($"~/Admin/Edit_Payment.aspx?id={ID}");
        }
    }
}