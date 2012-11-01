<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.ascx.cs"
    Inherits="Apcom.Product.EditProduct" %>
<%@ Register TagPrefix="dnn" TagName="texteditor" Src="~/controls/texteditor.ascx" %>
<style type="text/css">
    .cs_title
    {
        width: 200px;
        display:block;
        font-weight:bolder;
        text-transform:uppercase;
    }
    .max_size
    {
        font-size:larger;
        text-transform:uppercase;
        font-weight:bolder;
        }
</style>
<div>
    <h1>Thêm/Sửa sản phẩm</h1>
</div>
<div>
    <asp:HyperLink ID="addImage" runat="server" CssClass="max_size"></asp:HyperLink>
</div>
<div>
    <span class="cs_title">Tiêu đề bài viết</span><asp:TextBox runat="server" 
        ID="txtTitle" Width="691px" />
</div>
<div>
    <span class="cs_title">Loại sản phẩm:</span><asp:DropDownList ID="ddlCatProduct"
        runat="server">
    </asp:DropDownList>
</div>
<div>
    <span class="cs_title">Tóm tắt</span><asp:TextBox runat="server" ID="txtDes" 
        Columns="83" Rows="6" TextMode="MultiLine" />
</div>
<div>
    <span class="cs_title">Giá (Ngìn đồng)</span><asp:TextBox runat="server" ID="txtPrice" />
</div>
<div>
    <span class="cs_title">Ảnh đại diện</span>
    <asp:Image runat="server" ID="img_P" />
    <div></div>
    <asp:FileUpload runat="server" ID="flImge" />
</div>
<div>
    Nội dung
    <dnn:texteditor ID="txtContent" runat="server" TabIndex="3">
    </dnn:texteditor>
</div>
<div>
    <asp:Button ID="Button1" runat="server" Text="Lưu lại" OnClick="SaveProduct_Click" />
</div>
<div>
    <fieldset>
        <legend>ảnh</legend>
        <asp:Repeater ID="rptimgproduct" runat="server">
            <ItemTemplate>
                <img src='<%#GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,Eval("FileName").ToString()) %>'
                    alt='<%#Eval("FileName") %>' />
                <asp:LinkButton runat="server" Text="Xóa" OnClick="DeleteImage_Click" CommandArgument='<%#Eval("imageID") %>' />
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
</div>
