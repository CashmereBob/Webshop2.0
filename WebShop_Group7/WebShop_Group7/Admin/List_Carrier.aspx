<%@ Page Title="Frakt leverantör" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Carrier.aspx.cs" Inherits="WebShop_Group7.Admin.List_Carrier" %>

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

                <asp:GridView ID="GridView_Carrier" runat="server" AutoGenerateColumns="false"
                    AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table-striped table">

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="Försändelse-ID" SortExpression="ID" />

                        <asp:BoundField DataField="Carrier" HeaderText="Frakt leverantör" SortExpression="Frakt leverantör" />
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
