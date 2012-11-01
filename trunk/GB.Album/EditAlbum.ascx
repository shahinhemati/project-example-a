<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAlbum.ascx.cs" Inherits="IB.Album.EditAlbum" %>
<style>
    .item
    {
        
        width:250px;
        
        }
</style>
<div>
    <h1>
        Thêm / Sửa album</h1>
</div>
<div>
    <asp:HyperLink ID="addImage" runat="server">Thêm ảnh</asp:HyperLink>
</div>
<div>
    <div>
        Tên Album</div>
    <asp:TextBox ID="txtAlbum" runat="server" Width="638px" />
</div>
<div>
    <div>
        Ảnh :</div>
    <asp:Image ID="img_Album" runat="server" />
</div>
<div>
    <div>
        Ảnh
    </div>
    <asp:FileUpload ID="flUpload" runat="server" />
</div>
<div>
    <asp:TextBox ID="txtDes" runat="server" TextMode="MultiLine" Rows="6" Columns="80" />
</div>
<div>
    <fieldset>
        <legend>Ảnh album</legend>
        <div>
            <asp:Repeater runat="server" ID="rptImgOfAlbum">
                <ItemTemplate>
                    <div class="item">
                        <img src='<%#GetWebImageOfThumb(IB.Common.Base.LocationImage.Album,Eval("ImageName").ToString()) %>'
                            alt='<%#Eval("Title") %>' />
                        <asp:LinkButton runat="server" OnClick="DeleteImageOfAlbum_Click" CommandArgument='<%#Eval("ImageID") %>'
                            Text="Xóa" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </fieldset>
</div>
<div>
    <asp:Button ID="btnSave" runat="server" Text="Lưu lại" OnClick="SaveAlbum_Click" />
</div>
