<%@ Page Title="Products" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Products.aspx.cs" Inherits="WebShop_Group7.Admin.List_Products" %>

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
                    <asp:Button ID="Button_Add" runat="server" Text="Add new product" />
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
                            <asp:BoundField DataField="Name" HeaderText="Namn" SortExpression="Namn" />
                            <asp:BoundField DataField="CategoryID" HeaderText="Kategori" SortExpression="Kategori" />              
                            <asp:BoundField DataField="BrandID" HeaderText="Märke" SortExpression="Märke" />
                            <asp:BoundField DataField="Description" HeaderText="Förklaring" SortExpression="Förklaring" />
                            <asp:BoundField DataField="b2bPrice" HeaderText="Pris B2B" SortExpression="Pris B2B" />
                            <asp:BoundField DataField="b2cPrice" HeaderText="Pris B2C" SortExpression="Pris B2C" />
                            <asp:BoundField DataField="Attribute" HeaderText="AttributeS" SortExpression="AttributeS" />

                                <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton Text="Redigera/Visa" runat="server" OnClick="OnUpdate" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
