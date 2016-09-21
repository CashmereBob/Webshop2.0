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
                <div class="col-md-3">
                    <asp:Button ID="Button_Search" runat="server" Text="Search" />
                </div>
            </div>
        </div>
        <div class="jumbotron">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView_Products" runat="server" AutoGenerateColumns="false"
                        AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table-striped table">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="CategoryID" HeaderText="Kategori" SortExpression="Kategori" />
                            <asp:BoundField DataField="Name" HeaderText="Namn" SortExpression="Namn" />
                            <asp:BoundField DataField="BrandID" HeaderText="Märke" SortExpression="Märke" />
                            <asp:BoundField DataField="Description" HeaderText="Förklaring" SortExpression="Förklaring" />


                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
