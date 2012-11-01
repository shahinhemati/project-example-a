<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCatNews.ascx.cs"
    Inherits="Apcom.News.ManagerCatNews" %>
<div>
    <h1>
        Quản lý mục tin bài</h1>
</div>
<div>
    <a href='<%=EditUrl("EditCat") %>'>Thêm mới</a>
</div>
<div>
    <asp:Repeater ID="rpt" runat="server">
        <HeaderTemplate>
            <span>ID</span><span>Tên</span>
        </HeaderTemplate>
        <ItemTemplate>
            <div>
                <span><a href='<%#EditUrl("","","EditCat","catid="+Eval("catid")) %>'>[Sửa]</a>
                    <asp:LinkButton OnClick="DeleteNews_Click" runat="server" CommandArgument='<%#Eval("CatID")%>'
                        Text="[Xóa]" />
                    <%#Eval("catid")%></span> <span>
                        <%#Eval("catname") %></span>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
