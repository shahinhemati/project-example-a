<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Dispatch.ascx.cs" Inherits="GB.Album.Dispatch" %>
<div class="dnnForm GBAlbumSettings dnnClear" id="GBAlbumSettings">
    <div class="dnnFormItem">
        <ul class="dnnActions">
            <li><a class="dnnPrimaryAction" href='<%=ModuleContext.NavigateUrl(ModuleContext.TabId,"",false,"view=addalbum") %>'>Add New</a></li>
            <li><a class="dnnPrimaryAction" href='<%=ModuleContext.NavigateUrl(ModuleContext.TabId,"",false,"view=manageralbum") %>'>Manager album</a></li>
            <li><a class="dnnSecondaryAction" href='<%=ModuleContext.NavigateUrl(ModuleContext.TabId,"",false,"view=managerimage") %>'>Manager image</a></li>
        </ul>
    </div>
</div>
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
