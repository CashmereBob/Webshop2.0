<%@ Page Title="Users" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Users.aspx.cs" Inherits="WebShop_Group7.Admin.List_Users" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2><%: Title %>.</h2>
      
     
     <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
     <asp:Button ID="Button_Search" runat="server" Text="Sök" />
     <asp:DataList ID="DataList_Users" runat="server">
     </asp:DataList>
     <asp:Button ID="Button_Add" runat="server" Text="Lägg till" />

</asp:Content>
