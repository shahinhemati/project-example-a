<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs"
    Inherits="UIListNews.NewsDetail" %>
<div class="detail-news">
    <p class="detail-news-tis" id="txtTitle" runat="server">
    </p>
    <p class="detail-new-tis-info">
        (22/04/2011)
    </p>
    <p class="detail-news-descrition" id="txtDescript" runat="server">
    </p>
    <div class="detail-news-content" runat="server" id="txtContent">
    </div>
    <div class="topic-news-connect">
        <p class="topic-news-connect-tis">
           Tin liên quan:</p>
        <ul>
            <asp:Repeater runat="server" ID="rptOlder">
                <ItemTemplate>
                    <li><a href='<%#WriteUrl(TabForward.ToString(),"detailnews",Eval("NewsID").ToString(),Eval("Title").ToString()) %>'>
                        <%#Eval("Title")%></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <ul>
            <asp:Repeater runat="server" ID="rptNewer">
                <ItemTemplate>
                    <li><a href='<%#WriteUrl(TabForward.ToString(),"detailnews",Eval("NewsID").ToString(),Eval("Title").ToString()) %>'>
                        <%#Eval("Title")%></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
