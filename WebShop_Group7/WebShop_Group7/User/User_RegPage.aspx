<%@ Page Title="Register new user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_RegPage.aspx.cs" Inherits="WebShop_Group7.User.User_RegPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2><%: Title %>.</h2>
        <div class="jumbotron">
            <div class="row">
                <div class="col-md-5">
                    <h3>Kund uppgifter</h3>
                </div>
            </div>
            <%-- Förnamn --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Förnamn:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserFirstName" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Efternamn --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Efternamn:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserLastName" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Adress --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Adress:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserAdress" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Zip code --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Post nummer:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserZipCode" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- City --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Stad:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserCity" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Email --%>
            <%--<div class="row">--%>
                <div class="col-md-2">
                    <h4>Email:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserEmail" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Phone --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Telefon:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserPhone" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- MobilePhone --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>MobilTelefon:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserMobilePhone" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Företag --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Företag:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserCompay" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Password --%>

            <div class="row">
                <div class="col-md-2">
                    <h4>Password:</h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserPassword" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4>Password again:</h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_UserPasswordAgain" runat="server"></asp:TextBox>

                    <asp:Label ID="Lable_Passwordmatch" runat="server" Text=""></asp:Label>

                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button1" runat="server" Text="Registrera" OnClick="addNewUser" />
                </div>
            </div>

            <%-- END --%>
        </div>

    </div>


</asp:Content>
