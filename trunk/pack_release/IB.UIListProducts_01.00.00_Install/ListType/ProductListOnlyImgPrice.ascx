<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListOnlyImgPrice.ascx.cs"
    Inherits="UIListProducts.ListType.ProductListOnlyImgPrice" %>
<div class="news">
    <asp:Repeater ID="rptproducts" runat="server">
        <ItemTemplate>
            <div class="news-one">
                <a href='<%#WriteUrl(TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>'>
                    <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,Eval("ImageName").ToString()) %>'
                        alt='<%#Eval("Title") %>' />
                    <div class="h4">
                        <%#Eval("Title")%>
                        <div class="h5">
                            Giá :<%#int.Parse(Eval("Price").ToString()).ToString("##,###,###")+",000 VND"%>
                        </div>
                    </div>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
