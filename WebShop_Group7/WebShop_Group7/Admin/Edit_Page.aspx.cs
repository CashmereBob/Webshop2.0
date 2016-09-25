using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class Edit_Page : System.Web.UI.Page
    {
        Pages pageDal = new Pages();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Admin"] == null) //Kontrollerar om det finns en Admin session.
            {
                Response.Redirect("~/Admin/index.aspx"); //Om inte gå tillbaka till inloggning.
            }

            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    EditPage(int.Parse(Request.QueryString["id"]));
                }
            }
            else
            {
                CheckBox_delete.Visible = false;
                Label_delete.Visible = false;
            }
        }

        protected void EditPage(int id)
        {
            PageObject page = pageDal.GetPageById(id);

            TextBox_Name.Text = page.name;
            TextArea_Content.Text = page.content;

        }

       
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            if (CheckBox_delete.Checked == true)
            {
                pageDal.DeletePage(int.Parse(Request.QueryString["id"]));
                Response.Redirect("~/Admin/List_Pages.aspx");
            }

            if (Request.QueryString["id"] == null)
            {
                AddNewPage();
            }
            else
            {
                UpdatePage(int.Parse(Request.QueryString["id"]));
            }
        }

        private void UpdatePage(int id)
        {
            PageObject page = new PageObject();

            page.name = TextBox_Name.Text;
            page.content = TextArea_Content.Text;
           

            pageDal.UppdatePage(page, id);
            Response.Redirect("~/Admin/List_Pages.aspx");
        }

        private void AddNewPage()
        {
            PageObject page = new PageObject();

            page.name = TextBox_Name.Text;
            page.content = TextArea_Content.Text;

            pageDal.AddPage(page);
            Response.Redirect("~/Admin/List_Pages.aspx");
        }
    }
}