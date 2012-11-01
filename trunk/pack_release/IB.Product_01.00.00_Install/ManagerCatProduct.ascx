<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCatProduct.ascx.cs"
    Inherits="Apcom.Product.ManagerCatProduct" %>
<div>
    <h1>
        Quản lý danh mục sản phẩm</h1>
</div>
<div>
    <a href='<%=EditUrl("EditCat") %>'>Thêm mới</a>
</div>
<div>
    <asp:Repeater ID="rpt" runat="server">
        <HeaderTemplate>
            <span>ID</span> <span>Ten</span>
        </HeaderTemplate>
        <ItemTemplate>
            <div>
                <a href='<%#EditUrl("","","EditCat","catid="+Eval("catid")) %>'>[Sửa]</a>
                <asp:LinkButton OnClick="DeleteCatproduct_Click" runat="server" CommandArgument='<%#Eval("CatID")%>'
                    Text="[Xóa]" />
                <%#Eval("catid")%>
                <%#Eval("catname") %>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
