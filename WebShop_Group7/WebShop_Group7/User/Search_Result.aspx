<%@ Page Title="Search Result" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Search_Result.aspx.cs" Inherits="WebShop_Group7.User.Search_Result" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <h1>Sök ord: <asp:Label ID="Label_SearchString" runat="server" Text=""></asp:Label></h1>


    <div id="productResult" runat="server"></div>


    </asp:Content>
