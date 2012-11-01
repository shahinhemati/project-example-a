<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerAlbum.ascx.cs"
    Inherits="IB.Album.ManagerAlbum" %>
<%if (IsEditable)
  { %>
<div class="link_mng">
    <a href='<%=EditUrl("EditAlbum") %>'>Thêm mới</a>
</div>
<%} %>
<asp:MultiView runat="server" ID="mv">
    <asp:View ID="vList" runat="server">
        <div class="news">
            <asp:Repeater ID="rptAlbum" runat="server">
                <ItemTemplate>
                    <div class="news-one">
                        <a href='<%#WriteUrl(TabForward.ToString(),"detailalbum",Eval("albumid").ToString(),Eval("AlbumName").ToString()) %>'>
                            <img src='<%#GetWebImageOfThumb(IB.Common.Base.LocationImage.Album,Eval("ImageName").ToString()) %>'
                                alt='<%#Eval("AlbumName") %>' class="img_product" />
                            <div class="h4">
                                <%#Eval("AlbumName")%>
                            </div>
                            <%if (IsEditable)
                              { %>
                            <div class="h4">
                                <a href='<%#EditUrl("","","EditAlbum","albumid="+Eval("AlbumID").ToString()) %>'>[Sửa]</a>
                                <asp:LinkButton runat="server" Text="[Xóa]" OnClick="DeleteAlbum_Click" CommandArgument='<%#Eval("AlbumID") %>' />
                            </div>
                            <% }%>
                        </a>
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
        <div class="titleAlbum">
            <asp:Literal runat="server" ID="txtTitle" />
        </div>
        <div class="desAlbum">
            <asp:Literal runat="server" ID="txtDes"></asp:Literal>
        </div>
        <div class="news">
            <asp:Repeater runat="server" ID="rptAlbumDtl">
                <ItemTemplate>
                    <div class="news-one">
                        <a class="img_album" title='<%#Eval("Title")%>' rel="album" href='<%#GetWebImgOf(IB.Common.Base.LocationImage.Album,Eval("ImageName").ToString())%>'>
                            <img class="item_img_img" src='<%#GetWebImageOfThumb(IB.Common.Base.LocationImage.Album,Eval("ImageName").ToString())%>'
                                class="img_product" />
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:View>
</asp:MultiView>
