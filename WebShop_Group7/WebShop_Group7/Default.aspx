<%@ Page Title="Start page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebShop_Group7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .startPanel {
            border: 2px solid lightgray;
            margin-top: 5%;
        }
    </style>
    <div id="carousel-example-generic" class="row carousel slide" data-ride="carousel">
        <%-- Indicators --%>
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to-="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to-="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to-="2"></li>
        </ol>
        <%-- Wrapper for slides --%>
        <div class="carousel-inner" role="listbox">
            <%-- 1 --%>
            <div class="item active">
                <a href="#">
                    <asp:Image class="img-responsive" ImageUrl="http://lundgren84.com/Grupp7/slide1.PNG" ID="Image13" runat="server" />
                    <div class="carousel-caption">
                    </div>
                </a>

            </div>
            <%-- 2 --%>
            <div class="item">
                <a href="#">
                    <asp:Image class="img-responsive" ImageUrl="http://lundgren84.com/Grupp7/slide2.PNG" ID="Image14" runat="server" />
                    <div class="carousel-caption">
                    </div>
                </a>
            </div>
            <%-- 3 --%>
            <div class="item">
                <a href="#">
                    <asp:Image class="img-responsive" ImageUrl="http://lundgren84.com/Grupp7/slide3.PNG" ID="Image15" runat="server" />
                    <div class="carousel-caption">
                    </div>
                </a>
            </div>
        </div>
        <%-- Controls --%>
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <%-- Panel logIn --%>
    <div class="row">
        <asp:Panel CssClass="startPanel panel_login col-md-3" ID="Panel1" runat="server">
            <div class="container">
                <div class="borderStart">
                     <div class="row">
                        <div class="col-md-12">
                            <h2>Login</h2>
                        </div>
                    </div>
                    <%-- Username --%>
                     <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label6" runat="server" Text="Username"></asp:Label>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="TextBox2" Width="100%" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <%-- Password --%>
                     <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox ID="TextBox1" Width="100%" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="Button1" Width="100%" runat="server" Text="Login" />
                        </div>
                    </div>
                 

                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="Button2" Width="100%" runat="server" Text="Register" />
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel ID="Panel2" runat="server">
                                    Register stuff gets visible when button pressed
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <%-- Panel erbjudanden --%>
        <asp:Panel CssClass="startPanel panel_Erbjudanden col-sm-3" ID="Panel_Left" runat="server" Visible="False">
            <div class="container">
                <div class="borderStart">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Erbjudanden</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label ID="Label2" runat="server" Text="">Rabatt %</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-sm-12">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image1" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label7" runat="server" Text="">Rabatt %</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image2" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label8" runat="server" Text="">Rabatt %</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image3" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </asp:Panel>
        <%-- Space --%>
        <div class="col-sm-1"></div>
        <%-- Main panel --%>
        <asp:Panel CssClass="startPanel col-sm-8" ID="Panel_Main" runat="server">
            <div class="container">
                <div class="borderStart">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Nyheter</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label1" runat="server" Text="Label">Skor</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image4" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image5" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image6" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label ID="Label3" runat="server" Text="Label">Byxor</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image7" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image8" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image9" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Label ID="Label4" runat="server" Text="Label">Tröjor</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image10" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image11" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="thumbnail">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image12" runat="server" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                    <p><a href="#" class="btn btn-primary" role="button">Add to cart</a> <a href="#" class="btn btn-default" role="button">Product Info</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>
        <%--  --%>
    </div>



    <div id="content" runat="server"></div>

</asp:Content>
