<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductListOnlyImgPrice.ascx.cs"
    Inherits="UIListProducts.ListType.ProductListOnlyImgPrice" %>
<div class="news">
    <asp:Repeater ID="rptproducts" runat="server">
        <ItemTemplate>
            <div class="news-one">
                <a href='<%#ParentLoad.WriteUrl(ParentLoad.TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>' title='<%#Eval("ShortContent") %>'>
                    <img src='<%#ParentLoad.GetWebImageOfThumb(IB.Common.Base.LocationImage.Product,Eval("ImageName").ToString()) %>'
                        alt='<%#Eval("Title") %>' class="img_product"/>
                    <div class="h4">
                        <%#Eval("Title")%>
                    </div>
                    <div class="h5">
                        Giá :<%#int.Parse(Eval("Price").ToString()) == 0 ? ParentLoad.NoPrice : int.Parse(Eval("Price").ToString()).ToString("##,###,###") + ",000 VND"%>
                    </div>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
