<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slide.ascx.cs" Inherits="SlideShow.Slide" %>
<link rel="stylesheet" type="text/css" href='<%=ControlPath+"/Static/"+"preview.css"%>' />
<link rel="stylesheet" type="text/css" href='<%=ControlPath+"/Static/"+"wt-rotator.css"%>' />

<script type="text/javascript">
    var widthslide='<%=WidthSlide%>';
    var heightslide='<%=HeightSlide%>';
</script>

<script type="text/javascript" src='<%=ControlPath+"/Static/"+"js/jquery.easing.1.3.min.js"%>'></script>

<script type="text/javascript" src='<%=ControlPath+"/Static/"+"js/jquery.wt-rotator.min.js"%>'></script>

<script type="text/javascript" src='<%=ControlPath+"/Static/"+"js/preview.js"%>'></script>

<!--[if lt IE 9]>
  	<style>
    	.panel {
	    	border-left:1px solid #444;
			border-right:1px solid #444;
        }
    </style>
    <![endif]-->
    <style type="text/css"> 
        .slide_css
        {
            color:White;
            font-size:18px;
            font-weight:bolder;
            
            }
    </style>
<center>
    <asp:HyperLink runat="server" ID="hplManager"  CssClass="slide_css"/>
</center>
<div class="panel">
    <div class="container">
        <div class="wt-rotator">
            <div class="screen">
                <noscript>
                    <img src="images/triworks_abstract17.jpg" /></noscript>
            </div>
            <div class="c-panel">
                <div class="thumbnails">
                    <ul>
                        <asp:Repeater ID="rpt" runat="server">
                            <ItemTemplate>
                                <li><a href='<%#GetWebImgOf(IB.Common.Base.LocationImage.Slide,Eval("FileImage")+"") %>'
                                    title='<%#Eval("Title") %>'>
                                    <img src='<%#GetWebImageOfThumb(IB.Common.Base.LocationImage.Slide,Eval("FileImage")+"") %>' /></a>
                                    <a href='<%#(Eval("url")==null)?"#":Eval("url").ToString() %>' target="_self"></a>
                                    <div style="left: 5px; top: 94px; width: 336px; height: 0;">
                                        <h1>
                                            <%#Eval("Title") %></h1>
                                        <%#Eval("Description") %>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="buttons">
                    <div class="prev-btn">
                    </div>
                    <div class="play-btn">
                    </div>
                    <div class="next-btn">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
