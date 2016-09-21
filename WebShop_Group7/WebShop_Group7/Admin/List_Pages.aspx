<%@ Page Title="Pages" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Pages.aspx.cs" Inherits="WebShop_Group7.Admin.List_Pages" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2><%: Title %>.</h2>
      <asp:DataList ID="DataList_Users" runat="server">
     </asp:DataList>
     <asp:Button ID="Button_add" runat="server" Text="Lägg till" />
</asp:Content>
