<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
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
        <div class="border-sub-tis">
            <div class="sub-tis">
                <a class="breadcrumb" href="http://apcom.vn">Home</a>
                <span class='sp'>»</span>
                <dnn:BREADCRUMB ID="BREADCRUMB1" runat="server" RootLevel="0" Separator="<span class='sp'>»</span>"
                    CssClass="breadcrumb" UseTitle="false"/>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <!--end header-->
    <div class="line">
    </div>
    <div class="mid">
        <div class="content">
            <div class="sub-left-mid" id="menuleftpane" runat="server">
            </div>
            <!--end sub-left-mid-->
            <div class="sub-right-mid" runat="server" id="contentpane">
                <!--end sub-right-mid-content-->
            </div>
        </div>
        <!--end content-->
        <div class="clear">
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
                        Trụ sở: --------<br />
                        Điện thoại-Fax: -----<br />
                        Email: info@apcom.com.vn<br />
                        Website: apcom.com.vn<br />
                        Văn phòng: -------<br />
                        Điện thoại: 0000000 Fax: 0000000<br />
                    </p>
                </div>
                <div class="right-contact">
                    <p>
                        Trung tâm chăm sóc khách hàng:<br />
                        Điện thoại: 0000000<br />
                        Phòng kỹ thuật:<br />
                        Điện thoại: --<br />
                </div>
            </div>
        </div>
        <!--end infoFooter-->
    </div>
    <!--end footer-->
</div>
<!--end home-->
