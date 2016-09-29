<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShopingBasket.aspx.cs" Inherits="WebShop_Group7.User.Varukorg" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Varukorg</h1>
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h3>Person uppgifter</h3>
            </div>
        </div>
        <%-- User Heading --%>
        <div class="row" runat="server" id="UserHeadings">
            <div class="col-md-3" runat="server" id="UserHeadingFirstName"></div>
            <div class="col-md-3" runat="server" id="UserHeadingLastName"></div>
            <div class="col-md-3" runat="server" id="UserHeadingEmail"></div>
            <div class="col-md-3" runat="server" id="UserHeadingComany"></div>
        </div>
        <%--User Values --%>
        <div class="row" runat="server" id="UserValues">
            <div class="col-md-3" runat="server" id="FirstNameValue">
                <asp:TextBox ID="TextBox_FirstNameValue" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" runat="server" id="LastNameValue">
                <asp:TextBox ID="TextBox_LastNameValue" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" runat="server" id="EmailValue">
                <asp:TextBox ID="TextBox_EmailValue" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" runat="server" id="CompanyValue">
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h3>Order info</h3>
            </div>
        </div>
        <%-- OrderInfo --%>
        <div class="row">
            <div class="col-md-3"><strong>Art. Nummer</strong></div>
              <div class="col-md-2"><strong>Artikel</strong></div>
              <div class="col-md-2"><strong>Attribut</strong></div>
             <div class="col-md-2"><strong>Pris (kr)</strong></div>
             <div class="col-md-1"><strong>Antal</strong></div>
             <div class="col-md-2"><strong>Summa (kr)</strong></div>


        </div>
        <%-- Fraks bolag --%>
        <div class="row">
            <div class="col-xs-12">
                <h3>Fraktbolag</h3>
                <asp:RadioButton ID="RadioButton1" runat="server" /><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

            </div>
        </div>
        <%-- Payment Info --%>
        <div class="row">
            <ul class="nav nav-tabs">
                <li role="presentation" class="active"><a href="#">Kort</a></li>
                <li role="presentation"><a href="#">Faktura</a></li>
                <li role="presentation"><a href="#">Bank Överföring</a></li>
            </ul>
        </div>
          <div class="row">
            <div class="col-xs-12">
                <asp:Label ID="Label1" runat="server" Text="Jag godkänner "></asp:Label><a>Köpvilkoren</a><asp:CheckBox ID="CheckBox1" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:Button ID="Button1" runat="server" Text="Köp" />
            </div>
        </div>
    </div>
</asp:Content>

