<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsListOnlyTitle.ascx.cs"
    Inherits="UIListNews.ListType.NewsListOnlyTitle" %>
<div class="newss">
    <div class="newss-tis">
    </div>
    <ul>
        <asp:Repeater ID="rptnews" runat="server">
            <ItemTemplate>
                <li><a href='<%#ParentLoad.WriteUrl(ParentLoad.TabForward.ToString(),"detailnews",Eval("NewsID").ToString(),Eval("Title").ToString()) %>' title='<%#Eval("ShortContent") %>'>
                    <%#Eval("Title")%></a>(<i><%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("dd/MM/yyyy") %>)</i></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
