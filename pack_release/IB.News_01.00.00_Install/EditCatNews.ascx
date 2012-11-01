<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCatNews.ascx.cs" Inherits="Apcom.News.EditCatNews" %>
<h1>Thêm/Sửa Mục tin tức</h1>
<span>Tên mục tin</span><asp:TextBox ID="txtCatNewsName" runat="server" 
    Width="535px" />
<div>
    <asp:Button runat="server" Text="Lưu thay đổi" onclick="SaveCatNews_Click" />
</div>