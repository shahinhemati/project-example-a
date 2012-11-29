<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAlbum.ascx.cs" Inherits="GB.Album.AddAlbum" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnnweb" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="GB.Common.Controls" %>

<div class="dnnForm qaAskQuestion" id="qaAskQuestion">
	<fieldset>
		<div class="dnnFormItem">
			<dnn:label id="dnnlblTitle" runat="server" controlname="txtTitle" suffix=":"  />
			<asp:TextBox ID="txtTitle" runat="server" CssClass="dnnFormRequired qaplaceholder qaAskQuestion" MaxLength="150" TabIndex="0" />
			<asp:RequiredFieldValidator ID="valTitle" runat="server" resourcekey="valTitle.ErrorMessage" Display="Dynamic" ControlToValidate="txtTitle" CssClass="dnnFormMessage dnnFormError" />
		</div>
		<div class="dnnFormItem">
			<dnn:label id="dnnlblQuestion" runat="server" controlname="teShortContent" suffix=":" />
			<div class="dnnLeft">
				<dnn:texteditor id="teShortContent" runat="server" height="250px" width="500"  ></dnn:texteditor>
				<asp:Label ID="valQuestion" runat="server" resourcekey="valQuestion.ErrorMessage" Display="Dynamic" CssClass="dnnFormMessage dnnFormValidationSummary" Visible="false" />
			</div>			
		</div>
        <div class="dnnFormItem">
			<dnn:label id="dnnlblShortQuestion" runat="server" controlname="teContent" suffix=":" />
			<div class="dnnLeft">
				<dnn:texteditor id="teContent" runat="server" height="250px" width="500" ></dnn:texteditor>
				<asp:Label ID="valShortQuestion" runat="server" resourcekey="valQuestion.ErrorMessage" Display="Dynamic" CssClass="dnnFormMessage dnnFormValidationSummary" Visible="false" />
			</div>			
		</div>
		<asp:Panel class="dnnFormItem" id="pnlTags" runat="server">
			<dnn:label id="dnnlblTags" runat="server" controlname="txtTags" suffix=":" />
			<asp:TextBox ID="txtTags" runat="server" CssClass="dnnFormRequired" />	
		</asp:Panel>
	</fieldset>
	<ul class="dnnActions dnnClear">
		<li><asp:LinkButton ID="cmdSave" runat="server" resourcekey="cmdSave" CssClass="dnnPrimaryAction" OnClick="Btn_Click" /></li>
		<li><asp:HyperLink ID="cmdCancel" runat="server" resourcekey="cmdCancel" CssClass="dnnSecondaryAction" /></li>
	</ul>
</div>
<dnnweb:DnnCodeBlock ID="cbEditPost" runat="server">
	<script language="javascript" type="text/javascript">
		/*globals jQuery, window, Sys */
		var mydata;
		(function ($, Sys) {
			function setupAskQuestion() {
			
				function split(val) {
					return val.split(/,\s*/);
				}

				function extractLast(term) {
					return split(term).pop();
				}

				var myTextArea = $('#<%= txtTags.ClientID  %>').tagify( {delimiters: [9, 13, 44, 59, 188], addTagPrompt: '<%= Localization.GetString("AddTags", LocalResourceFile) %>' } ); // tab, return, comma, semicolon
				myTextArea.tagify('inputField').autocomplete({
					source: function (request, response) {
								$.ajax({
									type:"POST",
									url:'<%= ResolveUrl("~/DesktopModules/gb/gb.album/QA.asmx/SearchTags")%>',
									data:"{'searchTerm' : '" + extractLast(request.term) + "'}",
									contentType: "application/json",
									dataType: "json",
									success: function(data){
										var suggestions=[];
										mydata=data;
										$.each($.parseJSON(data.d),function(i,val){
											suggestions.push(val);
										});
										response(suggestions);
									}
								});
							},			
					minLength: 2,
					close: function(event, ui) { myTextArea.tagify('add'); myTextArea.tagify('serialize'); }
				});
			};

			$(document).ready(function () {
				setupAskQuestion();
				Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
					setupAskQuestion();
				});
			});

		} (jQuery, window.Sys));
	</script>
	<script id="questionsTemplate" type="text/html">
		<li>
			<span class="answercount">
				${QuestionVotes}
			</span>
			<span class="summary">
				<a href="${QuestionUrl}" target="_blank">${Title}</a>&nbsp;&nbsp;(${TotalAnswers})
			</span>
		</li>
	</script>
</dnnweb:DnnCodeBlock>