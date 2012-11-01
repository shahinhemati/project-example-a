<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListFull.ascx.cs"
    Inherits="UIListProducts.ProductListFull" %>
<p class="sub-right-mid-tis">
    USB 3G</p>
<div class="sub-right-mid-content">
    <asp:Repeater ID="rptproducts" runat="server">
        <ItemTemplate>
            <div class="product">
                <div class="product-img">
                    <a href='<%#WriteUrl(TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>'>
                        <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,Eval("ImageName").ToString()) %>'
                            alt='<%#Eval("Title") %>' />
                    </a>
                </div>
                <p class="product-description">
                    <%#Eval("Title") %>( Giá :<%#int.Parse(Eval("Price").ToString()).ToString("##,###,###")+",000 VND"%>)
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <div class="pager">
        <asp:Literal ID="pnPaging" runat="server"></asp:Literal>
    </div>
</div>
