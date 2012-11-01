<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs"
    Inherits="UIListNews.NewsDetail" %>
<div class="detail-news">
    <asp:PlaceHolder runat="server" ID="plh_detail"></asp:PlaceHolder>
    <div class="topic-news-connect">
        <p class="topic-news-connect-tis">
            Tin liên quan:</p>
        <asp:Repeater runat="server" ID="rptOlder" OnItemDataBound="OnDataBinding">
        </asp:Repeater>
        <asp:Repeater runat="server" ID="rptNewer" OnItemDataBound="OnDataBinding">
        </asp:Repeater>
    </div>
</div>
