<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsCatProduct.ascx.cs" Inherits="UICateProduct.SettingsCatProduct" %>
<span>Trang chuyển đến</span><asp:DropDownList runat="server" ID="ddlTabFw"></asp:DropDownList>
<span>Loại tin</span><asp:DropDownList  runat="server" ID="ddlCatPrds"></asp:DropDownList>
<div>
    <span>Kiểu danh sách</span><asp:DropDownList runat="server" ID="ddlListType" 
        AutoPostBack="True" onselectedindexchanged="ddlListType_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Image runat="server" ID="imgPreview" />
    <asp:Button runat="server" ID="btnCacelList" Text="Hủy" OnClick="btnCancelist_Click" />
    Nội dung template :<asp:TextBox runat="server" ID="txtTemplate"></asp:TextBox>
</div>