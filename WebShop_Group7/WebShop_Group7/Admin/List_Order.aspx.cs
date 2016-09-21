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
            GridView_Order.DataSource = ViewState["dt"] as DataTable;
            GridView_Order.DataBind();
        }

        protected void Button_Search_Click(object sender, EventArgs e)
        {
           
        }

        
    }
}