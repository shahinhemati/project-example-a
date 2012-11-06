using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(DispatchPresenter))]
    public partial class Dispatch : ModuleView<DispatchModel>,IDispatchView,IActionable
    {
        

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get { throw new NotImplementedException(); }
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}