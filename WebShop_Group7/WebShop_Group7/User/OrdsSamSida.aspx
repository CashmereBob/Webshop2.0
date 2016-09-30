<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdsSamSida.aspx.cs" Inherits="WebShop_Group7.User.OrdsSamSida" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h1 class="col-xs-12">Köp klart</h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:Label ID="Label_thanx" runat="server" Text="Tack (User name) för ditt köp! vi skickar en orderbekräftelse till (User mail) "></asp:Label>

            </div>
        </div>
        <div class="row">
            <h3>Order ID :
                <asp:Label ID="Label_Orderid" runat="server" Text="Label"></asp:Label></h3>
        </div>
        <%-- User --%>
        <div class="row">
            <h4>Person upgifter</h4>
        </div>
        <div class="row">
            <table class="col-xs-12">
                <tr>
                    <th>Förnamn</th>
                    <th>Efternamn</th>
                    <th>Email</th>
                    <th>Adress</th>
                    <th>Stad</th>
                    <th>Telefon</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label_Fnamn" runat="server" Text="FirstName"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_Lnamn" runat="server" Text="LastName"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_Email" runat="server" Text="Email"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_Phone" runat="server" Text="Phone"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_City" runat="server" Text="City"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_Adress" runat="server" Text="Adress"></asp:Label></td>


                </tr>
            </table>
        </div>
        <%-- Product Info --%>

        <div class="row">
            <h4>Produkt upgifter</h4>
        </div>

        <div class="row" id="productTable" runat="server">

        </div>

        <%-- Carrier --%>
        <div class="row">
            <h4>Leverantör upgifter</h4>
        </div>
        <div class="row">
            <table class="col-xs-12">
                <tr>
                    <th>Namn</th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th>Moms(kr)</th>
                    <th>Summa(kr)</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label_CarrierName" runat="server" Text="Label">Carrier Name</asp:Label></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Label ID="Label_CarrierMoms" runat="server" Text="Label">0,00</asp:Label></td>
                    <td>
                        <asp:Label ID="Label_CarrierPrice" runat="server" Text="Label">0,00</asp:Label></td>
                </tr>
            </table>
        </div>
        <%-- Payment --%>
        <div class="row">
            <h4>Betlnings upgifter</h4>
        </div>
        <div class="row">
            <table class="col-xs-12">
                <tr>
                    <th>Namn</th>
                    <th></th>
                    <th></th>
                    <th>Typ</th>
                    <th>Moms(kr)</th>
                    <th>Summa(kr)</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label_PayName" runat="server" Text="Pay name"></asp:Label></td>
                    <td></td>
                    <td>
                        <asp:Label ID="Label_PayType" runat="server" Text="Pay type"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_PayMoms" runat="server" Text="0,0"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label_PayPrice" runat="server" Text="0,0"></asp:Label></td>
                </tr>
            </table>
        </div>
        <%-- Total --%>
        <div class="row">
            <h4>Sammanställning</h4>
        </div>
        <div class="row">
            <table class="align-right col-md-6">
                <tr>
                    <th></th>
                    <th>Moms(kr)</th>
                    <th>Summa(kr)</th>
                </tr>
                <tr>
                    <td>Bettlaing</td>
                    <td>0</td>
                    <td>0</td>
                </tr>
                <tr>
                    <td>Frakt</td>
                    <td>0</td>
                    <td>0</td>
                </tr>
                <tr>
                    <td>Produkt</td>
                    <td>0</td>
                    <td>0</td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ForeColor="Black"  Font-Bold="true"  ID="Label1" runat="server" Text="Total"></asp:Label></th>
                    <th>
                        <asp:Label ID="Label_totalMoms" ForeColor="Black"  Font-Bold="true" runat="server" Text="Label"></asp:Label></th>
                    <th>
                        <asp:Label ID="Label_totalPrice" ForeColor="Black" runat="server" Font-Bold="true" Text="Label"></asp:Label></th>
                </tr>
            </table>
        </div>
        <%-- END --%>
    </div>
</asp:Content>
