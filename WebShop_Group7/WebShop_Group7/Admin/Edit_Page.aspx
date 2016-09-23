<%@ Page Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true"  CodeBehind="Edit_Page.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
  <script>tinymce.init({ selector:'textarea' });</script>

    <div>
        <h4>Namn</h4>
        <asp:TextBox ID="TextBox_payment" runat="server"></asp:TextBox>
        <h4>Innehåll</h4>
            </br>
        <asp:TextBox id="TextArea_input" TextMode="multiline"  runat="server" />
        </br>

        <asp:Button ID="Button_Save" runat="server" Text="Button" />
    
    </div>

</asp:Content>