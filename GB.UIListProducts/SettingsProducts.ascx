<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsProducts.ascx.cs"
    Inherits="UIListProducts.SettingsProducts" %>
<div>
    <span>Số bài </span>
    <asp:TextBox runat="server" ID="txtSize"></asp:TextBox>
</div>
<div>
    <span>Trang chuyển đến</span><asp:DropDownList runat="server" ID="ddlTabFw">
    </asp:DropDownList>
</div>
<div>
    <span>Mục hiển thị </span>
    <asp:DropDownList runat="server" ID="ddlCat">
    </asp:DropDownList>
</div>
<div>
    <span>Hiển thị không giá </span>
    <asp:TextBox runat="server" ID="txtNoPrice" />
</div>
<div>
    <span>Số cột </span>
    <asp:TextBox runat="server" ID="txtColumn" />
</div>
<fieldset>
    <legend>Danh sách</legend>
    <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="txtList" Width="641px"></asp:TextBox>
    <div class="clear"></div>
    <asp:Button runat="server" ID="btnListSave" Text="Lưu tempalte" OnClick="SaveListTemp_OnClick" />
    <div>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div style="float: left;padding-left: 5px;">
                    <img src='<%#ControlPath+"/templatelist/"+Eval("NameImage") %>' /><br />
                    <asp:Button ID="Button1" runat="server" CommandArgument='<%#Eval("NameTemp")%>' OnClick="ChangeFileList_OnClick"
                        Text="LoadTemp" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</fieldset>
<fieldset>
    <legend>Chi tiết</legend>
    <asp:TextBox runat="server" TextMode="MultiLine"  Rows="5" ID="txtDetail" Width="641px"></asp:TextBox>
    <div class="clear"></div>
    <asp:Button runat="server" ID="Button1" Text="Lưu tempalte" OnClick="SaveDetailTemp_OnClick" />
    <div>
        <asp:Repeater ID="rptDetail" runat="server">
            <ItemTemplate>
                <div style="float: left;padding-left: 5px;">
                    <img src='<%#ControlPath+"/templatelist/"+Eval("NameImage") %>' /><br />
                    <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("NameTemp")%>' OnClick="ChangeFileDetail_OnClick"
                        Text="LoadTemp" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</fieldset>
<fieldset>
    <legend>Liên quan </legend>
    <asp:TextBox runat="server" TextMode="MultiLine"  Rows="5" ID="txtRelative" Width="641px"></asp:TextBox>
    <div class="clear"></div>
    <asp:Button ID="Button3" runat="server" Text="Lưu tempalte" OnClick="SaveRelativeTemp_OnClick" />
    <div>
        <asp:Repeater ID="rptRelative" runat="server">
            <ItemTemplate>
                <div style="float: left;padding-left: 5px;">
                    <img src='<%#ControlPath+"/templatelist/"+Eval("NameImage") %>' /><br />
                    <asp:Button ID="Button4" runat="server" CommandArgument='<%#Eval("NameTemp")%>' OnClick="ChangeFileRelative_OnClick"
                        Text="LoadTemp" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</fieldset>
