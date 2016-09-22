<%@ Page Title="Edit Order" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="Edit_Order.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Order" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2><%: Title %>.</h2>

     <h4><asp:Label ID="Label_OrderID" runat="server" Text="OrderID"></asp:Label></h4>
     <h3>Kunduppgifter</h3>
     <h4><asp:Label ID="Label_company" runat="server" Text="company"></asp:Label></h4>
      <h4><asp:Label ID="Label_firstname" runat="server" Text="firstname"></asp:Label> <asp:Label ID="Label_lastname" runat="server" Text="lastnamename"></asp:Label></h4>
      <h4><asp:Label ID="Label_adress" runat="server" Text="adress"></asp:Label></h4>
      <h4><asp:Label ID="Label_postalcode" runat="server" Text="postalcode"></asp:Label> <asp:Label ID="Label_city" runat="server" Text="city"></asp:Label></h4>
    
     </br>
     <h4><asp:Label ID="Label_email" runat="server" Text="email"></asp:Label></h4>
     <h4><asp:Label ID="Label_telephone" runat="server" Text="telephone"></asp:Label></h4>
     <h4><asp:Label ID="Label_mobile" runat="server" Text="mobile"></asp:Label></h4>

     <h3>Produkter</h3>
     <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="false"  CssClass="table-striped table list-group">

                    <Columns>

                        <asp:BoundField DataField="ArtNr" HeaderText="Art. Nummer"  />

                        <asp:BoundField DataField="Name" HeaderText="Produkt Namn" />

                        <asp:BoundField DataField="Price" HeaderText="Pris"  />

                    </Columns>

                </asp:GridView>
<asp:DataList ID="DataList_PruductsInOrder" runat="server">
</asp:DataList>
     <h3>Frakt</h3>
     <h4><asp:Label ID="Label_Carrier" runat="server" Text="Fraktmetod"></asp:Label> <asp:Label ID="Label_carrierService" runat="server" Text="Fraktmetod"></asp:Label></h4>
     <h3>Payment</h3>
     <h4><asp:Label ID="Label_Payment" runat="server" Text="Payment"></asp:Label> <asp:Label ID="Label_paymentService" runat="server" Text="Payment"></asp:Label></h4>
    
     <h3>Kostnader</h3>
     <h4>Frakt: <asp:Label ID="Labe_CarrierPrice" runat="server" Text="Frakt"></asp:Label></h4>
     <h4>Betalning: <asp:Label ID="Label_PaymentPrice" runat="server" Text="Betalt"></asp:Label></h4>
     <h4>Summa ink moms: <asp:Label ID="Label_Sum" runat="server" Text="Summa"></asp:Label></h4>
     <h4>Var av moms: <asp:Label ID="Label_Tax" runat="server" Text="moms"></asp:Label></h4>


     
</asp:Content>
