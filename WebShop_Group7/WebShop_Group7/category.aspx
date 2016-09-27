<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="category.aspx.cs" Inherits="WebShop_Group7.category" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                <div class="row">
                    <div class="col-xs-12" id="productCont" runat="server">
                      
                    </div>
                </div>
               

</asp:Content>
