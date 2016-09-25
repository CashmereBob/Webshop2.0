<%@ Page Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true"  CodeBehind="Edit_Page.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/tinymce/tinymce.min.js"></script>
  <script>tinymce.init({
    selector: 'textarea',
    plugins: "code",
      code_dialog_width: 800
      });</script>

    <div>
        <h2>Redigera Sida</h2>
        <h3>Namn</h3>
        <asp:TextBox ID="TextBox_Name" runat="server"></asp:TextBox>
        </br>
        <h3>Innehåll</h3>
            
        <asp:TextBox id="TextArea_Content" TextMode="multiline"  runat="server" />
  

       </br>
            <asp:CheckBox ID="CheckBox_delete" runat="server" />
    <asp:Label ID="Label_delete" runat="server" Text="Ta bort"></asp:Label>
        </br>
        <asp:Button ID="Button_Save" runat="server" Text="Spara" OnClick="Button_Save_Click" />
    
    </div>

</asp:Content>