<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCatNews.ascx.cs"
    Inherits="IB.News.ManagerCatNews" %>
<div>
    <h1>
        Quản lý mục tin bài</h1>
</div>
<div>
    <a href='<%=EditUrl("EditCat") %>'>Thêm mới</a>
</div>
<div>
    <asp:Repeater ID="rpt" runat="server">
        <ItemTemplate>
            <div>
                <span><a href='<%#EditUrl("","","EditCat","catid="+Eval("catid")) %>'>[Sửa]</a>
                    <asp:LinkButton OnClick="DeleteNews_Click" runat="server" CommandArgument='<%#Eval("CatID")%>'
                        Text="[Xóa]" OnClientClick='return confirm("Bạn có chắc xóa mục này ? \n Nếu đồng ý các mục con và tin bài thuộc mục này và mục con \n sẽ bị xóa hết");' />
                    <%#Eval("catid")%></span> <span>
                        <%#Eval("catname") %></span>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
