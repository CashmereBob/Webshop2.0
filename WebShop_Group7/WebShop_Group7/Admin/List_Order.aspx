<%@ Page Title="Order" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Order.aspx.cs" Inherits="WebShop_Group7.Admin.List_Order" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="col-xs-12">
                <h2><%: Title %></h2>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
                <asp:Button ID="Button_Search" runat="server" Text="Search" OnClick="Button_Search_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="false" OnRowEditing="OnRowEditing"
                    AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table-striped table list-group">

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="Order NR" SortExpression="ID" />

                        <asp:BoundField DataField="Firstname" HeaderText="Förnamn" SortExpression="Förnamn" />

                        <asp:BoundField DataField="Lastname" HeaderText="Efternamn" SortExpression="Efternamn" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton Text="Detaljer" runat="server" OnClick="OnUpdate" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
