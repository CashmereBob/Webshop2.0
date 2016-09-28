<%@ Page Title="Start page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebShop_Group7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .startPanel {
            margin-top: 5%;
        }
    </style>
    <div id="carousel-example-generic" class="row carousel slide" data-ride="carousel">
        <%-- Controls --%>
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to-="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to-="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to-="2"></li>
        </ol>
        <%-- Panel logIn --%>
        <div class="carousel-inner" role="listbox">
            <%-- carousel img 1 --%>
            <div class="item active">
                <a href="#">
                    <asp:Image class="img-responsive" ImageUrl="http://lundgren84.com/Grupp7/slide1.PNG" ID="Image13" runat="server" />
                    <div class="carousel-caption">
                    </div>
                </a>

            </div>
            <%-- carousel img 2 --%>
            <div class="item">
                <a href="#">
                    <asp:Image class="img-responsive" ImageUrl="http://lundgren84.com/Grupp7/slide2.PNG" ID="Image14" runat="server" />
                    <div class="carousel-caption">
                    </div>
                </a>
            </div>
            <%-- carousel img 3 --%>
            <div class="item">
                <a href="#">
                    <asp:Image class="img-responsive" ImageUrl="http://lundgren84.com/Grupp7/slide3.PNG" ID="Image15" runat="server" />
                    <div class="carousel-caption">
                    </div>
                </a>
            </div>
        </div>
        <%-- Carousel controler--%>
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <%--  Login panel --%>
    <div class="row">
        <asp:Panel CssClass="startPanel panel_login col-md-3" ID="Panel_Login" runat="server">
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
                            <asp:Button ID="Button_Register" Width="100%" runat="server" Text="Register" OnClick="Button_Register_Click" />
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

        <%-- SpecialOffer Panel --%>
        <asp:Panel CssClass="startPanel panel_Erbjudanden col-sm-3" ID="Panel_SpecialOffers" runat="server" Visible="False">
            <div class="container">
                <div class="borderStart">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Erbjudanden</h2>
                        </div>
                    </div>

                    <%-- SpecialOffer 1 --%>
                    <div class="row">
                        <div class="col-sm-12 col-sm-12">                        
                                <asp:Panel ID="Panel10" CssClass="thumbnail" runat="server">
                                     <img src="Pictures/REA.png" />
                                    <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image4" runat="server" />
                                     <img src="Pictures/REA.png" />
                                    <div class="caption">
                                        <%-- Name --%>
                                        <asp:Label Font-Size="X-Large" ID="Label1" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                        <%-- Brand --%>
                                        <asp:Label ID="Label2" runat="server" Text="Brand"></asp:Label><span>,</span>
                                        <%-- Category --%>
                                        <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label><span>,</span>
                                        <%-- Attributes --%>
                                        <asp:Label ID="Label7" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                        <%-- Price --%><br />
                                        <span>Pris: </span>
                                        <asp:Label ID="Label8" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label9" runat="server" Text="kr"></asp:Label>
                                       <p><asp:TextBox ID="TextBox6" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox> <a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                    </div>
                                </asp:Panel>
                        </div>    
                        
                         
                     
                               
                    </div>
                    <%-- SpecialOffer 2 --%>

                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="thumbnail">
                                <img src="Pictures/REA.png" />
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image2" runat="server" />
                                <img src="Pictures/REA.png" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                      <p><asp:TextBox ID="TextBox4" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">Product Info</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- SpecialOffer 3 --%>

                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <div class="thumbnail">
                                <img src="Pictures/REA.png" />
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image3" runat="server" />
                                <img src="Pictures/REA.png" />
                                <div class="caption">
                                    <h3>Product Name</h3>
                                    <p>...</p>
                                     <p><asp:TextBox ID="TextBox3" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">Product Info</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </asp:Panel>
        <%-- Space --%>
        <div class="col-sm-1"></div>
        <%-- Main Panel --%>
        <asp:Panel CssClass="startPanel col-sm-8" ID="Panel_Main" runat="server">
            <div class="container">
                <div class="borderStart">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Nyheter</h2>
                        </div>
                    </div>
                    <%-- 1 --%>
                    <div class="row">
                        <div class="col-sm-4 new1">
                            <div class="">
                                <asp:Panel ID="Panel1" CssClass="thumbnail" runat="server">
                                    <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new1" runat="server" />
                                    <div class="caption">
                                        <%-- Name --%>
                                        <asp:Label Font-Size="X-Large" ID="Label_Name_new1" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                        <%-- Brand --%>
                                        <asp:Label ID="Label_Brand_new1" runat="server" Text="Brand"></asp:Label><span>,</span>
                                        <%-- Category --%>
                                        <asp:Label ID="Label_Cat_new1" runat="server" Text="Category"></asp:Label><span>,</span>
                                        <%-- Attributes --%>
                                        <asp:Label ID="Label_Attri_new1" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                        <%-- Price --%><br />
                                        <span>Pris: </span>
                                        <asp:Label ID="Label_Price_new1" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label3" runat="server" Text="kr"></asp:Label>
                                       <p><asp:TextBox ID="TextBox_Amount_new1" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox> <a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>

                        <%-- 2 --%>
                        <div class="col-sm-4 new1">

                            <asp:Panel ID="Panel_2" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new2" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new2" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new2" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new2" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new2" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new2" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label15" runat="server" Text="kr"></asp:Label>
                                    <p><asp:TextBox ID="TextBox_Amount_new2" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>

                        </div>
                        <%-- 3 --%>
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel3" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new3" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new3" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new3" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new3" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new3" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new3" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label24" runat="server" Text="kr"></asp:Label>
                                    <p><asp:TextBox ID="TextBox_Amount_new3" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <%-- 4 --%>
                    <div class="row">
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel4" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new4" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new4" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new4" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new4" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new4" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new4" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label29" runat="server" Text="kr"></asp:Label>
                                     <p><asp:TextBox ID="TextBox_Amount_new4" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>

                        <%-- 5 --%>
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel5" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new5" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new5" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new5" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new5" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new5" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new5" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label34" runat="server" Text="kr"></asp:Label>
                                     <p><asp:TextBox ID="TextBox_Amount_new5" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>
                        <%-- 6 --%>
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel6" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new6" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new6" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new6" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new6" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new6" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new6" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label39" runat="server" Text="kr"></asp:Label>
                                    <p><asp:TextBox ID="TextBox_Amount_new6" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <%-- 7 --%>
                    <div class="row">
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel7" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new7" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new7" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new7" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new7" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new7" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new7" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label44" runat="server" Text="kr"></asp:Label>
                                     <p><asp:TextBox ID="TextBox_Amount_new7" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>

                        <%-- 8 --%>
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel8" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new8" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new8" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new8" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new8" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new8" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new8" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label49" runat="server" Text="kr"></asp:Label>
                                    <p><asp:TextBox ID="TextBox_Amount_new8" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>
                        <%-- 9 --%>
                        <div class="col-sm-4 new1">
                            <asp:Panel ID="Panel9" CssClass="thumbnail" runat="server">
                                <asp:Image ImageUrl="http://lundgren84.com/Grupp7/TröjaG7.PNG" AlternateText="Product img" class="img-responsive" ID="Image_new9" runat="server" />
                                <div class="caption">
                                    <%-- Name --%>
                                    <asp:Label Font-Size="X-Large" ID="Label_Name_new9" runat="server" Text="ProductName"></asp:Label><span>,</span>
                                    <%-- Brand --%>
                                    <asp:Label ID="Label_Brand_new9" runat="server" Text="Brand"></asp:Label><span>,</span>
                                    <%-- Category --%>
                                    <asp:Label ID="Label_Cat_new9" runat="server" Text="Category"></asp:Label><span>,</span>
                                    <%-- Attributes --%>
                                    <asp:Label ID="Label_Attri_new9" runat="server" Text="Color: Red, Size: XL"></asp:Label>
                                    <%-- Price --%><br />
                                    <span>Pris: </span>
                                    <asp:Label ID="Label_Price_new9" runat="server" Text="Pris"></asp:Label><asp:Label ID="Label54" runat="server" Text="kr"></asp:Label>
                                    <p><asp:TextBox ID="TextBox_Amount_new9" placeholder="0" Width="50px" runat="server" TextMode="Number"></asp:TextBox><a href="#" class="btn btn-primary" role="button">Add to cart</a></p> <a href="#" class="btn btn-default" role="button">More Info</a>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <%--  --%>
    </div>



    <div id="content" runat="server"></div>

</asp:Content>
