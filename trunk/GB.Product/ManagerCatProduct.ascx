<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCatProduct.ascx.cs"
    Inherits="IB.Product.ManagerCatProduct" %>
<div>
    <h1>
        Quản lý danh mục sản phẩm</h1>
</div>
<div>
    <a href='<%=EditUrl("EditCat") %>'>Thêm mới</a>
</div>
<div>
    <asp:Repeater ID="rpt" runat="server">
       <ItemTemplate>
            <div>
                <a href='<%#EditUrl("","","EditCat","catid="+Eval("catid")) %>'>[Sửa]</a>
                <asp:LinkButton OnClick="DeleteCatproduct_Click" runat="server" CommandArgument='<%#Eval("CatID")%>'
                    Text="[Xóa]" OnClientClick='return confirm("Bạn có chắc xóa mục này ? \n Nếu đồng ý các mục con và các sản phẩm thuộc mục này và mục con \n của nó sẽ bị xóa hết");'/>
                <%#Eval("catid")%>
                <%#Eval("catname") %>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
