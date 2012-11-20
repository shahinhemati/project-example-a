<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="TagList.ascx.cs" Inherits="GB.Album.TagList" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnnweb" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Import Namespace="GB.Album.Components.Common" %>
<%@ Register TagPrefix="dqa" Namespace="GB.Common.Controls" Assembly="GB.Common" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>

<div class="dnnqaTagList dnnForm">
	<h2 class="dnnFormSectionHead"><%= Localization.GetString("Title", LocalResourceFile)%></h2>
	<div class="qatlRight">
		<ul class="qaSortActions dnnClear">
			<li><asp:HyperLink ID="hlTagPopular" runat="server" resourcekey="hlTagPopular" /></li>
			<li><asp:HyperLink ID="hlTagName" runat="server" resourcekey="hlTagName" /></li>
			<li><asp:HyperLink ID="hlTagLatest" runat="server" resourcekey="hlTagLatest" /></li>
		</ul>
	</div>
	<p><%= Localization.GetString("TagDescription", LocalResourceFile) %></p>
	<div class="qaTagFilter dnnClear">
		<label for="<%= txtFilter.ClientID %>"><%= Localization.GetString("SearchTerms", LocalResourceFile) %></label>
		<asp:TextBox ID="txtFilter" runat="server" />
		<asp:LinkButton ID="cmdFilter" runat="server" resourcekey="cmdFilter" CssClass="dnnPrimaryAction" OnClick="CmdOnSearchClick" />
	</div>
	<div class="qaTagResults dnnClear">
		<asp:Repeater ID="rptTags" runat="server" OnItemDataBound="RptTagsItemDataBound" EnableViewState="false" >
			<HeaderTemplate><ul class="qaTags"></HeaderTemplate>
			<ItemTemplate>
				<li class="qaTag">
					<dqa:Tags ID="dqaTag" runat="server" /><br /><br />
					<span class="qaTagCounts"><asp:Literal ID="litCount" runat="server" /></span>
					<p class="dnnClear"><asp:Literal ID="litDescription" runat="server" /></p>
					<span class="qaTagStats"><asp:Literal ID="litStats" runat="server" /></span>
				</li>
			</ItemTemplate>
			<FooterTemplate></ul></FooterTemplate>
		</asp:Repeater>
		<asp:Panel ID="pnlNoRecords" runat="server" CssClass="dnnFormMessage dnnFormWarning">
			<%= Localization.GetString("NoRecords", LocalResourceFile) %>
		</asp:Panel>
	</div>
	<div class="qaPager">
		<ul class="qaPageActions dnnClear">
			<li><asp:LinkButton ID="cmdMore" runat="server" resourcekey="cmdMore" OnClick="CmdPagingClick" CommandName="up" CssClass="dnnPrimaryAction" /></li>
			<li><asp:LinkButton ID="cmdBack" runat="server" resourcekey="cmdBack" OnClick="CmdPagingClick" CommandName="down" CssClass="dnnPrimaryAction" /></li>
		</ul>
	</div>
</div>