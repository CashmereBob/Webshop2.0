using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class Edit_Carrier : System.Web.UI.Page
    {
        Carrier carrDal = new Carrier();
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
                    EditCarrier(int.Parse(Request.QueryString["id"]));
                }
            }
            else
            {
                CheckBox_delete.Visible = false;
                Label_delete.Visible = false;
            }
        }

        protected void EditCarrier(int id)
        {
            CarrierObject carrier = carrDal.GetCarrierById(id);

            TextBox_carrier.Text = carrier.carrier;
            TextBox_Service.Text = carrier.service;
            TextBox_price.Text = carrier.price.ToString("#.##");

        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            if (CheckBox_delete.Checked == true)
            {
                carrDal.DeleteCarrier(int.Parse(Request.QueryString["id"]));
                Response.Redirect("~/Admin/List_Carrier.aspx");
            }

            if (Request.QueryString["id"] == null)
            {
                AddNewCarrier();
            }
            else
            {
                UpdateCarrier(int.Parse(Request.QueryString["id"]));
            }
        }

        protected void AddNewCarrier()
        {
            CarrierObject carrier = new CarrierObject();
            carrier.carrier = TextBox_carrier.Text;
            carrier.service = TextBox_Service.Text;
            carrier.price = decimal.Parse(TextBox_price.Text);

                carrDal.AddCarrier(carrier);
                Response.Redirect("~/Admin/List_Carrier.aspx");
            }
        protected void UpdateCarrier(int id)
        {
            CarrierObject carrier = new CarrierObject();
            carrier.carrier = TextBox_carrier.Text;
            carrier.service = TextBox_Service.Text;
            carrier.price = decimal.Parse(TextBox_price.Text);

            carrDal.UppdateCarier(carrier, id);
            Response.Redirect("~/Admin/List_Carrier.aspx");
            }
        }
        
    }
