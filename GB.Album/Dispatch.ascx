<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Dispatch.ascx.cs" Inherits="IB.Album.Dispatch" %>
<div class="dnnClear">
	<asp:PlaceHolder ID="phUserControl" runat="server" />
</div>
<script language="javascript" type="text/javascript">
    /*globals jQuery, window, Sys */
    (function ($, Sys) {
        function setupDnnQuestions() {
            $('.qaTooltip').qaTooltip();
        }

        $(document).ready(function () {
            setupDnnQuestions();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                setupDnnQuestions();
            });
        });

    } (jQuery, window.Sys));
</script>  