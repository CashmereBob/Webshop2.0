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
        Product product = new Product();

        decimal totalProductPrice = 0;
        decimal totalPayPrice = 0;
        decimal totalCarrierPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            oO = Session["Cart"] as OrderObject;
         

            FillValues();
        }

        private void FillValues()
        {
            Label_Orderid.Text = oO.orderId.ToString();
            Label_thanx.Text = $"Tack {oO.usr.firstName} {oO.usr.lastName} för ditt köp!"+Environment.NewLine+
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
            Label_totalMoms.Text = decimal.Multiply(getFullPrice(),(decimal)0.2).ToString("#.##");
        }

        private void GetProductValues()
        {
         
            productTable.InnerHtml = "";
            productTable.InnerHtml +=
                     $"<table class=\"table col-xs-12\">   " +
                     $"<tr> " +
                     $"<th>Artikel</th> " +
                     $"<th>Attribut</th> " +
                     $"<th>Pris(kr)</th> " +
                     $"<th>Antal</th> " +
                     $"<th>Moms(kr)</th> " +
                     $"<th>Summa(kr)</th> " +
                     $"</tr> ";
            foreach (var item in oO.products)
            {
                decimal price = 0;
                if (oO.usr.priceGroup== 2) { price = item.priceB2B; }
                else { price = item.priceB2C; }
                productTable.InnerHtml +=

                     $"<tr> " +
                     $"<td>{item.name}</td> " +
                     $"<td>{product.GetAttributes(item.ID)}</td> " +
                     $"<td>{price}</td> " +
                     $"<td>{item.quantity}</td> " +
                     $"<td>{decimal.Multiply(price,(decimal)0.2).ToString("##.#")}</td> " +
                     $"<td>{price.ToString("#.##")}</td> " +
                     $"</tr>   ";
                totalProductPrice += price;
            }
            productTable.InnerHtml += 
                                 $"<tr> " +
                     $"<td></td> " +
                     $"<td></td> " +
                     $"<td></td> " +
                     $"<td><strong>Total:</strong></td> " +
                     $"<td><strong>{(decimal.Multiply(totalProductPrice,(decimal)0.2)).ToString("#.##") }</strong></td> " +
                     $"<td><strong>{totalProductPrice.ToString("#.##")}</strong></td> " +
                     $"</tr> " +
                     $"</table> ";
        }
        private decimal getFullPrice()
        {
            decimal result = 0;
            result = totalProductPrice + totalPayPrice + totalCarrierPrice;
            return result;
        }
    }
}