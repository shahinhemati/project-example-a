<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.ascx.cs"
    Inherits="UIListProducts.ProductDetail" %>

<script type="text/javascript" src='<%=ControlPath+"/Static/fancybox/jquery.fancybox-1.3.4.pack.js" %>'></script>

<script type="text/javascript" src='<%=ControlPath+"/Static/fancybox/jquery.easing-1.3.pack.js" %>'></script>

<script type="text/javascript" src='<%=ControlPath+"/Static/fancybox/jquery.mousewheel-3.0.4.pack.js" %>'></script>

<script type="text/javascript">
            $(document).ready(function() {


                $("a#funcyalbum").fancybox({
                    'titlePosition': 'over',
                    'overlayColor': '#000',
                    'overlayOpacity': 0.9
                });

                /* Apply fancybox to multiple items */

                $("a[rel=album]").fancybox({
                    'overlayColor': '#000',
                    'titlePosition': 'over',
                    'overlayOpacity': 0.9
                });

            });

</script>

<style type="text/css">
    </style>
<link rel="stylesheet" href='<%=ControlPath+"/Static/fancybox/jquery.fancybox-1.3.4.css"%>'
    type="text/css" media="screen" />
<div class="pr_header">
    <div class="img">
        <asp:Image ID="prImg" runat="server" />
    </div>
    <div class="title_des">
        <div id="txtTitle" runat="server">
        </div>
        <div id="txtDescript" runat="server">
        </div>
    </div>
    <div class="clear">
    </div>
    <div style="overflow: hidden; width: 900px; height: 50px;">
        <asp:Repeater runat="server" ID="rptImgProduct">
            <ItemTemplate>
                <div style="float: left; padding: 2px 5px 2px 5px; height: auto;">
                    <a class="img_album" rel="album" href='<%#GetWebImgOf(Apcom.Common.Base.LocationImage.Product,Eval("FileName").ToString())%>'>
                        <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,Eval("FileName").ToString())%>'
                            alt="" width="200px;" />
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<div class="clear">
</div>
<div id="txt_content" runat="server" class="pr_content">
</div>
<div>
    <h2>
        Sản phẩm liên quan</h2>
</div>
<div class="pr_relate">
    <asp:Repeater runat="server" ID="rptNewer">
        <ItemTemplate>
            <div class="new-event1">
                <div class="left">
                    <a href='<%#WriteUrl(TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>'>
                        <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,Eval("ImageName").ToString()) %>'
                            alt='<%#Eval("Title") %>' />
                    </a>
                </div>
                <div class="right">
                    <div class="new-event1-tis">
                        <a href='<%#WriteUrl(TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>'>
                            <%#Eval("Title")%>
                        </a>
                    </div>
                    <div>
                        Giá : <span>
                            <%#Eval("Price")%></span></div>
                    <div class="new-event-shortinfo">
                        <%#Eval("ShortContent") %>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div>
    <asp:Repeater runat="server" ID="rptOlder">
        <ItemTemplate>
            <div class="new-event1">
                <div class="left">
                    <a href='<%#WriteUrl(TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>'>
                        <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,Eval("ImageName").ToString()) %>'
                            alt='<%#Eval("Title") %>' />
                    </a>
                </div>
                <div class="right">
                    <div class="new-event1-tis">
                        <a href='<%#WriteUrl(TabForward.ToString(),"detailproduct",Eval("productID").ToString(),Eval("Title").ToString()) %>'>
                            <%#Eval("Title")%>
                        </a>
                    </div>
                    <div>
                        Giá : <span>
                            <%#Eval("Price")%></span></div>
                    <div class="new-event-shortinfo">
                        <%#Eval("ShortContent") %>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
