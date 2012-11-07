using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.UI.Modules;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Common;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(DispatchPresenter))]
    public partial class Dispatch : ModuleView<DispatchModel>,IDispatchView,IActionable
    {
        
        public Dispatch()
        {
            AutoDataBind = true;
        }

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get {return new ModuleActionCollection(); }
        }

        public void Refresh()
        {
            Utils.RegisterClientDependencies(Page);

            var ctlDirectory = TemplateSourceDirectory;

            var objControl = LoadControl(ctlDirectory + Model.ControlToLoad) as ModuleUserControlBase;
            if (objControl == null) return;

            phUserControl.Controls.Clear();
            objControl.ModuleContext.Configuration = ModuleContext.Configuration;
            objControl.ID = System.IO.Path.GetFileNameWithoutExtension(ctlDirectory + Model.ControlToLoad);
            phUserControl.Controls.Add(objControl);

            if ((string)ViewState["CtlToLoad"] != Model.ControlToLoad)
            {
                ViewState["CtlToLoad"] = Model.ControlToLoad;
            }
        }
    }
}