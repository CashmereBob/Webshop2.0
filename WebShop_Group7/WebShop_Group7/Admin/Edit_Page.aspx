<%@ Page Language="C#" MasterPageFile="~/Admins.Master" AutoEventWireup="true"  CodeBehind="Edit_Page.aspx.cs" Inherits="WebShop_Group7.Admin.Edit_Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/tinymce/tinymce.min.js"></script>
  <script>tinymce.init({
    selector: 'textarea',
    height: 500,
    theme: 'modern',
    plugins: [
      'advlist autolink lists link image charmap print preview hr anchor pagebreak',
      'searchreplace wordcount visualblocks visualchars code fullscreen',
      'insertdatetime media nonbreaking save table contextmenu directionality',
      'emoticons template paste textcolor colorpicker textpattern imagetools'
    ],
    toolbar1: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
    toolbar2: 'print preview media | forecolor backcolor emoticons',
    image_advtab: true,
    templates: [
      { title: 'Test template 1', content: 'Test 1' },
      { title: 'Test template 2', content: 'Test 2' }
    ],
    content_css: [
      '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
      '//www.tinymce.com/css/codepen.min.css'
    ]
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