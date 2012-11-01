<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerNews.ascx.cs"
    Inherits="Apcom.News.ManagerNews" %>
<link href='<%=ControlPath+"Static/News.css"%>' rel="stylesheet" type="text/css" />

<div>
    <h1>Quản lý tin bài</h1>
</div>
<div>
    <div class="new_head">
        <ul>
            <li>Loại tin </li>
            <li>
                <asp:DropDownList ID="ddlCatNews" runat="server">
                </asp:DropDownList>
            </li>
            <li>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Button ID="btnSearch" runat="server" Text="Button" />
            </li>
        </ul>
        <div class="clear">
        </div>
        <div>
            <a href='<%=EditUrl("EditNews") %>'>[Thêm mới]</a> <a href='<%=EditUrl("CatNews") %>'>
                [Danh mục]</a>
        </div>
    </div>
    <div>
        <asp:Repeater ID="rptnews" runat="server">
            <HeaderTemplate>
                <div>
                    <b>STT</b> <b>Tên</b><b>Ngày tạo</b>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                 <a href='<%#EditUrl("","","EditNews","newsid="+Eval("newsid")) %>'>[Edit] </a>
                    <asp:LinkButton OnClick="DeleteNews_Click" runat="server" CommandArgument='<%#Eval("NewsID")%>'
                        Text='[Xóa]' />
                    <%#Eval("Title")%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pager">
        <asp:Literal ID="pnPaging" runat="server"></asp:Literal>
    </div>
</div>
