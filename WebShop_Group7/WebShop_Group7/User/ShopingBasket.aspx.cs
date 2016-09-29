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
        OrderObject orderObject;
        UserObject user;
        List<CarrierObject> carriers;
        List<RadioButton> radioList = new List<RadioButton>();
        decimal totalOrderPrice = 0;
        decimal totalPrice = 0;
        decimal carrierPrice = 0;
        decimal payPrice = 0;
        string carrierName = "";
        int priceGroup;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUserTextboxVisible();
            orderObject = Session["Cart"] as OrderObject;
           // orderObject = order.GetOrder(1);
            user = orderObject.usr;
            priceGroup = user.priceGroup;
            if(priceGroup != 2) { priceGroup = 1; }
           // user = users.GetUserById(3);
            carriers = carrier.GetAllCarriers();
            FillCarrierInfo();
            FillUserInfo(user);
            FillOrderInfo(order);
            FillResultInfo();
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
                    return;
                }
            }
        }

        private void UpdateTotalPrice()
        {
            throw new NotImplementedException();
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
                ////Add Cell Art. Nummer
                //TableCell tc_ArtN = new TableCell();
                //tc_ArtN.ID = "tc_ArtN" + item.ID;
                //tr.Controls.Add(tc_ArtN);

                ////Add Lable Art. Nummer
                //Label lb_ArtNr = new Label();
                //lb_ArtNr.ID = "lb_ArtNr" + item.ID;
                //lb_ArtNr.Text = item.artNr;
                //tc_ArtN.Controls.Add(lb_ArtNr);
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
                lb_Attribute.Text = "Attributes!";
                tc_Attribute.Controls.Add(lb_Attribute);
                ////////////////////////////////////////////////////////////
                //Add Cell Price
                TableCell tc_Price = new TableCell();
                tc_Price.ID = "tc_Price" + item.ID;
                tr.Controls.Add(tc_Price);

                //Add Price
                Label lb_Price = new Label();
                lb_Price.ID = "lb_Price" + item.ID;
                if (priceGroup == 1) { lb_Price.Text = item.priceB2C.ToString("#.##") + "kr"; }
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
                lb_Total.Text = (item.quantity * item.priceB2B).ToString("##.#");
                tc_Total.Controls.Add(lb_Total);
                totalOrderPrice += item.priceB2B * item.quantity;
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
            Label_total.Text = totalOrderPrice.ToString("#.##")+"kr";
            tc6.Controls.Add(Label_total);
        }
        private void FillUserInfo(UserObject user)
        {
            UserHeadingFirstName.InnerHtml = "<strong>Förnamn</strong>";
            UserHeadingLastName.InnerHtml = "<strong>Efternamn</strong>";
            UserHeadingEmail.InnerHtml = "<strong>Email</strong>";



            if (users.GetUserById(user.userId) == null)
            {
                //User dont exists
                TextBox_FirstNameValue.Visible = true;
                TextBox_LastNameValue.Visible = true;
                TextBox_EmailValue.Visible = true;

            }
            else
            {
                FirstNameValue.InnerHtml = user.firstName;
                LastNameValue.InnerHtml = user.lastName;
                EmailValue.InnerHtml = user.email;
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
            Label_Total_PaymentMethod.Text = "Payment";
            Label_Total_PaymentPrice.Text = "0,0";

            totalPrice = totalOrderPrice + carrierPrice + payPrice;
            Label_Total_Carrier.Text = carrierName;
            Label_Total_CarrierPrice.Text = carrierPrice.ToString("##.#");
            Label_ProductPrice.Text = totalOrderPrice.ToString("#.##");
            Label_TotalPrice.Text = totalPrice.ToString("#.##");
            Label_TotalMoms.Text = (decimal.Multiply(totalPrice,(decimal)0.2)).ToString("#.##");
        }
        private void SetUserTextboxVisible()
        {
            TextBox_FirstNameValue.Visible = false;
            TextBox_LastNameValue.Visible = false;
            TextBox_EmailValue.Visible = false;
        }
    }
}