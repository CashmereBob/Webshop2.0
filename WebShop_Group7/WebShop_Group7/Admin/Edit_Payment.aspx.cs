using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.Admin
{
    public partial class Edit_Payment : System.Web.UI.Page
    {
        Payment payDal = new Payment();
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
                    EditPayment(int.Parse(Request.QueryString["id"]));
                }
            }
            else
            {
                CheckBox_delete.Visible = false;
                Label_delete.Visible = false;
            }
        }

        protected void EditPayment(int id)
        {
            PaymentObject payment = payDal.GetPaymentById(id);

            TextBox_payment.Text = payment.payment;
            TextBox_Service.Text = payment.service;
            TextBox_price.Text = payment.price.ToString("#.##");
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            if (CheckBox_delete.Checked == true)
            {
                payDal.DeletePayment(int.Parse(Request.QueryString["id"]));
                Response.Redirect("~/Admin/List_Payment.aspx");
            }

            if (Request.QueryString["id"] == null)
            {
                AddNewPayment();
            }
            else
            {
                UpdatePayment(int.Parse(Request.QueryString["id"]));
            }
        }

        protected void AddNewPayment()
        {
            PaymentObject payment = new PaymentObject();
            payment.payment = TextBox_payment.Text;
            payment.service = TextBox_Service.Text;
            payment.price = decimal.Parse(TextBox_price.Text);

            payDal.AddPayment(payment);
            Response.Redirect("~/Admin/List_Payment.aspx");
        }

        protected void UpdatePayment(int id)
        {
            PaymentObject payment = new PaymentObject();
            payment.payment = TextBox_payment.Text;
            payment.service = TextBox_Service.Text;
            payment.price = decimal.Parse(TextBox_price.Text);

            payDal.UppdatePayment(payment, id);
            Response.Redirect("~/Admin/List_Payment.aspx");

        }

    }
}