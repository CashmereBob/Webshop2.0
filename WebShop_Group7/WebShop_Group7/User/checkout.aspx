<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="WebShop_Group7.User.checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
     <h3>Kunduppgifter</h3>
    <div class="row">
        <div class="col-sm-4">
     <h4><asp:Label ID="Label_company" runat="server" Text="Företag"></asp:Label></h4><asp:TextBox ID="TextBox_company" runat="server" CssClass="form-control"></asp:TextBox>
      <h4><asp:Label ID="Label_firstname" runat="server" Text="Förnamn"></asp:Label></h4><asp:TextBox ID="TextBox_firstname" runat="server" CssClass="form-control"></asp:TextBox>
          <h4><asp:Label ID="Label_lastname" runat="server" Text="Efternamn"></asp:Label></h4><asp:TextBox ID="TextBox_lastname" runat="server" CssClass="form-control"></asp:TextBox>
      </div>
     <div class="col-sm-4">
            <h4><asp:Label ID="Label_adress" runat="server" Text="Adress"></asp:Label></h4><asp:TextBox ID="TextBox_adress" runat="server" CssClass="form-control"></asp:TextBox>
      <h4><asp:Label ID="Label_postalcode" runat="server" Text="Postnr"></asp:Label></h4><asp:TextBox ID="TextBox_postalcode" runat="server" CssClass="form-control"></asp:TextBox> 
          <h4><asp:Label ID="Label_city" runat="server" Text="Stad"></asp:Label></h4><asp:TextBox ID="TextBox_city" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
     <div class="col-sm-4">
     <h4><asp:Label ID="Label_email" runat="server" Text="E-post"></asp:Label></h4><asp:TextBox ID="TextBox_email" runat="server" CssClass="form-control"></asp:TextBox>
     <h4><asp:Label ID="Label_telephone" runat="server" Text="Telefon"></asp:Label></h4><asp:TextBox ID="TextBox_telephone" runat="server" CssClass="form-control"></asp:TextBox>
     <h4><asp:Label ID="Label_mobile" runat="server" Text="Mobiltelefon"></asp:Label></h4><asp:TextBox ID="TextBox_mobile" runat="server" CssClass="form-control"></asp:TextBox>
   </div>
          </div>
     <h3>Produkter</h3>
    <div class="row">
    <div id="products" class="col-xs-12" runat="server"></div>
     </div>

    <div class="row">
        <div class="col-sm-4">
     <div id="paymentDiv" runat="server"></div>
            </div>
        <div class="col-sm-4">
    <div id="carrierDiv" runat="server"></div>
            </div>
        <div class="col-sm-4 text-right">
    <div id="summary" class="text-right">
       <h3>Summering</h3>
       <h4>Total summa: <span id="total"></span></h4>
       <h5><i>Var av moms: <span id="tax"></span></i></h5>
    </div>
    <p><asp:Button ID="Button1" runat="server" Text="Uppdatera" CssClass="btn btn-primary" OnClick="UpdateCart" /> <asp:Button ID="Button_confirm" runat="server" Text="Slutför beställning" OnClick="Button_confirm_Click" OnClientClick="getPayCar();" UseSubmitBehavior="false" CssClass="btn btn-success" /></p>
    </div></div>
        </asp:Content>
