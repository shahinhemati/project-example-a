<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditNews.ascx.cs" Inherits="IB.News.EditNews" %>
<%@ Register TagPrefix="dnn" TagName="texteditor" Src="~/controls/texteditor.ascx" %>
<style type="text/css">
    .cs_title
    {
        width: 200px;
        display: block;
        font-weight: bolder;
        text-transform: uppercase;
    }
</style>
<div>
    <h1>
        Thêm/Sửa Tin bài</h1>
</div>
<div>
    <span class="cs_title">Tiêu đề bài viết </span>
    <asp:TextBox runat="server" ID="txtTitle" Width="690px" /><asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tiêu đề bài viết"
        ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
</div>
<div>
    <span class="cs_title">Tóm tắt</span><asp:TextBox runat="server" ID="txtDes" Columns="83"
        Rows="6" TextMode="MultiLine" />
</div>
<div>
    <span class="cs_title">Loại tin</span>
    <asp:DropDownList ID="ddlCatNews" runat="server">
    </asp:DropDownList>
</div>
<div>
    <span class="cs_title">Ảnh đại diện</span>
    <asp:Image runat="server" ID="img_P" />
    <div>
    </div>
    <asp:FileUpload runat="server" ID="flImge" />
</div>
<div>
    Nội dung
    <dnn:texteditor ID="txtContent" runat="server" TabIndex="3">
    </dnn:texteditor>
</div>
<div>
    <asp:Button runat="server" Text="Lưu lại" OnClick="SaveNews_Click" />
</div>
