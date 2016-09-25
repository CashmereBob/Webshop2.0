<%@ Page Title="Edite Product" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="Edit_Product.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Product" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2><%: Title %>.</h2>
        <div class="jumbotron">

            <div class="row">
                <div class="col-md-12">
                    <h4>Produktnamn:
                        <asp:Label ID="Label_ProductNameHeader" runat="server" Text=""></asp:Label>
                    </h4>
                </div>

            </div>
            <div class="row">
                <%-- IMG --%>
                <div class="col-md-3">
                    <asp:Image CssClass="img-responsive img-rounded" ID="Image_Product" ImageUrl="http://lundgren84.com/KlädPlagg.jpg" AlternateText="Product img" runat="server" />
                </div>
            </div>

            <%-- Produktuppgifter --%>
            <div class="row">
                <div class="col-md-2">
                    <h3>Produktuppgifter</h3>
                </div>
            </div>
            <%-- Produkt Namn --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Produktnamn:</h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="Label_ProductName" runat="server" Text="Produktnamn"></asp:Label>

                    </h4>
                </div>
                <%--      <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_ProductName" runat="server"></asp:TextBox>
                </div>--%>
            </div>
            <%-- Artikelnummer --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Artikelnummer: </h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="Label_ArticleNumber" runat="server" Text="000111222333"></asp:Label></h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox1_ArticleNumber" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Antal i lager --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Antal i lager:</h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="Label_Quantity" runat="server" Text="23"></asp:Label>st</h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Quantity" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Varumärke --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Varumärke: </h4>
                </div>
                <div class="col-md-2">
                    <h4>

                        <asp:Label ID="Label_Brand" runat="server" Text="Varumärke"></asp:Label></h4>

                </div>

            </div>
            <%-- Kategori --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Kategori:  </h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="Label_Category" runat="server" Text="Kategori"></asp:Label></h4>
                </div>

            </div>
            <%-- Pris b2b--%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Pris B2B:  </h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="Label_PriceB2B" runat="server" Text="0kr"></asp:Label></h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_PriceB2B" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Pris b2c--%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Pris B2C:  </h4>
                </div>
                <div class="col-md-2">
                    <h4>
                        <asp:Label ID="Label_PriceB2C" runat="server" Text="0kr"></asp:Label></h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_PriceB2C" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Beskrivning --%>
            <div class="row">
                <div class="col-md-2">
                    <h3>Beskrivning</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    <asp:TextBox ID="TextBox_Description" runat="server" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <%--    <div class="col-md-7">
                    <asp:TextBox ID="TextBox_Description" runat="server" ReadOnly="False" Height="100%" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </div>--%>
            </div>

            <%-- Egenskaper --%>
            <div class="row">
                <div class="col-md-2">
                    <h3>Egenskaper</h3>
                </div>
            </div>

            <%-- Egenskap1 --%>


            <div class="row">
                <asp:Panel ID="Panel_Attribute1" runat="server">
                    <div class="col-md-2">
                        <asp:Label ID="Label_Attribute1" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute1" runat="server" Text="Remove" OnClick="Button_RemoveAttribute1_Click" />
                    </div>
                </asp:Panel>
            </div>
            <%-- Egenskap2 --%>
            <div class="row">
                <asp:Panel ID="Panel_Attribute2" runat="server">
                    <div class="col-md-2">
                        <asp:Label ID="Label_Attribute2" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute2" runat="server" Text="Remove" OnClick="Button_RemoveAttribute2_Click" />
                    </div>
                </asp:Panel>
            </div>
            <%-- Egenskap3 --%>
            <div class="row">
                <asp:Panel ID="Panel_Attribute3" runat="server">
                    <div class="col-md-2">
                        <asp:Label ID="Label_Attribute3" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute3" runat="server" Text="Remove" OnClick="Button_RemoveAttribute3_Click" /><br />
                    </div>
                </asp:Panel>
            </div>
            <%-- Egenskap4 --%>
            <div class="row">
                <asp:Panel ID="Panel_Attribute4" runat="server">
                    <div class="col-md-2">
                        <asp:Label ID="Label_Attribute4" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute4" runat="server" Text="Remove" OnClick="Button_RemoveAttribute4_Click" /><br />
                    </div>
                </asp:Panel>
            </div>
            <%-- Spara ny egenskap --%>

            <asp:Panel ID="Panel_Add_Attributes" runat="server">
                <div class="row">
                    <div class="col-md-2">
                        <h4>Lägg till egenskap</h4>
                    </div>

                </div>
                <div class="row">

                    <%--      <div class="col-md-2">
                    <asp:DropDownList CssClass="form-control" ID="DropDownList_AttributeName" runat="server"></asp:DropDownList>
                </div>--%>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox_AttributeName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="TextBox_AttributeValue" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_AddAttribute" runat="server" Text="Läggtill" OnClick="Button_AddAttribute_Click" />

                    </div>
                </div>
            </asp:Panel>
            <%-- Save button --%>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_Save" runat="server" Text="Spara" OnClick="Button_Save_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
