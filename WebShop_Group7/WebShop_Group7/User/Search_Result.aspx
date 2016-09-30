<%@ Page Title="Search Result" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Search_Result.aspx.cs" Inherits="WebShop_Group7.User.Search_Result" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="container">
        <div class="row">
            <h1 class="col-xs-12">Sök ord:
        <asp:Label ID="Label_SearchString" runat="server" Text=""></asp:Label>
            </h1>
        </div>
        <asp:Panel CssClass="row" ID="Panel_SearchFailed" runat="server" Visible="False">
<h2>Hitta ignet. . . </h2>
        </asp:Panel>--%>

        <%--  Product name--%>    
      <%--  <asp:Panel class="row" ID="Panel_NameSearch" runat="server">
            
            <h2 class="col-xs-12">
                <asp:Label ID="Label1" runat="server" Text="Produkt namn"></asp:Label>
            </h2>
            <div id="NameResult" runat="server"></div>
        </asp:Panel>--%>

        <%-- Brand --%>
          <%-- <asp:Panel class="row" ID="Panel_BrandSearch" runat="server">
            <h2 class="col-xs-12">
                <asp:Label ID="Label2" runat="server" Text="Märke"></asp:Label>
            </h2>
            <div id="BrandResult" runat="server"></div>
        </asp:Panel>--%>
        <%-- Category --%>
          <%-- <asp:Panel class="row" ID="Panel_CategorySearch" runat="server">
            <h2 class="col-xs-12">
                <asp:Label ID="Label3" runat="server" Text="Kategori"></asp:Label>
            </h2>
            <div id="CategoryResult" runat="server"></div>
        </asp:Panel>--%>
        <%-- Description --%>
           <%--<asp:Panel class="row" ID="Panel_DivSearch" runat="server">
            <h2 class="col-xs-12">
                <asp:Label ID="Label_DivResult" runat="server" Text="Diverse"></asp:Label>
            </h2>
            <div id="Div_DivResult" runat="server"></div>
        </asp:Panel>--%>
        <%-- END --%>
    <%--</div>--%>

     <script src="Scripts/bootstrap-slider.min.js"></script>
    <script src="Scripts/JsCategory.js"></script>
    <link href="css/bootstrap-slider.min.css" rel="stylesheet" />

    <div id="wrapper">

        <!-- Sidebar -->
        <div id="sidebar-wrapper">

            <ul class="sidebar-nav" runat="server" id="filternav">
            </ul>
        </div>
        <!-- /#sidebar-wrapper -->


        <!-- Page Content -->
        <div id="page-content-wrapper">
            <div class="container-fluid">

                <div class="row">
                    <div class="col-xs-12">
                        <h2>Kategori</h2>
                        <hr>
                        <h4 class="button-aside"><a href="#menu-toggle" id="menu-toggle"><span class="glyphicon glyphicon-filter" aria-hidden="true"></span></a></h4>
                        <hr>
                    </div>
                </div>
                <div class="row" id="productCont" runat="server">
                </div> 
             
</div>
</asp:Content>
