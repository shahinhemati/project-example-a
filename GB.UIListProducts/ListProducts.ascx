<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListProducts.ascx.cs"
    Inherits="UIListProducts.ListProducts" %>
<asp:MultiView runat="server" ID="mv">
    <asp:View runat="server" ID="vList">
        <asp:Repeater runat="server" ID="rptproducts" OnItemDataBound="OnDataBinding">
        </asp:Repeater>
        <div class="clear">
        </div>
        <div class="pager phantrang">
            <asp:Literal ID="pnPaging" runat="server"></asp:Literal>
        </div>
    </asp:View>
    <asp:View runat="server" ID="vDetail">
        <asp:PlaceHolder runat="server" ID="plhDetail"></asp:PlaceHolder>
    </asp:View>
</asp:MultiView>
<div class="clear">
</div>
