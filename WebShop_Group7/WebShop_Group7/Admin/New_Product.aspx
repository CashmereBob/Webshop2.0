<%@ Page Title="New Product" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="New_Product.aspx.cs" Inherits="WebShop_Group7.Admin.New_Product" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2><%: Title %>.</h2>
        <div class="jumbotron">

            <div class="row">
                <%-- IMG --%>
                <div class="col-md-3">
                    <asp:Image CssClass="img-responsive img-rounded" ID="Image_Product" ImageUrl="http://lundgren84.com/KlädPlagg.jpg" AlternateText="Product Img" runat="server" />
                </div>
            </div>
            <div class="row">
                <asp:Label ID="Label_ImgUrl" runat="server" Text=""></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <h4>Img Url:</h4>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox_ImgUlr" CssClass="form-control" runat="server" TextMode="Url"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_NewProductIMG" runat="server" Text="Upload" OnClick="Button_NewProductIMG_Click" />
                </div>
            </div>

            <%-- Produktuppgifter --%>
            <div class="row">
                <div class="col-md-2">
                    <h3>Produktuppgifter</h3>
                </div>
            </div>
            <%-- Produkt Namn --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Produktnamn:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_ProductName" runat="server"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ControlToValidate="TextBox_ProductName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <%-- Artikelnummer --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Artikelnummer: </h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox1_ArticleNumber" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TextBox1_ArticleNumber"></asp:RequiredFieldValidator>
                </div>
            </div>
            <%-- Antal i lager --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Antal i lager:</h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Quantity" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <%-- Varumärke --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Varumärke: </h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Brand" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TextBox_Brand"></asp:RequiredFieldValidator>
                </div>
            </div>
            <%-- Kategori --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Kategori:  </h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Category" runat="server"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="TextBox_Category"></asp:RequiredFieldValidator>
                </div>
            </div>
            <%-- B2B --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Pris B2B:  </h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_B2B" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <%-- B2C --%>
            <div class="row">
                <div class="col-md-2">
                    <h4>Pris B2C:  </h4>
                </div>

                <div class="col-md-3">
                    <asp:TextBox CssClass="form-control" ID="TextBox_B2C" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <%-- Beskrivning --%>
            <div class="row">
                <div class="col-md-2">
                    <h3>Beskrivning</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    <asp:TextBox ID="TextBox_Description" runat="server" ReadOnly="False" Height="100%" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </div>
            </div>

            <%-- Egenskaper --%>
            <div class="row">
                <div class="col-md-2">
                    <h3>Egenskaper</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label1" runat="server" Text="Namn"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label2" runat="server" Text="Värde"></asp:Label>
                </div>
            </div>
            <%-- Egenskap1 --%>

            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="Label3" runat="server" Text="1:"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute1_Name" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute1_Value" runat="server"></asp:TextBox>
                </div>
            </div>

            <%-- Egenskap2 --%>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="Label5" runat="server" Text="2:"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute2_Name" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute2_Value" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Egenskap3 --%>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="Label6" runat="server" Text="3:"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute3_Name" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute3_Value" runat="server"></asp:TextBox>
                </div>
            </div>
            <%-- Egenskap4 --%>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="Label7" runat="server" Text="4:"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute4_Name" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:TextBox CssClass="form-control" ID="TextBox_Attribute4_Value" runat="server"></asp:TextBox>
                </div>
            </div>

            <%-- Save button --%>
            <div class="row">
                <div class="col-md-4">
                    <asp:Button CssClass="btn btn-default" Csstype="button" ID="Button_Save" runat="server" Text="Lägg till produkt" OnClick="Button_Save_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
