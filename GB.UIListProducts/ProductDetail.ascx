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

<link rel="stylesheet" href='<%=ControlPath+"/Static/fancybox/jquery.fancybox-1.3.4.css"%>'
    type="text/css" media="screen" />
<div class="detail">
    <asp:PlaceHolder runat="server" ID="plhDetail">
    </asp:PlaceHolder>
</div>
<div class="img_product">
    <asp:Repeater runat="server" ID="rptImgProduct" >
    <ItemTemplate>
        
    </ItemTemplate>
    </asp:Repeater>
</div>
<div class="relative-product">
    <asp:Repeater runat="server" ID="rptRelative" OnItemDataBound="Relative_DataBinding">
    </asp:Repeater>
</div>
