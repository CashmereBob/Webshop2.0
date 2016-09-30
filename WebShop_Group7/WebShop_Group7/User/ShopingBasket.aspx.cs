using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebShop_Group7.Models;

namespace WebShop_Group7.User
{
    public partial class Varukorg : System.Web.UI.Page
    {
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
          if(Session["User"] != null)
            { 
            user = users.GetUserById(Convert.ToInt32(Session["User"]));
                userExists = true;
            }
          try { 
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
            bool check = false;
            foreach (var item in paymentObjects)
            {
                //Add TableRow

                TableRow tr = new TableRow();
                tr.ID = "tr_" + item.paymentId;
                Table_Payment.Controls.Add(tr);


                //1
                //Add tablrCellRadio
                TableCell tcR = new TableCell();
                tcR.ID = "tcr_" + item.paymentId;
                tr.Controls.Add(tcR);
                //RadioButton
                RadioButton radio = new RadioButton();
                radio.ID = "radio_" + item.paymentId;
                radio.GroupName = "Payment";
                tcR.Controls.Add(radio);
                radio.CheckedChanged += Radio_CheckedChanged;
                radioList.Add(radio);
                //2
                //Add TableCells Payment
                TableCell tc1 = new TableCell();
                tc1.CssClass = "tc";
                tc1.ID = "tc_" + item.paymentId + item;
                tr.Controls.Add(tc1);
                //Add Lable Payment
                Label lb = new Label();
                lb.ID = "lb_" + item.paymentId + item.payment;
                lb.Text = item.payment;
                tc1.Controls.Add(lb);

                //3
                //Add TableCells PaymentType
                TableCell tc2 = new TableCell();
                tc2.CssClass = "tc";
                tc2.ID = "tc2_" + item.paymentId + item;
                tr.Controls.Add(tc2);
                //Add Lable PaymentServise
                Label lbType = new Label();
                lbType.ID = "lbType" + item.paymentId + item.service;
                lbType.Text = item.service;
                tc2.Controls.Add(lbType);

                //4
                //Add TableCells Price
                TableCell tc_Price = new TableCell();
                tc_Price.CssClass = "tc";
                tc_Price.ID = "tc_" + item.paymentId + item.price;
                tr.Controls.Add(tc_Price);
                //Add Lable Price
                Label lb_Price = new Label();
                lb_Price.ID = "lb_" + item.paymentId + item.price;
                lb_Price.Text = item.price.ToString("#.##") + "kr";
                tc_Price.Controls.Add(lb_Price);

                if (!check)
                {
                    radio.Checked = true;
                    check = true;
                    payPrice = item.price;
                    payName = item.service;
                }
            }
        }

        private void FillCarrierInfo()
        {
            bool check = false;
            foreach (var item in carriers)
            {
                //Add TableRow

                TableRow tr = new TableRow();
                tr.ID = "tr_" + item.carrierId;
                Table_Carriers.Controls.Add(tr);



                //Add tablrCellRadio
                TableCell tcR = new TableCell();
                tcR.ID = "tcr_" + item.carrierId;
                tr.Controls.Add(tcR);

                //RadioButton
                RadioButton radio = new RadioButton();
                radio.ID = "radio_" + item.carrierId;
                radio.GroupName = "Carrier";
                tcR.Controls.Add(radio);
                radio.CheckedChanged += Radio_CheckedChanged;
                radioList.Add(radio);
                //Add TableCells CarrierName
                TableCell tc1 = new TableCell();
                tc1.CssClass = "tc";
                tc1.ID = "tc_" + item.carrierId + item.carrier;
                tr.Controls.Add(tc1);


                //Add Lable CarrierName
                Label lb = new Label();
                lb.ID = "lb_" + item.carrierId + item.carrier;
                lb.Text = item.carrier;
                tc1.Controls.Add(lb);

                //Add TableCells CarrierPrice
                TableCell tc_Price = new TableCell();
                tc_Price.CssClass = "tc";
                tc_Price.ID = "tc_" + item.carrierId + item.price;
                tr.Controls.Add(tc_Price);
                //Add Lable CarrierPrice
                Label lb_Price = new Label();
                lb_Price.ID = "lb_" + item.carrierId + item.price;
                lb_Price.Text = item.price.ToString("#.##") + "kr";
                tc_Price.Controls.Add(lb_Price);

                if (!check)
                {
                    radio.Checked = true;
                    check = true;
                    carrierPrice = item.price;
                    carrierName = item.carrier;
                }
            }

        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < radioList.Count; i++)
            {
                if (radioList[i].Checked)
                {

                    carrierPrice = 0;
                    Label_Total_CarrierPrice.Text = "Radio CheckedChanged";
                    return;
                }
            }
        }

        private void FillOrderInfo(Order order)
        {

            var OrderInfoList = order.GetProductsToList(orderObject);
            foreach (var item in OrderInfoList)
            {
                //Add TableRow
                TableRow tr = new TableRow();
                tr.ID = "tr_" + item.ID;
                Table_OrderInfo.Controls.Add(tr);
                ////////////////////////////////////////////////////////////
                //Add Cell Article
                TableCell tc_Article = new TableCell();
                tc_Article.ID = "tc_Article" + item.ID;
                tr.Controls.Add(tc_Article);

                //Add Lable Article
                Label lb_Article = new Label();
                lb_Article.ID = "lb_Article" + item.ID;
                lb_Article.Text = item.name;
                tc_Article.Controls.Add(lb_Article);
                ////////////////////////////////////////////////////////////
                //Add Cell Attribute
                TableCell tc_Attribute = new TableCell();
                tc_Attribute.ID = "tc_Attribute" + item.ID;
                tr.Controls.Add(tc_Attribute);

                //Add Attributes
                Label lb_Attribute = new Label();
                lb_Attribute.ID = "lb_Attribute" + item.ID;            
                lb_Attribute.Text = product.GetAttributes(item.ID) ;
                tc_Attribute.Controls.Add(lb_Attribute);
                ////////////////////////////////////////////////////////////
                //Add Cell Price
                TableCell tc_Price = new TableCell();
                tc_Price.ID = "tc_Price" + item.ID;
                tr.Controls.Add(tc_Price);

                //Add Price
                Label lb_Price = new Label();
                lb_Price.ID = "lb_Price" + item.ID;
                if (priceGroup == 1) { lb_Price.Text = item.priceB2C.ToString("#.##"); }
                else { lb_Price.Text = item.priceB2B.ToString("#.##") + "kr"; }
                tc_Price.Controls.Add(lb_Price);
                ////////////////////////////////////////////////////////////
                //Add Cell Quantity
                TableCell tc_Quantity = new TableCell();
                tc_Quantity.ID = "tc_Quantity" + item.ID;
                tr.Controls.Add(tc_Quantity);

                //Add Quantity
                Label lb_Quantity = new Label();
                lb_Quantity.ID = "lb_Quantity" + item.ID;
                lb_Quantity.Text = item.quantity.ToString();
                tc_Quantity.Controls.Add(lb_Quantity);
                ////////////////////////////////////////////////////////////
                //Add Cell Total
                TableCell tc_Total = new TableCell();
                tc_Total.ID = "tc_Total" + item.ID;
                tr.Controls.Add(tc_Total);

                //Add Total
                Label lb_Total = new Label();
                lb_Total.ID = "lb_Total" + item.ID;
                if (priceGroup == 1) { lb_Total.Text = (item.quantity * item.priceB2C).ToString("##.#"); totalOrderPrice += (item.quantity * item.priceB2C); }
                else { lb_Total.Text = (item.quantity * item.priceB2B).ToString("##.#"); totalOrderPrice += (item.quantity * item.priceB2B); }
                tc_Total.Controls.Add(lb_Total);

            }
            //Add row total
            TableRow tr2 = new TableRow();
            tr2.ID = "tr2";
            Table_OrderInfo.Controls.Add(tr2);
            //Add Cells

            TableCell tc2 = new TableCell(); tc2.ID = "tc2"; tr2.Controls.Add(tc2);
            TableCell tc3 = new TableCell(); tc3.ID = "tc3"; tr2.Controls.Add(tc3);
            TableCell tc4 = new TableCell(); tc4.ID = "tc4"; tr2.Controls.Add(tc4);
            TableCell tc5 = new TableCell(); tc5.ID = "tc5"; tr2.Controls.Add(tc5);
            TableCell tc6 = new TableCell(); tc6.ID = "tc6"; tr2.Controls.Add(tc6);

            Label Label_total = new Label();
            Label_total.ID = "Label_total";
            Label_total.Text = totalOrderPrice.ToString("#.##") + "kr";
            tc6.Controls.Add(Label_total);
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
            UserObject thisUser = new UserObject();
            if (userExists)
            {
                thisUser = user;
            }
            else
            {
                thisUser.firstName = TextBox_FirstNameValue.Text;
                thisUser.lastName = TextBox_LastNameValue.Text;
                thisUser.priceGroup = 1;
                thisUser.adress = TextBox_Adress.Text;
                thisUser.city = TextBox_City.Text;
                thisUser.postalCode = TextBox_Zip.Text;
                thisUser.telephone = TextBox_Phone.Text;
            }
            orderObject.usr = thisUser;

            Response.Redirect($"~/User/OrdsSamSida.aspx");
        }
    }
}