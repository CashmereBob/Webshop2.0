<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="Edit_User.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Kunduppgifter</h2>

    <h4>
        <asp:CheckBox ID="CheckBox_admin" runat="server" /><asp:Label ID="Label_admin" runat="server" Text="Admin"></asp:Label>
    </h4>
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
    <h3>Adminrättigheter</h3>




    <h4>Prisgrupp
        <asp:RadioButtonList ID="RADIO_pricegroup" runat="server">

            <asp:ListItem Text="B2C" Value="1"></asp:ListItem>
            <asp:ListItem Text="B2B" Value="2"></asp:ListItem>
        </asp:RadioButtonList>


    </h4>

    <h4>Lösenord</h4>
    <asp:TextBox ID="TextBox_password01" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox_password02" runat="server"></asp:TextBox>



    <asp:Label ID="Lable_Passwordmatch" runat="server" Text=""></asp:Label>

    <br />
    <asp:CheckBox ID="CheckBox_delete" runat="server" />
    <asp:Label ID="Label_delete" runat="server" Text="Ta bort"></asp:Label>
    <br />
    <asp:Button ID="Button_submitUser" runat="server" Text="Spara" OnClick="Button_submitUser_Click" />







</asp:Content>
