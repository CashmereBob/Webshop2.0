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
        List<CarrierObject> carriers;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUserTextboxVisible();
            // OrderObject orderObject = Session["Cart"] as OrderObject;
            OrderObject orderObject = order.GetOrder(1);
            //UserObject user = orderObject.usr;
            UserObject user = users.GetUserById(3);
            carriers = carrier.GetAllCarriers();
            FillCarrierInfo();
            FillUserInfo(user);
            FillOrderInfo(order);
        }

        private void FillCarrierInfo()
        {
 
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


                //Add TableCells CarrierName
                TableCell tc1 = new TableCell();
                tc1.CssClass = "tc";
                tc1.ID = "tc_" + item.carrierId+item.carrier;
                tr.Controls.Add(tc1);


                //Add Lable CarrierName
                Label lb = new Label();
                lb.ID = "lb_" + item.carrierId+item.carrier;
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
                lb_Price.Text = item.price.ToString("#.##")+"kr";
                tc_Price.Controls.Add(lb_Price);

            }

        }

        private void FillOrderInfo(Order order)
        {
           
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
        private void SetUserTextboxVisible()
        {
            TextBox_FirstNameValue.Visible = false;
            TextBox_LastNameValue.Visible = false;
            TextBox_EmailValue.Visible = false;
        }
    }
}