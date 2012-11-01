<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerAlbum.ascx.cs"
    Inherits="Album.ManagerAlbum" %>
<style>
    .clear
    {
        clear: both;
    }
    .item_album
    {
        float: left;
        padding-left: 10px;
    }
    .item_album, .item_album_img
    {
        width: 200px;
    }
    .item_img_img, item_img
    {
        width: 173px;
        padding-left: 10px;
    }
</style>

<script type="text/javascript">
jQuery(document).ready(function (){
 //thiet lap chieu cao 
    var max=0;
    $('.item_album').each(function(){
        if(max<$(this).height()){
            max=$(this).height();
        }
    });
    
    $('.item_album').each(function(){
        $(this).height(max);
    });
    
    
    
    $('.item_img').each(function(){
        if(max<$(this).height()){
            max=$(this).height();
        }
    });
    
    $('.item_img').each(function(){
        $(this).height(max);
    });
});

</script>

<%if (IsEditable)
  { %>
<div>
    <a href='<%=EditUrl("EditAlbum") %>'>Thêm mới</a>
</div>
<%} %>
<asp:MultiView runat="server" ID="mv">
    <asp:View ID="vList" runat="server">
        <div>
            <asp:Repeater ID="rptAlbum" runat="server">
                <ItemTemplate>
                    <div class="item_album">
                        <a href='<%#WriteUrl(TabForward.ToString(),"detailalbum",Eval("albumid").ToString(),Eval("AlbumName").ToString()) %>'>
                            <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Album,Eval("ImageName").ToString()) %>'
                                alt='<%#Eval("AlbumName") %>' class="item_album_img" /></a>
                        <%if (IsEditable)
                          { %>
                        <div class="clear">
                        </div>
                        <a href='<%#EditUrl("","","EditAlbum","albumid="+Eval("AlbumID").ToString()) %>'>[Sửa]</a>
                        <asp:LinkButton runat="server" Text="[Xóa]" OnClick="DeleteAlbum_Click" CommandArgument='<%#Eval("AlbumID") %>' />
                        <% }%>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:View>
    <asp:View ID="vDetail" runat="server">

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
        <div>
            <asp:Literal runat="server" ID="txtTitle" />
        </div>
        <div>
            <asp:Literal runat="server" ID="txtDes"></asp:Literal>
        </div>
        <div>
            <asp:Repeater runat="server" ID="rptAlbumDtl">
                <ItemTemplate>
                    <div style="float: left;" class="item_img">
                        <a class="img_album" title='<%#Eval("Title")%>' rel="album" href='<%#GetWebImgOf(Apcom.Common.Base.LocationImage.Album,Eval("ImageName").ToString())%>'>
                            <img class="item_img_img" src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Album,Eval("ImageName").ToString())%>' />
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:View>
</asp:MultiView>
