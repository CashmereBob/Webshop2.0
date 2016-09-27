<%@ Page Title="User Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_Page.aspx.cs" Inherits="WebShop_Group7.User.User_page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Kunduppgifter</h2>

    <h4>Förnamn
    </h4>
    <asp:TextBox ID="TextBox_firstName" runat="server"></asp:TextBox>
    <h4>Efternamn
       
    </h4>
    <asp:TextBox ID="TextBox_lastName" runat="server"></asp:TextBox>
    <h4>Företag</h4>
    <asp:TextBox ID="TextBox_company" runat="server"></asp:TextBox>

    <h4>Adress
    </h4>
    <asp:TextBox ID="TextBox_adress" runat="server"></asp:TextBox>
    <h4>Postnummer
    </h4>
    <asp:TextBox ID="TextBox_postalCode" runat="server"></asp:TextBox>
    <h4>Stad
    </h4>
    <asp:TextBox ID="TextBox_city" runat="server"></asp:TextBox>
    
    <h3>Kontaktuppgifter</h3>

    <h4>Telefon</h4>
    <asp:TextBox ID="TextBox_phone" runat="server"></asp:TextBox>
    <h4>Mobil</h4>
    <asp:TextBox ID="TextBox_mobile" runat="server"></asp:TextBox>
    <h4>Mail</h4>
    <asp:TextBox ID="TextBox_mail" runat="server"></asp:TextBox>
    <h4>Lösenord</h4>
    <asp:TextBox ID="TextBox_password01" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox_password02" runat="server"></asp:TextBox>

    <asp:Label ID="Lable_Passwordmatch" runat="server" Text=""></asp:Label>

    <br />
    <asp:Button ID="Button_submitUser" runat="server" Text="Spara" OnClick="Button_submitUser_Click" />



</asp:Content>
