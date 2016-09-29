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
            <div class="col-xs-12">
                <asp:Table ID="Table_OrderInfo" CssClass="table" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell><strong>Art. Nummer</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Artikel</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Attribut</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Pris (kr)</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Antal</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Summa (kr)</strong></asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
        <%-- Fraks bolag --%>

        <div class="row">
            <div class="col-xs-6">
                <h3>Fraktbolag</h3>
                <asp:Table ID="Table_Carriers" CssClass=" table" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell></asp:TableHeaderCell>
                        <asp:TableHeaderCell>Namn</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Pris</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
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

