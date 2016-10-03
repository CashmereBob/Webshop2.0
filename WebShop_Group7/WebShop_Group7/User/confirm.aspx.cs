using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class confirm : System.Web.UI.Page
    {
        Order ordDal = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {


            OrderObject order = (OrderObject)Session["Cart"];       
            order = ordDal.GetOrder(ordDal.AddOrder(order));
            SendMail(order);
            DataTable dt = ordDal.GetProducts(order);
            ViewState["dt"] = dt;
            this.BindGrid();

            Label_OrderID.Text = order.orderId.ToString();
            Label_firstname.Text = order.firstName;
            Label_lastname.Text = order.lastName;
            Label_company.Text = order.company;
            Label_adress.Text = order.adress;
            Label_postalcode.Text = order.postalCode;
            Label_city.Text = order.city;
            Label_Date.Text = order.date;

            Label_email.Text = order.email;
            Label_telephone.Text = order.telephone;
            Label_mobile.Text = order.mobile;

            Label_Carrier.Text = order.carrier;
            Label_carrierService.Text = order.carrierService;

            Label_Payment.Text = order.payment;
            Label_paymentService.Text = order.paymentService;

            Labe_CarrierPrice.Text = order.carrierPrice.ToString("#.##");
            Label_PaymentPrice.Text = order.paymentPrice.ToString("#.##");
            Label_Sum.Text = order.CalculatePrice().ToString("#.##");
            decimal tax = order.CalculatePrice() * 0.25M;
            Label_Tax.Text = tax.ToString("#.##");

            Session["Cart"] = new OrderObject();

            HiddenField hdnID = (HiddenField)Page.Master.FindControl("Cart");
            var JsonObj = JsonConvert.SerializeObject(Session["Cart"]);
            hdnID.Value = JsonObj;



        }
        protected void BindGrid()
        {
            GridViewOrder.DataSource = ViewState["dt"] as DataTable;
            GridViewOrder.DataBind();
        }
        protected void SendMail(OrderObject oO)
        {

            string OrderMail = $@"Dear {oO.firstName} {oO.lastName}! {Environment.NewLine}
                           “As we express our gratitude, we must never forget that the highest appreciation is not to utter words, but to live by them.”{Environment.NewLine}
                           –John F. Kennedy.{Environment.NewLine}{Environment.NewLine}
                           Order info
                           Order nummer: {oO.orderId}
                           Total Price: { oO.CalculatePrice().ToString("#.##")}{Environment.NewLine}
                           Best reguards from Group 7  
                           
                           
                           ";


            try
            {
                MailMessage o = new MailMessage("lundgren84@hotmail.se", $"{oO.email}", "Web-Shop Group7", $"{OrderMail}");
                NetworkCredential netCred = new NetworkCredential("lundgren84@hotmail.se", "olleolle12");
                SmtpClient smtpobj = new SmtpClient("smtp.live.com", 587);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;
                smtpobj.Send(o);
            }
            catch
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }

        }
    }
}