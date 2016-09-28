<%@ Page Title="Products" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Products.aspx.cs" Inherits="WebShop_Group7.Admin.List_Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

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
            <div class="col-md-12">
                <asp:GridView ID="GridView_Products" runat="server" AutoGenerateColumns="false"
                    AllowSorting="true" AllowPaging="true" PageSize="10" CssClass="table-striped table list-group" OnSelectedIndexChanged="GridView_Products_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />

                        <asp:BoundField DataField="Name" HeaderText="Namn" SortExpression="Namn" />
                        <asp:BoundField DataField="CategoryID" HeaderText="Kategori" SortExpression="Kategori" />
                        <asp:BoundField DataField="BrandID" HeaderText="Märke" SortExpression="Märke" />
                        <asp:BoundField DataField="Description" HeaderText="Förklaring" SortExpression="Förklaring" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton Text="Visa" runat="server" OnClick="OnUpdate" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton Text="Delete" runat="server" OnClick="DeleteObj" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
