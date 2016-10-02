using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            HiddenField hdnID = (HiddenField)Page.Master.FindControl("Cart");
            OrderObject order = (OrderObject)Session["Cart"];

            order = ordDal.GetOrder(ordDal.AddOrder(order));

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

            hdnID.Value = "";
            Session["Cart"] = new OrderObject();


        }
        protected void BindGrid()
        {
            GridViewOrder.DataSource = ViewState["dt"] as DataTable;
            GridViewOrder.DataBind();
        }
    }
}