using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;
using System.Net;
using Newtonsoft.Json;

namespace WebShop_Group7.User
{
    public partial class OrdsSamSida : System.Web.UI.Page
    {
        OrderObject oO;
        Product product = new Product();
        string OrderMail;
        decimal totalProductPrice = 0;
        decimal totalPayPrice = 0;
        decimal totalCarrierPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
       
            oO = Session["Cart"] as OrderObject;
            OrderMail = $@"Dear {oO.usr.firstName} {oO.usr.lastName}! {Environment.NewLine} Hope your prushase fill your needs.{Environment.NewLine}
                           Your order nummer is {oO.orderId}{Environment.NewLine}{Environment.NewLine}";
          
            FillValues();
            SendMail();
            ClearCart();

        }
        private void ClearCart()
        {
            HiddenField hdnID = (HiddenField)Page.Master.FindControl("Cart");
            Session["Cart"] = new OrderObject();
            var JsonObj = JsonConvert.SerializeObject(Session["Cart"]);
            hdnID.Value = JsonObj;
        }
        private void FillValues()
        {
            Label_Orderid.Text = oO.orderId.ToString();
            Label_thanx.Text = $"Tack {oO.usr.firstName} {oO.usr.lastName} för ditt köp!" + Environment.NewLine +
                                $"Vi skickar en orderbekräftelse till {oO.usr.email}";

            //User
            Label_Fnamn.Text = oO.usr.firstName;
            Label_Lnamn.Text = oO.usr.lastName;
            Label_Email.Text = oO.usr.email;
            Label_City.Text = oO.usr.city;
            Label_Adress.Text = oO.usr.adress + " " + oO.usr.postalCode;
            Label_Phone.Text = oO.usr.telephone;
            //Products   
            GetProductValues();
            //Carrier

            Label_CarrierName.Text = oO.carrier;
            Label_CarrierPrice.Text = oO.carrierPrice.ToString("#.##");
            Label_CarrierMoms.Text = (decimal.Multiply(oO.carrierPrice, (decimal)0.2)).ToString("#.##");
            //Payment
            Label_PayName.Text = oO.payment;
            Label_PayPrice.Text = oO.paymentPrice.ToString("#.##");
            Label_PayType.Text = oO.paymentService;
            Label_PayMoms.Text = (decimal.Multiply(oO.paymentPrice, (decimal)0.2)).ToString("#.##");
            //Result
            Label_totalPrice.Text = getFullPrice().ToString("#.##");
            Label_totalMoms.Text = decimal.Multiply(getFullPrice(), (decimal)0.2).ToString("#.##");
        }
        private void GetProductValues()
        {

            productTable.InnerHtml = "";
            productTable.InnerHtml +=
                     $"<table class=\"table col-xs-12\">   " +
                     $"<tr> " +
                     $"<th>Artikel<//th> " +
                     $"<th>Attribut<//th> " +
                     $"<th>Pris(kr)<//th> " +
                     $"<th>Antal<//th> " +
                     $"<th>Moms(kr)<//th> " +
                     $"<th>Summa(kr)<//th> " +
                     $"<//tr> ";

            OrderMail += $@"Your products{Environment.NewLine}";
            foreach (var item in oO.products)
            {
                decimal price = 0;
                if (oO.usr.priceGroup == 2) { price = item.priceB2B; }
                else { price = item.priceB2C; }
                productTable.InnerHtml +=

                     $"<tr> " +
                     $"<td>{item.name}</td> " +
                     $"<td>{product.GetAttributes(item.ID)}</td> " +
                     $"<td>{price}</td> " +
                     $"<td>{item.quantity}</td> " +
                     $"<td>{decimal.Multiply(price, (decimal)0.2).ToString("##.#")}</td> " +
                     $"<td>{price.ToString("#.##")}</td> " +
                     $"</tr>   ";
                totalProductPrice += price;
                OrderMail += $@"Name: {item.name} Attributes: {product.GetAttributes(item.ID)} Quantity: {item.quantity} Price: {price.ToString("#.##")}kr {Environment.NewLine}";
            }
            productTable.InnerHtml +=
                                 $"<tr> " +
                     $"<td></td> " +
                     $"<td></td> " +
                     $"<td></td> " +
                     $"<td><strong>Total:</strong></td> " +
                     $"<td><strong>{(decimal.Multiply(totalProductPrice, (decimal)0.2)).ToString("#.##") }</strong></td> " +
                     $"<td><strong>{totalProductPrice.ToString("#.##")}</strong></td> " +
                     $"</tr> " +
                     $"</table> ";
            OrderMail += $@" Total Product Price : {totalProductPrice.ToString("#.##")}kr  {Environment.NewLine}  {Environment.NewLine}";
            OrderMail += $@"Delivery price: {oO.carrierPrice.ToString("#.##")}kr{Environment.NewLine}   ";
            OrderMail += $@"Payment price: {oO.paymentPrice.ToString("#.##")}kr{Environment.NewLine}{Environment.NewLine}";
            OrderMail += $@"Total price: {getFullPrice().ToString("#.##")}kr {Environment.NewLine}{Environment.NewLine}Best regards WebShop Group 7";
        }
        private decimal getFullPrice()
        {
            decimal result = 0;
            totalCarrierPrice = oO.carrierPrice;
            totalPayPrice = oO.paymentPrice;
            result = totalProductPrice + totalPayPrice + totalCarrierPrice;
            return result;
        }
        protected void SendMail()
        {
            try
            {
                MailMessage o = new MailMessage("lundgren84@hotmail.se", $"{oO.usr.email}", "Web-Shop Group7", $"{OrderMail}");
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