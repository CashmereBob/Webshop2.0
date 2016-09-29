<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShopingBasket.aspx.cs" Inherits="WebShop_Group7.User.Varukorg" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Varukorg</h1>
    <div class="container">

        <div class="row">
            <div class="col-xs-12">
                <h3>Person uppgifter</h3>
            </div>
        </div>
        <%-- ÉND --%>
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
         <div class="row" runat="server" id="Div1">
            <div class="col-md-3" runat="server" id="Div2"><strong>Adress</strong></div>
            <div class="col-md-3" runat="server" id="Div3"><strong>Zip</strong></div>
            <div class="col-md-3" runat="server" id="Div4"><strong>City</strong></div>
            <div class="col-md-3" runat="server" id="Div5"><strong>Phone</strong></div>
        </div>
            <div class="row" runat="server" id="Div6">
            <div class="col-md-3" runat="server" id="Div_AdressValue">
                <asp:TextBox ID="TextBox_Adress" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" runat="server" id="Div_ZipValue">
                <asp:TextBox ID="TextBox_Zip" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" runat="server" id="Div_CityValue">
                <asp:TextBox ID="TextBox_City" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
               <div class="col-md-3" runat="server" id="Div1_PhoneValue">
                <asp:TextBox ID="TextBox_Phone" CssClass="form-control" runat="server"></asp:TextBox>
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

                        <asp:TableHeaderCell><strong>Artikel</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Attribut</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Pris (kr)</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Antal</strong></asp:TableHeaderCell>
                        <asp:TableHeaderCell><strong>Summa (kr)</strong></asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
        <%-- Frakt bolag --%>

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
            <div class="col-xs-6">
                <h3>Betalnings metod</h3>
                  <asp:Table ID="Table_Payment" CssClass=" table" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell></asp:TableHeaderCell>
                        <asp:TableHeaderCell>Namn</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Pris</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
     
        <%-- Result info --%>

        <div class="row">
            <div class="col-xs-6">
                <h3>Total summa</h3>
                <asp:Table ID="Table1" CssClass=" table" runat="server">

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Betalning" runat="server" Text="Label"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label_Total_PaymentPrice" runat="server" Text="0,00"></asp:Label>kr
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Frakt" runat="server" Text="Label"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label_Total_CarrierPrice" runat="server" Text="0,00"></asp:Label>kr
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Produkt Summa </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="Label_ProductPrice" runat="server" Text="0,00"></asp:Label>kr
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><strong>Total Summa</strong> </asp:TableCell>
                        <asp:TableCell>
                            <strong>
                                <asp:Label ID="Label_TotalPrice" runat="server" Text="0,00"></asp:Label>
                                kr</strong>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><small>Var av moms:  </small></asp:TableCell>
                        <asp:TableCell>
                            <small>
                                <asp:Label ID="Label_TotalMoms" runat="server" Text="0,00"></asp:Label>
                                kr </small>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
        <%-- ÉND --%>
        <div class="row">
            <div class="col-xs-12">
                <asp:Label ID="Label1" runat="server" Text="Jag godkänner "></asp:Label><a>Köpvilkoren</a><asp:CheckBox ID="CheckBox1" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:Button ID="Button_Buy" runat="server" Text="Köp" OnClick="Button_Buy_Click" />
            </div>
        </div>

    </div>
</asp:Content>

