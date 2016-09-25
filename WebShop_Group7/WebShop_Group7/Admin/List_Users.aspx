<%@ Page Title="Kunder" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Users.aspx.cs" Inherits="WebShop_Group7.Admin.List_Users" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <h2><%: Title %></h2>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">

                <asp:Button ID="Button_AddUser" runat="server" Text="Lägg till" OnClick="Button_AddUser_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">

                <asp:GridView ID="GridView_User" runat="server" AutoGenerateColumns="false" OnRowEditing="OnRowEditing"
                    AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table-striped table">

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="Kund-ID" SortExpression="ID" />

                        <asp:BoundField DataField="Name" HeaderText="Namn" SortExpression="Förnamn" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Pricegroup" HeaderText="Prisgrupp" SortExpression="Prisgrupp" />
                        <asp:BoundField DataField="Registered" HeaderText="Registrerad" SortExpression="Efternamn" />
                        <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Efternamn" />


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
</asp:Content>
