﻿<%@ Page Title="New Product" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="New_Product.aspx.cs" Inherits="WebShop_Group7.Admin.New_Product" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2><%: Title %>.</h2>
        <div class="jumbotron">
     
            <div class="row">
                <%-- IMG --%>
                <div class="col-md-3">
                    <asp:Image CssClass="img-responsive img-rounded" ID="Image_Product" ImageUrl="http://lundgren84.com/KlädPlagg.jpg" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_NewProductIMG" runat="server" Text="Upload" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="Label_ImgUpload" runat="server" ForeColor="#CC0000"></asp:Label>
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
         
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_ProductName" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Artikelnummer --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Artikelnummer: </h4>
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
         
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Quantity" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Varumärke --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Varumärke: </h4>
                </div>
            
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Brand" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Kategori --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Kategori:  </h4>
                </div>
            
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Category" runat="server"></asp:TextBox>
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
                    <asp:TextBox ID="TextBox_Description" runat="server" ReadOnly="False" Height="100%" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </div>
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
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute1" runat="server" Text="Remove" />
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
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute2" runat="server" Text="Remove" />
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
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_RemoveAttribute3" runat="server" Text="Remove" /><br />
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
                        <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button1" runat="server" Text="Remove" /><br />
                    </div>
                </asp:Panel>
            </div>
            <%-- Spara ny egenskap --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Lägg till egenskap</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_AttributeCategory" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList CssClass="form-control" ID="DropDownList_Atribute" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_AddAttribute" runat="server" Text="Läggtill" />

                </div>
            </div>
            <%-- Save button --%>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_Save" runat="server" Text="Lägg till produkt"  />
                </div>
            </div>
        </div>
    </div>
    </asp:Content>