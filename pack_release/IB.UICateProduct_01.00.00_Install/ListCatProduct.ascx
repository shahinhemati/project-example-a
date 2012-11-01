<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListCatProduct.ascx.cs"
    Inherits="UICateProduct.ListCatProduct" %>
<asp:Repeater runat="server" ID="rptcatnew">
    <ItemTemplate>
        <a class="sub-menu-item" href='<%#WriteUrlCat(TabForward,"catproduct="+Eval("Catid")) %>'
            class='<%#CatID.ToString()==Eval("catid").ToString()?"select":"" %>'>
            <p>
                <%#Eval("CatName")%></p>
        </a>
    </ItemTemplate>
</asp:Repeater>
