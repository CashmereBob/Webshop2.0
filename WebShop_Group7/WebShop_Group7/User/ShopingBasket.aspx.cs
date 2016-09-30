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
    public partial class Varukorg : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();
        Users users = new Users();
        Order order = new Order();
        Carrier carrier = new Carrier();
        Payment payment = new Payment();
        Product product = new Product();
        OrderObject orderObject;
        UserObject user;
        List<CarrierObject> carriers;
        List<PaymentObject> paymentObjects = new List<PaymentObject>();
        List<RadioButton> radioList = new List<RadioButton>();
        bool userExists = false;
        decimal totalOrderPrice = 0;
        decimal totalPrice = 0;
        decimal carrierPrice = 0;
        decimal payPrice = 0;
        string carrierName = "";
        string payName = "";
        int priceGroup;
        protected void Page_Load(object sender, EventArgs e)
        {

            SetUserTextboxVisible();
            orderObject = Session["Cart"] as OrderObject;
            // orderObject = order.GetOrder(1);
            if (Session["User"] != null)
            {
                user = users.GetUserById(Convert.ToInt32(Session["User"]));
                userExists = true;
            }
            try
            {
                priceGroup = user.priceGroup;
            }
            catch { }
            if (priceGroup != 2) { priceGroup = 1; }
            // user = users.GetUserById(3);
            carriers = carrier.GetAllCarriers();
            paymentObjects = payment.GetAllPayments();
            if (!IsPostBack)
            {
                FillCarrierInfo();
                FillUserInfo(user);
                FillOrderInfo(order);
                FillPayment();
                FillResultInfo();
            }
        }

        private void FillPayment()
        {
            sb.Clear();
            sb.Append("<table class=\"table table-striped\">");
            sb.Append(@"        
               <tr>
                   <th>Betalnings metod</th>
                   <th>Namn</th>
                   <th>Typ</th>
                   <th>Pris(kr)</th>               
               </tr>
          ");
            foreach (var item in paymentObjects)
            {
                sb.Append($@"     
               <tr>
                   <td>  
                    RadioButton
                   </td>
                   <td>{item.payment}</td>
                   <td>{item.service}</td>
                   <td>{item.price.ToString("#.##")}</td>          
               </tr> ");
            }
            sb.Append("</ table >");
            PaymentTable.InnerHtml = sb.ToString();
        }

        private void FillCarrierInfo()
        {
            sb.Clear();
            sb.Append("<table class=\"table table-striped\">");
            sb.Append(@"        
               <tr>
                   <th>Frakt</th>
                   <th>Namn</th>
                   <th>Pris(kr)</th>               
               </tr>
          ");
            foreach (var item in carriers)
            {
                sb.Append($@"     
               <tr>
                   <td>  
                    RadioButton
                   </td>
                   <td>{item.carrier}</td>
                   <td>{item.price.ToString("#.##")}</td>          
               </tr> ");
            }
            sb.Append("</ table >");
            CarrierTable.InnerHtml = sb.ToString();
        }

 

        private void FillOrderInfo(Order order)
        {
            sb.Clear();
            sb.Append("<table class=\"table table-striped\">");
            sb.Append(@"        
               <tr>
                   <th>Artikel</th>
                   <th>Attribut</th>
                   <th>Pris(kr)</th>
                   <th>Antal</th>
                   <th>Summa(kr)</th>
               </tr>
          ");


            decimal price = 0;
            var OrderInfoList = order.GetProductsToList(orderObject);
            foreach (var item in OrderInfoList)
            {


                try
                {
                    if (user.priceGroup == 2) { price = item.priceB2B; }
                    else { price = item.priceB2C; }
                }
                catch { price = item.priceB2C; }
                sb.Append($@"     
               <tr>
                   <td>{item.name}</td>
                   <td>{product.GetAttributes(item.ID)}</td>
                   <td>{price.ToString("#.##")}</td>
                   <td>{item.quantity}</td>
                   <td>{decimal.Multiply(price,(decimal)item.quantity).ToString("#.##")}</td>
               </tr> ");
            }

            sb.Append("</ table >");
            ProductTable.InnerHtml = sb.ToString();


        }
        private void FillUserInfo(UserObject user)
        {
            UserHeadingFirstName.InnerHtml = "<strong>Förnamn</strong>";
            UserHeadingLastName.InnerHtml = "<strong>Efternamn</strong>";
            UserHeadingEmail.InnerHtml = "<strong>Email</strong>";



            if (!userExists)
            {
                //User dont exists
                TextBox_FirstNameValue.Visible = true;
                TextBox_LastNameValue.Visible = true;
                TextBox_EmailValue.Visible = true;
                TextBox_Adress.Visible = true;
                TextBox_Zip.Visible = true;
                TextBox_City.Visible = true;
                TextBox_Phone.Visible = true;
            }
            else
            {
                FirstNameValue.InnerHtml = user.firstName;
                LastNameValue.InnerHtml = user.lastName;
                EmailValue.InnerHtml = user.email;
                Div_AdressValue.InnerText = user.adress;
                Div_ZipValue.InnerText = user.postalCode;
                Div_CityValue.InnerText = user.city;
                Div1_PhoneValue.InnerText = user.telephone;

                //User exists!
                if (user.priceGroup == 1)
                {
                    //B2C   

                }
                else
                {
                    //B2B
                    UserHeadingComany.InnerHtml = "<strong>Företag</strong>";
                    CompanyValue.InnerHtml = user.company;


                }
            }
        }

        private void FillResultInfo()
        {
            // Label_Total_PaymentMethod.Text = payName;
            Label_Total_PaymentPrice.Text = payPrice.ToString("#.##");

            totalPrice = totalOrderPrice + carrierPrice + payPrice;
            // Label_Total_Carrier.Text = carrierName;
            Label_Total_CarrierPrice.Text = carrierPrice.ToString("##.#");
            Label_ProductPrice.Text = totalOrderPrice.ToString("#.##");
            Label_TotalPrice.Text = totalPrice.ToString("#.##");
            Label_TotalMoms.Text = (decimal.Multiply(totalPrice, (decimal)0.2)).ToString("#.##");
        }
        private void SetUserTextboxVisible()
        {
            TextBox_FirstNameValue.Visible = false;
            TextBox_LastNameValue.Visible = false;
            TextBox_EmailValue.Visible = false;
            TextBox_Adress.Visible = false;
            TextBox_Zip.Visible = false;
            TextBox_City.Visible = false;
            TextBox_Phone.Visible = false;
        }

        protected void Button_Buy_Click(object sender, EventArgs e)
        {
            if (CheckBox_Accept.Checked)
            {
                UserObject thisUser = new UserObject();
                if (userExists)
                {
                    thisUser = user;

                }
                else
                {
                    thisUser.email = TextBox_EmailValue.Text;
                    thisUser.firstName = TextBox_FirstNameValue.Text;
                    thisUser.lastName = TextBox_LastNameValue.Text;
                    thisUser.priceGroup = 1;
                    thisUser.adress = TextBox_Adress.Text;
                    thisUser.city = TextBox_City.Text;
                    thisUser.postalCode = TextBox_Zip.Text;
                    thisUser.telephone = TextBox_Phone.Text;
                }
                orderObject.usr = thisUser;

                Response.Redirect($"~/User/OrdsSamSida.aspx?id=");
            }
            else
            {
                Label_CheckboxReq.Visible = true;
            }
        }
    }
}