<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerSlide.ascx.cs"
    Inherits="SlideShow.ManagerSlide" %>
<style type="text/css">
    .clear
    {
        clear: both;
    }
    .item
    {
        width: 250px;
        float: left;
        padding-right: 12px;
    }
    .title
    {
        padding: 5px;
        font-weight: bolder;
        font-size: 17px;
    }
</style>
<% if (IsEditable)
   { %>
<div>
    <h1>
        Quản lý Slide ảnh</h1>
</div>
<a href='<%=EditUrl("EditSlide")%>' class="title">Thêm slide </a>
<hr />
<%} %>
<div class="clear">
</div>
<asp:Repeater runat="server" ID="rptSlide">
    <ItemTemplate>
        <div class="item">
            <img alt='<%#Eval("Title") %>' src='<%#GetWebImageOfThumb(IB.Common.Base.LocationImage.Slide,Eval("FileImage")==null?"":Eval("FileImage").ToString()) %>' />
            <%if (IsEditable)
              { %>
            <a href='<%#EditUrl("","","EditSlide","slideid="+Eval("ItemID").ToString())%>'>[Sửa]</a>
            <asp:LinkButton runat="server" Text="[Xóa]" CommandArgument='<%#Eval("ItemID").ToString() %>'
                OnClick="DeletSlideItem_Click" />
                <%} %>
        </div>
    </ItemTemplate>
</asp:Repeater>
