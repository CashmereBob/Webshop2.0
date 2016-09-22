<%@ Page Title="Betalning" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Payment.aspx.cs" Inherits="WebShop_Group7.Admin.List_Payment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <h2><%: Title %>.</h2>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">

                <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">

                <asp:GridView ID="GridView_Payment" runat="server" AutoGenerateColumns="false"
                    AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table-striped table">

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="Betalnings-ID" SortExpression="ID" />

                        <asp:BoundField DataField="Provider" HeaderText="Leverantör" SortExpression="Leverantör" />
                        <asp:BoundField DataField="Service" HeaderText="Tjänst" SortExpression="Tjänst" />
                        <asp:BoundField DataField="Price" HeaderText="Pris" SortExpression="Pris" />
                        
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

