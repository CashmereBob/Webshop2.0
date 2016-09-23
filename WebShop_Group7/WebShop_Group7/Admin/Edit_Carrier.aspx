<%@ Page Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="Edit_Carrier.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Carrier" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h4>Leverantör</h4>
        <asp:TextBox ID="TextBox_carrier" runat="server"></asp:TextBox>
        <h4>Service</h4>
        <asp:TextBox ID="TextBox_Service" runat="server"></asp:TextBox>
        <h4>Price</h4>
        <asp:TextBox ID="TextBox_price" runat="server"></asp:TextBox>
        </br>
            <asp:CheckBox ID="CheckBox_delete" runat="server" />
    <asp:Label ID="Label_delete" runat="server" Text="Ta bort"></asp:Label>
        </br>
        <asp:Button ID="Button_Save" runat="server" Text="Spara" OnClick="Button_Save_Click" />
    
    </div>

    </asp:Content>