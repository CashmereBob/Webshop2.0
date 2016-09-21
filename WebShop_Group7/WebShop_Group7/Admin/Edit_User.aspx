<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="Edit_User.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Kunduppgifter</h2>

    <h4>Förnamn<asp:TextBox ID="TextBox_firstName" runat="server"></asp:TextBox>
    </h4>
    <h4>Efternamn
        <asp:TextBox ID="TextBox_lastName" runat="server"></asp:TextBox>
    </h4>
    <h4>Företag<asp:TextBox ID="TextBox_company" runat="server"></asp:TextBox></h4>

    <h4>Adress<asp:TextBox ID="TextBox_adress" runat="server"></asp:TextBox>
    </h4>
    <h4>Postnummer<asp:TextBox ID="TextBox_postalCode" runat="server"></asp:TextBox>
    </h4>
    <h4>Stad<asp:TextBox ID="TextBox_city" runat="server"></asp:TextBox>
    </h4>
    <h3>Kontaktuppgifter</h3>
    <h4>Telefon<asp:TextBox ID="TextBox_phone" runat="server"></asp:TextBox></h4>
    <h4>Mobil<asp:TextBox ID="TextBox_mobile" runat="server"></asp:TextBox></h4>
    <h4>Mail<asp:TextBox ID="TextBox_mail" runat="server"></asp:TextBox></h4>
    <h3>Adminrättigheter</h3>




   <h4>Prisgrupp <asp:DropDownList ID="DropDownList_pricegroup" runat="server">
    </asp:DropDownList>
       </h4>

    <h4>Lösenord</h4>
    <asp:TextBox ID="TextBox_password01" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox_password02" runat="server"></asp:TextBox>



    <br />
    <asp:Button ID="Button_submitUser" runat="server" Text="Spara" />



</asp:Content>
