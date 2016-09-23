<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admins.Master" CodeBehind="Edit_Payment.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h4>Leverantör</h4>
        <asp:TextBox ID="TextBox_payment" runat="server"></asp:TextBox>
        <h4>Service</h4>
        <asp:TextBox ID="TextBox_Service" runat="server"></asp:TextBox>
        <h4>Price</h4>
        <asp:TextBox ID="TextBox_price" runat="server"></asp:TextBox>
        </br>
        <asp:Button ID="Button_Save" runat="server" Text="Button" />
    
    </div>

    </asp:Content>