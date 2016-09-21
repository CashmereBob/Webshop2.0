<%@ Page Title="Order" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Order.aspx.cs" Inherits="WebShop_Group7.Admin.List_Order" %>

        

 <asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h2><%: Title %>.</h2>
<p>1<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
     
     <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
     <asp:Button ID="Button_Search" runat="server" Text="Search" OnClick="Button_Search_Click" />
      
    <asp:GridView ID="GridView_Order" runat="server" AutoGenerateColumns="false"

    AllowSorting="true" AllowPaging="true" PageSize="5">

    <Columns>

        <asp:BoundField DataField="ID" HeaderText="Order NR" SortExpression="ID" />

        <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="Förnamn" />




    </Columns>

</asp:GridView>

</asp:Content>