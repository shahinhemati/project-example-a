<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCatProduct.ascx.cs" Inherits="Apcom.Product.EditCatProduct" %>

<div>
    <h1>
        Thêm/Sửa danh mục sản phẩm
    </h1>
</div>
<span>Tên mục sản phẩm</span><asp:TextBox ID="txtCatProductsName" 
    runat="server"  Width="467px" />
<div>
    <asp:Button ID="btnSave" runat="server" Text="Lưu thay đổi" onclick="SaveCatProduct_Click" />
</div>