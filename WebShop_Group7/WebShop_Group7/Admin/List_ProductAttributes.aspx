<%@ Page Title="Product Types" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_ProductAttributes.aspx.cs" Inherits="WebShop_Group7.Admin.List_ProductAttributes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
     

            <div class="row">
                <div class="col-md-12">
                    <h2>Huvud produkt</h2>
                </div>
            </div>
            <%-- Search and stuff --%>
            <div class="row">             
                <div class="col-md-3">
                    <asp:Button ID="Button_Add" runat="server" Text="Add new Type" OnClick="Button_Add_Click" />
                </div>
                  <div class="col-md-1">
                        <asp:Image CssClass="img-responsive img-rounded" ID="Image_Product" AlternateText="Product Img" ImageUrl="http://lundgren84.com/KlädPlagg.jpg" runat="server" />
                  </div>

            </div>
            <%-- Product_Attribute values --%>
            <div class="row">
                <div class="col-md-6">
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-4">
                </div>

            </div>


            <asp:Table ID="Table1" runat="server" Width="100%">
          <asp:TableHeaderRow>
              <asp:TableCell>
                  <h3>Information</h3>
              </asp:TableCell>
          </asp:TableHeaderRow>
                <%-- Name --%>
                <asp:TableRow CssClass="row">
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Namn:"></asp:Label>
                    </asp:TableCell>
                    <%-- Current value --%>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label_ProductName" runat="server" Text="ProduktName"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label10" runat="server" Text=" Ändra till:"></asp:Label>
                    </asp:TableCell>
                    <%-- New Vlaue --%>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:TextBox ID="TextBox_ProductName" CssClass="form-control" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <%-- Category --%>
                <asp:TableRow CssClass="row">
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label2" runat="server" Text="Kategori: "></asp:Label>
                    </asp:TableCell>
                    <%-- Current value --%>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label_ProductCategory" runat="server" Text="ProductCategory"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label9" runat="server" Text=" Ändra till:"></asp:Label>
                    </asp:TableCell>
                    <%-- New Vlaue --%>
                    <asp:TableCell CssClass="col-md-2">
                      <%--  <asp:DropDownList OnSelectedIndexChanged="itemSelected" CssClass="form-control" ID="DropDownList_Category" runat="server" >
                             <asp:ListItem Value="Select"></asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="TextBox_Category" CssClass="form-control" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <%-- Brand --%>

                <asp:TableRow CssClass="row">
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label5" runat="server" Text="Märke: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label_ProductBrand" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label6" runat="server" Text=" Ändra till:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                      <%--  <asp:DropDownList OnSelectedIndexChanged="itemSelected" CssClass="form-control" ID="DropDownList_Brand"  runat="server">
                            <asp:ListItem Value="Select"></asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="TextBox_Brand" CssClass="form-control" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <%-- Img --%>
                <asp:TableRow CssClass="row">
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label3" runat="server" Text="ImgUrl: "></asp:Label>
                    </asp:TableCell>
                    <%-- Current value --%>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label_imgURL" runat="server"  Text="imgURL"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label11" runat="server" Text=" Ändra till:"></asp:Label>
                    </asp:TableCell>
                     <%-- New Vlaue --%>
                    <asp:TableCell CssClass="col-md-3">
                        <asp:TextBox ID="TextBox_ImgUrl" AutoSize="true" CssClass="form-control" runat="server" TextMode="Url"></asp:TextBox>
                    </asp:TableCell>
                   
                </asp:TableRow>
                <%-- Description --%>
                <asp:TableRow CssClass="row">
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label4" runat="server" Text="Förklaring: "></asp:Label>
                    </asp:TableCell>
                    <%-- Current value --%>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:TextBox ID="TextBox_ProductDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:Label ID="Label8" runat="server" Text=" Ändra till:"></asp:Label>
                    </asp:TableCell>
                    <%-- New Vlaue --%>
                    <asp:TableCell CssClass="col-md-2">
                        <asp:TextBox ID="TextBox_ProductNewDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </asp:TableCell>
                    <%-- SaveButton --%>
                    <asp:TableCell>
                        <asp:Button ID="Button_Save" runat="server" OnClick="Button_Save_Click" Text="Spara" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <%-- Star GridView --%>
            <div class="row">
            </div>
  


            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView_Products" runat="server" AutoGenerateColumns="false"
                        AllowSorting="true" AllowPaging="true" PageSize="100" CssClass="table-striped table">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="ArticleNr" HeaderText="Artikel nr" SortExpression="Artikel nr" />                          
                            <asp:BoundField DataField="b2bPrice" HeaderText="Pris B2B" SortExpression="Pris B2B" />
                            <asp:BoundField DataField="b2cPrice" HeaderText="Pris B2C" SortExpression="Pris B2C" />
                            <asp:BoundField DataField="quant" HeaderText="Antal" SortExpression="Antal" />
                            <asp:BoundField DataField="Attribute" HeaderText="Attributes" SortExpression="Attributes" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Redigera" runat="server" OnClick="OnUpdate" />
                                    <asp:LinkButton Text="Delete" runat="server" OnClick="DeleteObj" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
     
    </div>
</asp:Content>
