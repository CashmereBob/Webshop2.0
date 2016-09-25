<%@ Page Title="Pages" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Pages.aspx.cs" Inherits="WebShop_Group7.Admin.List_Pages" %>

  <asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <h2>
                    
                    <%: Title %></h2>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <asp:Button ID="Button_add" runat="server" Text="Lägg till" OnClick="Button_add_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">

                <asp:GridView ID="GridView_Pages" runat="server" AutoGenerateColumns="false"
                    AllowSorting="true" AllowPaging="true" PageSize="5" CssClass="table-striped table">

                    <Columns>

                        <asp:BoundField DataField="ID" HeaderText="Sid-ID" SortExpression="ID" />

                        <asp:BoundField DataField="Name" HeaderText="Namn" SortExpression="Namn" />
                        
                        
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
