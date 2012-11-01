<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListProducts.ascx.cs"
    Inherits="UIListProducts.ListProducts" %>
<style type="text/css">
    .left
    {
        float: left;
        width: 30%;
    }
    .right
    {
        float: left;
        width: 70%;
    }
    .clear
    {
        clear: both;
    }
    .new-event1
    {
        float: left;
    }
    .new-event1
    {
        width: 100%;
    }
</style>
<asp:MultiView runat="server" ID="mv">
    <asp:View runat="server" ID="vList">
    <asp:PlaceHolder runat="server" ID="plhList">
    </asp:PlaceHolder>
    </asp:View>
    <asp:View runat="server" ID="vDetail">
    <asp:PlaceHolder runat="server" ID="plhDetail">
    </asp:PlaceHolder>
    </asp:View>
</asp:MultiView>
<div class="clear">
</div>
