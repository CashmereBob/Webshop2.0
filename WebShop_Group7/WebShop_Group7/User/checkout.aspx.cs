using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class checkout : System.Web.UI.Page
    {
        Users usrDal = new Users();
        Order orderDal = new Order();
        Carrier carDal = new Carrier();
        Payment payDal = new Payment();

        int pricegroup = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null && !IsPostBack)
            {
                FillInfo();
            }

            DrawProducts();
            Carriers();
            Payments();
        }

        protected void FillInfo()
        {
            UserObject user = usrDal.GetUserById((int)Session["User"]);

            TextBox_firstname.Text = user.firstName;
            TextBox_lastname.Text = user.lastName;
            TextBox_company.Text = user.company;
            TextBox_adress.Text = user.adress;
            TextBox_postalcode.Text = user.postalCode;
            TextBox_city.Text = user.city;
            TextBox_mobile.Text = user.mobile;
            TextBox_telephone.Text = user.telephone;
            TextBox_email.Text = user.email;
            pricegroup = user.priceGroup;

        }

        protected void DrawProducts()
        {
            Product pruDal = new Product();
            products.InnerHtml = @"<h4>Kundkorgen är tom</h4>";

            HiddenField hdnID = (HiddenField)Page.Master.FindControl("Cart");
            OrderObject cart = (OrderObject)Session["Cart"];
        

            if (!string.IsNullOrWhiteSpace(hdnID.Value))
            {

                cart = JsonConvert.DeserializeObject<OrderObject>(hdnID.Value);

                Session["Cart"] = cart;


            }


            List<ProductObject> deletes = new List<ProductObject>();

            cart.priceGroup = pricegroup;

            if (cart.products.Count > 0)
            {
                
                StringBuilder str = new StringBuilder();
                str.Append("<table class=\"table table-striped\">");
                str.Append(@"<tr>
                              <th>Art.nr</th>
                                <th>Artikel</th>
                                <th>Attribut</th>
                                <th>Pris</th>
                                <th>Antal</th>
                                <th>Summa</th>
                                <th></th>
                                </tr>");



                foreach (ProductObject product in cart.products)
                {
                    if (product.quantity > 0)
                    {
                        decimal price = product.priceB2C;
                        if (pricegroup != 1) { price = product.priceB2B; }

                        string atr = string.Empty;

                        Dictionary<string, string> atribbut = pruDal.GetAttribute(product);

                        if (atribbut != null)
                        {
                            foreach (KeyValuePair<string, string> val in atribbut)
                            {
                                atr += val.Value + ", ";
                            }
                        }

                        str.Append($@"<tr>
                              <td>{product.artNr}</td>
                                <td>{product.name}</td>
                                <td>{atr}</td>
                                <td>{price.ToString("#.##")}kr</td>
                                <td><input id='{product.ID}' class='quantity' style='width: 70px;' type='number' value='{product.quantity}' min='0'/></td>
                                <td>{(product.quantity * price).ToString("#.##")}kr</td>
                                <td><button id='{product.ID}' class='delete'><span class='glyphicon glyphicon-remove' aria-hidden='true'></span></button></td>
                                </tr>");
                    }
                    else
                    {
                        deletes.Add(product);
                    }
                }
                str.Append("</table>");
                products.InnerHtml = str.ToString();
            }

            foreach (ProductObject delete in deletes)
            {
                cart.products.Remove(delete);
            }

            cart.priceGroup = pricegroup;
            cart.sum = cart.CalculatePrice();

            Session["Cart"] = cart;
        }

        protected void Carriers()
        {
            List<CarrierObject> carriers = carDal.GetAllCarriers();

            StringBuilder str = new StringBuilder();

            str.Append("<h4>Fraktalternativ</h4>");
            foreach (CarrierObject carrier in carriers)
            {
                str.Append($@"<input class='carrm' type='radio' name='carrier' value='{carrier.carrierId}'>{carrier.service}: {carrier.price.ToString("#.##")}kr </br>");
            }

            carrierDiv.InnerHtml = str.ToString();
        }

        protected void Payments()
        {
            List<PaymentObject> payments = payDal.GetAllPayments();

            StringBuilder str = new StringBuilder();

            str.Append("<h4>Betalningsalternativ</h4>");
            foreach (PaymentObject payer in payments)
            {
                str.Append($@"<input class='paym' type='radio' name='payment' value='{payer.paymentId}'>{payer.service}: {payer.price.ToString("#.##")}kr </br>");
            }

            paymentDiv.InnerHtml = str.ToString();
        }

        protected void Button_confirm_Click(object sender, EventArgs e)
        {
            HiddenField hdnID = (HiddenField)Page.Master.FindControl("Cart");
            OrderObject order = (OrderObject)Session["Cart"];


            if (!string.IsNullOrWhiteSpace(hdnID.Value))
            {

                order = JsonConvert.DeserializeObject<OrderObject>(hdnID.Value);

                Session["Cart"] = order;


            }

            if (Session["User"] != null)
            {
                order.userID = (int)Session["User"];
            }



            order.firstName = TextBox_firstname.Text;
            order.lastName = TextBox_lastname.Text;
            order.company = TextBox_company.Text;
            order.adress = TextBox_adress.Text;
            order.postalCode = TextBox_postalcode.Text;
            order.city = TextBox_city.Text;
            order.mobile = TextBox_mobile.Text;
            order.telephone = TextBox_telephone.Text;
            order.email = TextBox_email.Text;

            order.priceGroup = pricegroup;
            order.sum = order.CalculatePrice();

            Session["Cart"] = order;

            Response.Redirect("~/User/confirm.aspx");

            
        }
    }
}