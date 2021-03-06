﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="product.aspx.cs" Inherits="WebShop_Group7.product" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div id="head" class="col-xs-12" runat="server">
        </div>


    </div>

    <div class="row">
        <div id="img" class="col-xs-12 col-sm-6" runat="server">
        </div>
        <div id="description" class="col-xs-12 col-sm-6" runat="server">
            <h3>Productbeskrivning</h3>
            <p id="prodbesk" runat="server"></p>
            <div class="input-group">
                <span class="input-group-addon" id="atr1lable" runat="server">Attribut</span>
                <asp:DropDownList ID="atr1" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            </br>
            <div class="input-group">
                <span class="input-group-addon" id="atr2lable" runat="server">Attribut</span>
                <asp:DropDownList ID="atr2" CssClass="form-control" runat="server"></asp:DropDownList>

            </div>
            </br>
            <div class="input-group">
                <span class="input-group-addon" id="atr3lable" runat="server">Attribut</span>
                <asp:DropDownList ID="atr3" CssClass="form-control" runat="server"></asp:DropDownList>

            </div>
            </br>
            <div class="input-group">
                <span class="input-group-addon" id="atr4lable" runat="server">Attribut</span>
                <asp:DropDownList ID="atr4" CssClass="form-control" runat="server"></asp:DropDownList>

            </div>

            <h2 class="text-right"><span id="pris" runat="server"></span>kr</h2>
            <p class="text-right"><i>moms:<span id="moms" runat="server"></span>kr</i></p>

            <div class="input-group">
                
                <asp:TextBox ID="ant" TextMode="number" runat="server" CssClass="form-control" Text=1></asp:TextBox>
                <span class="input-group-addon" id="antallable" runat="server">Antal</span>
            </div>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Minimum 1" ControlToValidate="ant" MinimumValue="1" MaximumValue="99999"></asp:RangeValidator>
            
            </br>
            <p class="text-right">
                <asp:Button ID="Button_addtocart" runat="server" Text="Lägg i varukorg" cssClass="btn btn-success" OnClick="Button_addtocart_Click" /></p>
        </div>
    </div>

</asp:Content>
