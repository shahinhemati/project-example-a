<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsListFull.ascx.cs"
    Inherits="UIListNews.NewsListFull" %>
<p class="sub-right-mid-tis">
  Tin tức</p>
<div class="news2">
    <asp:Repeater ID="rptnews" runat="server">
        <ItemTemplate>
            <div class="tin">
                <a href='<%#WriteUrl(TabForward.ToString(),"detailnews",Eval("NewsID").ToString(),Eval("Title").ToString()) %>'>
                    <div class="anhMH">
                        <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.News,Eval("ImageName").ToString()) %>'
                            alt='<%#Eval("title") %>' class="img" />
                        <div class="bongAnh">
                            <img src='<%#ControlPath+"img/bongTin.png" %>' /></div>
                    </div>
                </a>
                <a href='<%#WriteUrl(TabForward.ToString(),"detailnews",Eval("NewsID").ToString(),Eval("Title").ToString()) %>'>
                    <p class="tdTin">
                        <%#Eval("Title")%></p>
                </a>
                <p class="ngaydang">
                    <%--<%#(Eval("CreateDate")as DateTime).ToString("dd/MM/yyyy") %></p>--%>
                    </p>
                <p class="ndTin">
                    <%#Eval("ShortContent") %>
                </p>
            </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <div class="clear">
            </div>
        </SeparatorTemplate>
    </asp:Repeater>
</div>
<div class="clear"></div>
 <div class="pager phantrang">
    <asp:Literal ID="pnPaging" runat="server"></asp:Literal>
</div>