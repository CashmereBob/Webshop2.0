﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="WebShop_Group7.User.checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
     <h3>Kunduppgifter</h3>
     <h4><asp:Label ID="Label_company" runat="server" Text="company"></asp:Label><asp:TextBox ID="TextBox_company" runat="server"></asp:TextBox></h4>
      <h4><asp:Label ID="Label_firstname" runat="server" Text="firstname"></asp:Label><asp:TextBox ID="TextBox_firstname" runat="server"></asp:TextBox>
          <asp:Label ID="Label_lastname" runat="server" Text="lastnamename"></asp:Label><asp:TextBox ID="TextBox_lastname" runat="server"></asp:TextBox></h4>
      <h4><asp:Label ID="Label_adress" runat="server" Text="adress"></asp:Label><asp:TextBox ID="TextBox_adress" runat="server"></asp:TextBox></h4>
      <h4><asp:Label ID="Label_postalcode" runat="server" Text="postalcode"></asp:Label><asp:TextBox ID="TextBox_postalcode" runat="server"></asp:TextBox> 
          <asp:Label ID="Label_city" runat="server" Text="city"></asp:Label><asp:TextBox ID="TextBox_city" runat="server"></asp:TextBox></h4>
    
     </br>
     <h4><asp:Label ID="Label_email" runat="server" Text="email"></asp:Label><asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox></h4>
     <h4><asp:Label ID="Label_telephone" runat="server" Text="telephone"></asp:Label><asp:TextBox ID="TextBox_telephone" runat="server"></asp:TextBox></h4>
     <h4><asp:Label ID="Label_mobile" runat="server" Text="mobile"></asp:Label><asp:TextBox ID="TextBox_mobile" runat="server"></asp:TextBox></h4>

     <h3>Produkter</h3>
    <div id="products" runat="server"></div>
     

     <div id="paymentDiv" runat="server"></div>
    <div id="carrierDiv" runat="server"></div>
    <div id="summary"></div>
    <asp:Button ID="Button_confirm" runat="server" Text="Slutför beställning" OnClick="Button_confirm_Click" OnClientClick="getPayCar();" UseSubmitBehavior="false" />
    </asp:Content>
