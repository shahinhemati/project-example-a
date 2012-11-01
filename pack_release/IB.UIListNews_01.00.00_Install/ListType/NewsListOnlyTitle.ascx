<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsListOnlyTitle.ascx.cs"
    Inherits="UIListNews.ListType.NewsListOnlyTitle" %>
<div class="newss">
    <div class="newss-tis">
        Tin nhanh</div>
    <ul>
        <asp:Repeater ID="rptnews" runat="server">
            <ItemTemplate>
                <li><a href='<%#WriteUrl(TabForward.ToString(),"detailnews",Eval("NewsID").ToString(),Eval("Title").ToString()) %>'>
                    <%#Eval("Title")%></a> </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
