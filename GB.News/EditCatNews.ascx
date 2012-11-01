<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCatNews.ascx.cs"
    Inherits="IB.News.EditCatNews" %>
<h1>
    Thêm/Sửa Mục tin tức</h1>
   <h2 style="color:Red"> <asp:Literal runat="server" ID="ltr"></asp:Literal></h2>
<span>Tên mục tin</span><asp:TextBox ID="txtCatNewsName" runat="server" Width="535px" />
<span>Thuộc mục:</span><asp:DropDownList runat="server" ID="ddlCatNews" ></asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên mục tin"
    ControlToValidate="txtCatNewsName"></asp:RequiredFieldValidator>
<div>
    <asp:Button runat="server" Text="Lưu thay đổi" OnClick="SaveCatNews_Click" />
</div>
