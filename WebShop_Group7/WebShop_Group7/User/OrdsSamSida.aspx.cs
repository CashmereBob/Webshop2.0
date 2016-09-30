using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class OrdsSamSida : System.Web.UI.Page
    {
        OrderObject oO;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            oO = Session["Cart"] as OrderObject;
            //userObject = orderObject.usr;

            FillValues();
        }

        private void FillValues()
        {
            Label_Orderid.Text = oO.orderId.ToString();
            Label_thanx.Text = $"Tack {oO.usr.firstName} {oO.usr.lastName} för ditt köp!"+Environment.NewLine+
                                $"Vi skickar en orderbekräftelse till {oO.usr.email})";

            //User
            Label_Fnamn.Text = oO.usr.firstName;
            Label_Lnamn.Text = oO.usr.lastName;
            Label_Email.Text = oO.usr.email;
            Label_City.Text = oO.usr.city;
            Label_Adress.Text = oO.usr.adress + " " + oO.usr.postalCode;
            Label_Phone.Text = oO.usr.telephone;
            //Products           
            //Carrier
            Label_CarrierName.Text = oO.carrier;
            Label_CarrierPrice.Text = oO.carrierPrice.ToString("#.##");
            Label_CarrierMoms.Text = (decimal.Multiply(oO.carrierPrice, (decimal)0.2)).ToString("#.##");
            //Payment
            Label_PayName.Text = oO.payment;
            Label_PayPrice.Text = oO.paymentPrice.ToString("#.##");
            Label_PayType.Text = oO.paymentService;
            Label_PayMoms.Text = (decimal.Multiply(oO.paymentPrice, (decimal)0.2)).ToString("#.##");

        }
    }
}