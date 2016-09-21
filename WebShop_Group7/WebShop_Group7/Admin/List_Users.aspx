<%@ Page Title="Kunder" Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true" CodeBehind="List_Users.aspx.cs" Inherits="WebShop_Group7.Admin.List_Users" %>

        

 <asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h2><%: Title %>.</h2>
<p>1<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
     
     <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
     
    <asp:GridView ID="GridView_User" runat="server" AutoGenerateColumns="false"

    AllowSorting="true" AllowPaging="true" PageSize="5">

    <Columns>

        <asp:BoundField DataField="ID" HeaderText="Kund-ID" SortExpression="ID" />

        <asp:BoundField DataField="Firstname" HeaderText="Förnamn" SortExpression="Förnamn" />
        <asp:BoundField DataField="Lastname" HeaderText="Efternamn" SortExpression="Efternamn" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="Pricegroup" HeaderText="Prisgrupp" SortExpression="Prisgrupp" />







    </Columns>

</asp:GridView>

</asp:Content>