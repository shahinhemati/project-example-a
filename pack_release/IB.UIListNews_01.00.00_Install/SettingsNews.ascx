<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsNews.ascx.cs" Inherits="UIListNews.SettingsNews" %>

<div>
    <span>Số bài </span><asp:TextBox runat="server" id="txtSize"></asp:TextBox>
</div>
<div>
    <span>Trang chuyển đến</span><asp:DropDownList runat="server" ID="ddlTabFw"></asp:DropDownList>
</div>
<div>
    <span>Mục hiển thị </span><asp:DropDownList runat="server" id="ddlCat"></asp:DropDownList>
</div>
<div>
    <span>Kiểu danh sách</span><asp:DropDownList runat="server" ID="ddlListType"></asp:DropDownList>
</div>