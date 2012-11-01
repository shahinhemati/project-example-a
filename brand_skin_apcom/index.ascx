<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<link href='<%=SkinPath+"style.css" %>' rel="stylesheet" type="text/css" />
<script src='<%=SkinPath+"equal_height.js" %>' type="text/javascript" ></script>
<div class="home">
    <div class="header">
        <div class="top">
            <div class="logo">
                <a href="#">
                    <img src="images/logo_300.gif" /></a><p>
                        apcom.com.vn</p>
            </div>
            <div class="rightLogo">
                <div class="topBar">
                    <ul>
                        <li>Call: 0000000</li>
                    </ul>
                </div>
                <!--end topBar-->
                <div class="clear">
                </div>
            </div>
            <!--end rightLogo-->
        </div>
        <!--end top-->
        <div class="nav">
            <ul>
                <li><a href="/en-us/home.aspx" id="home">Trang chủ </a></li>
                <li><a href="/en-us/san-pham.aspx" id="company">Sản phẩm</a></li>
                <li><a href="/en-us/tin-tuc.aspx" id="product">Tin tức</a></li>
                <li><a href="/en-us/thu-vien-anh.aspx" id="contact">Thư viện ảnh</a></li>
                <li><a href="/en-us/chung-toi.aspx" id="support">Chúng tôi</a></li>
            </ul>
        </div>
        <!--end nav-->
        <div class="slice" runat="server" id="slidepane" style="height:150px;">
        </div>
        <!--end slice-->
        <div class="clear">
        </div>
    </div>
    <!--end header-->
    <div class="line">
    </div>
    <div class="mid">
        <div class="content">
            <div class="leftContent" runat="server" id="contentpane">
                
                <!--end news-->
                
            </div>
            <!--end leftContent-->
            <div class="rightContent">
                <div class="videos-clip">
                    <div class="video-top">
                        <embed width="250" height="170" type="application/x-shockwave-flash" src='<%=SkinPath+"flvplayer.swf" %>'
                            id="single" name="" quality="high" allowfullscreen="true" flashvars='<%="displayheight=170&amp;width=240&amp;file=as.flv&amp;image="+SkinPath+"video1.png"%>'></embed>
                        <p class="video-top-name">
                            Hướng dẫn cài đặt và sử dụng bộ Công Cụ Việt</p>
                        <div class="clear">
                        </div>
                    </div>
                    <!--end vieo-clip-->
                    <div class="contact">
                        <div class="clear">
                        </div>
                        <div class="video-connect">
                            <a href="#">
                                <img src="images/yahoo.jpg" />
                                <p class="video-description">
                                    Hỗ trợ kỹ thuật</p>
                                <p class="video-description">
                                    Phone: 000000</p>
                                <p class="video-description">
                                    Email: support@apcom.com.vn</p>
                            </a>
                            <p class="clear">
                            </p>
                        </div>
                    </div>
                    <!--end contact-->
                </div>
                <!--end rightContent-->
                <div class="clear">
                </div>
            </div>
            <!--end content-->
            <div class="clear">
            </div>
        </div>
    </div>
    <!--end mid-->
    <div class="footer">
        <div class="menuFooter">
            <ul>
                <li><a href="/en-us/home.aspx" id="A1">Trang chủ </a></li>
                <li><a href="/en-us/san-pham.aspx" id="A2">Sản phẩm</a></li>
                <li><a href="/en-us/tin-tuc.aspx" id="A3">Tin tức</a></li>
                <li><a href="/en-us/thu-vien-anh.aspx" id="A4">Thư viện ảnh</a></li>
                <li><a href="/en-us/chung-toi.aspx" id="A5">Chúng tôi</a></li>
            </ul>
        </div>
        <!--end menuFooter-->
        <div class="infoFooter">
            <div class="contactIf">
                <div class="left-contact">
                    <p>
                        Trụ sở: -----<br />
                        Điện thoại-Fax: 00000<br />
                        Email: tc_chung@ymail.com.vn<br />
                        Website: apcom.com.vn<br />
                        Văn phòng: --------<br />
                        Điện thoại: 000000 Fax: ------<br />
                    </p>
                </div>
                <div class="right-contact">
                    <p>
                        Trung tâm chăm sóc khách hàng:<br />
                        Điện thoại: ---------<br />
                        Phòng kỹ thuật:<br />
                        Điện thoại: ------<br />
                    </p>
                </div>
            </div>
        </div>
        <!--end infoFooter-->
    </div>
    <!--end footer-->
</div>
<!--end home-->
