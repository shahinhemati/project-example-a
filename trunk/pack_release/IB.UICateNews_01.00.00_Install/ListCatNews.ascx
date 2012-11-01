<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListCatNews.ascx.cs"
    Inherits="UICateNews.ListCatNews" %>

    <asp:Repeater runat="server" ID="rptcatnew">
        <ItemTemplate>
            <a class="sub-menu-item" href='<%#WriteUrlCat(TabForward,"catnews="+Eval("Catid")) %>'
                class='<%#CatID.ToString()==Eval("catid").ToString()?"select":"" %>'>
                <p>
                    <%#Eval("CatName") %></p>
            </a>
        </ItemTemplate>
    </asp:Repeater>

