<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSlide.ascx.cs" Inherits="SlideShow.EditSlide" %>
<div>
    <h1>Thêm / Sửa Slide ảnh</h1>
</div>
<div>
    <div>Tiêu đề:</div><asp:TextBox ID="txtTitle" runat="server" Width="658px" />
</div>
<div>
    <div>Mô tả:</div><asp:TextBox ID="txtDes" runat="server"  TextMode="MultiLine" Rows="6" Columns="80"/>
</div>
<div>
    <div>URL:</div>
    <asp:TextBox ID="url" runat="server" Width="656px" />
</div>
<div>
    <div>Ảnh </div>
    <asp:Image runat="server" ID="img" />
    <div></div>
    <asp:FileUpload  ID="flUpload" runat="server"/>
</div>
<div>
    <asp:Button runat="server" Text="Lưu lại" OnClick="SaveChange_Click" />
</div>
