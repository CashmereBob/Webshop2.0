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


    <%-- Page --%>
    <div class="row">
        <%-- Panel left 1 --%>
        <asp:Panel CssClass="startPanel  col-sm-4" ID="panel_left1" runat="server" Visible=" true">
            <h3>Web Shop</h3>
            <p>
                Tote bag marfa biodiesel wayfarers. Banjo hot chicken enamel pin bitters mixtape prism. Tumeric small batch four loko, XOXO master cleanse bicycle rights yuccie iPhone shoreditch. Authentic squid retro ramps, farm-to-table put a bird on it ethical post-ironic cred bushwick cliche truffaut swag mixtape. Mumblecore snackwave poutine raclette affogato drinking vinegar tousled ramps church-key, unicorn hot chicken. Kinfolk cliche paleo cronut fingerstache. Pork belly flexitarian wayfarers 8-bit.
            </p>
              <p>
               Humblebrag pop-up poke, cardigan fingerstache farm-to-table beard bushwick chambray. You probably haven't heard of them live-edge stumptown pinterest. Pour-over letterpress edison bulb, portland waistcoat microdosing cliche. Truffaut try-hard ugh, PBR&B gochujang gastropub slow-carb VHS stumptown banh mi schlitz. Ramps you probably haven't heard of them health goth waistcoat church-key synth disrupt tacos stumptown.
            </p>
            <h3>Group Seven</h3>
          <p>Lyft echo park copper mug, freegan air plant portland jianbing glossier. Chicharrones venmo brunch, shoreditch art party lo-fi intelligentsia fam microdosing cred chambray. Twee church-key mlkshk 90's wolf af. Chambray occupy literally tattooed, pickled art party wayfarers. Small batch squid enamel pin, DIY mumblecore swag XOXO trust fund everyday carry VHS PBR&B art party. Yr freegan photo booth 8-bit. Occupy art party biodiesel bitters, cornhole prism everyday carry keffiyeh jianbing listicle keytar shabby chic disrupt schlitz.

Shoreditch unicorn tbh fingerstache bitters, viral tousled hot chicken leggings kombucha organic glossier. Four dollar toast chartreuse keytar, snackwave iPhone chia sartorial plaid yr listicle shabby chic meh literally ramps. Tofu offal mumblecore cliche mustache tumeric. Deep v woke artisan, biodiesel scenester copper mug occupy cliche drinking vinegar shoreditch. Pop-up marfa cliche master cleanse try-hard tumblr. Vinyl ethical pabst authentic waistcoat pug, celiac pinterest migas unicorn humblebrag distillery. Lo-fi slow-carb man bun, prism edison bulb la croix crucifix distillery snackwave cliche plaid messenger bag.
</p>

        </asp:Panel>
        <%-- Panel left 2 --%>
        <asp:Panel CssClass="startPanel  col-sm-4" ID="panel_left2" runat="server" Visible="False">
            <div class="container">
                <div class="borderStart ">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Erbjudanden</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div runat="server" id="SpecialOffers">
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <%-- Panel right --%>
        <asp:Panel CssClass="startPanel col-sm-8" ID="Panel_Main" runat="server">
            <div class="container">
                <div class="borderStart">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Nyheter</h2>
                        </div>
                    </div>
                    <%-- All news --%>
                    <div runat="server" id="productCont">
                    </div>


                </div>
            </div>
        </asp:Panel>

    </div>



    <div id="content" runat="server"></div>

</asp:Content>
