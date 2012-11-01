<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCatProduct.ascx.cs" Inherits="IB.Product.EditCatProduct" %>

<div>
    <h1>
        Thêm/Sửa danh mục sản phẩm
    </h1>
       <h2 style="color:Red"> <asp:Literal runat="server" ID="ltr">  </asp:Literal>
    </h2>
  
</div>
<span>Tên mục sản phẩm</span><asp:TextBox ID="txtCatProductsName" 
    runat="server"  Width="467px" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên mục sản phẩm"
    ControlToValidate="txtCatProductsName"></asp:RequiredFieldValidator>
    <span>Thuộc mục:</span><asp:DropDownList runat="server" ID="ddlCatPrd" ></asp:DropDownList>
<div>
    <asp:Button ID="btnSave" runat="server" Text="Lưu thay đổi" onclick="SaveCatProduct_Click" />
</div>