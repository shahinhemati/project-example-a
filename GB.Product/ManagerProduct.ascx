<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerProduct.ascx.cs"
    Inherits="IB.Product.ManagerProduct" %>
<div>
    <h1>
        Quản lý sản phẩm</h1>
</div>
<div>
    <div class="new_head">
        <ul>
            <li>Loại Sản phẩm </li>
            <li>
                <asp:DropDownList ID="ddlCatProducts" runat="server">
                </asp:DropDownList>
            </li>
            <li>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" />
            </li>
        </ul>
        <div class="clear">
        </div>
        <div>
            <a href='<%=EditUrl("EditProduct") %>'>Thêm mới</a> <a href='<%=EditUrl("CatProduct") %>'>
                Danh mục</a>
        </div>
    </div>
    <div>
        <asp:Repeater ID="rptproducts" runat="server">
            <HeaderTemplate>
                <div>
                    <b>STT</b> <b>Tên</b><b>Ngày tạo</b>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                    <a href='<%#EditUrl("","","EditProduct","productid="+Eval("productID"))%>'>[Sửa]</a>
                    <asp:LinkButton OnClick="DeleteProduct_Click" runat="server" CommandArgument='<%#Eval("productid")%>'
                        Text='[Xóa]' OnClientClick='return confirm("Bạn có chắc chắn xóa ?")' />
                    <%#Eval("Title")%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <asp:Literal ID="pnPaging" runat="server"></asp:Literal>
    </div>
</div>
