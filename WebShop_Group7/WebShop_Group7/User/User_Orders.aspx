<%@ Page Title="Order" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="User_Orders.aspx.cs" Inherits="WebShop_Group7.User.User_Orders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="col-xs-12">
                <h2><%: Title %></h2>
            </div>
        </div>



        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="false" OnRowEditing="OnRowEditing"
                    CssClass="table-striped table list-group">

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="Order NR" SortExpression="ID" />

                        <asp:BoundField DataField="Date" HeaderText="Datum" SortExpression="datum" />

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
