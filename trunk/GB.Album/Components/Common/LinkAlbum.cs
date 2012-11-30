using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.UI.Modules;
using GB.Album.CommonBase;

namespace GB.Album.Components.Common
{
    public class LinkAlbum
    {
        public static string Home(int tabId)
        {
            return DotNetNuke.Common.Globals.NavigateURL(tabId, "", "");
        }

        public static string AddAlbum(ModuleInstanceContext modContext)
        {
            return modContext.NavigateUrl(modContext.TabId, "", false, "view=" + Constants.PageScope.Ask.ToString().ToLower());
        }
    }
}