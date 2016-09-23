<%@ Page Title="Product Types" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_ProductAttributes.aspx.cs" Inherits="WebShop_Group7.Admin.List_ProductAttributes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
         
            <div class="row">
                <div class="col-md-12">
                    <h2><%: Title %>.</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Button ID="Button_Search" runat="server" Text="Search" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="Button_Add" runat="server" Text="Add new product" OnClick="Button_Add_Click" />
                </div>
            </div>
              <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Namn"></asp:Label>
                </div>
                 <div class="col-md-4">
                    <asp:Label ID="Label2" runat="server" Text="Kategori"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label_ProductName" runat="server" Text="ProduktName"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox_ProductName" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label_ProductCategory" runat="server" Text="ProductCategory"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox_ProductCategory" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Märke"></asp:Label>
                </div>
                 <div class="col-md-4">
                    <asp:Label ID="Label4" runat="server" Text="Förklaring"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label_ProductBrand" runat="server" Text="ProductBrand"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox_ProductBrand" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label_ProductDescription" runat="server" Text="ProductDescription"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox_ProductDescription" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" Text="Spara" />
                </div>
            </div>
        </div>
        <div class="jumbotron">
         
          
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView_Products" runat="server" AutoGenerateColumns="false"
                        AllowSorting="true" AllowPaging="true" PageSize="10" CssClass="table-striped table">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="ArticleNr" HeaderText="Artikel nr" SortExpression="Artikel nr" />
                      <%--      <asp:BoundField DataField="Name" HeaderText="Namn" SortExpression="Namn" />
                            <asp:BoundField DataField="CategoryID" HeaderText="Kategori" SortExpression="Kategori" />
                            <asp:BoundField DataField="BrandID" HeaderText="Märke" SortExpression="Märke" />
                            <asp:BoundField DataField="Description" HeaderText="Förklaring" SortExpression="Förklaring" />--%>
                            <asp:BoundField DataField="b2bPrice" HeaderText="Pris B2B" SortExpression="Pris B2B" />
                            <asp:BoundField DataField="b2cPrice" HeaderText="Pris B2C" SortExpression="Pris B2C" />
                            <asp:BoundField DataField="quant" HeaderText="Antal" SortExpression="Antal" />
                            <asp:BoundField DataField="Attribute" HeaderText="AttributeS" SortExpression="AttributeS" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Redigera" runat="server" OnClick="OnUpdate" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
