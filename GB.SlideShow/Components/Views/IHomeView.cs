using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;

namespace GB.SlideShow.Components.Views
{
    public interface IHomeView :IModuleView<GB.SlideShow.Components.Models.HomeModel>
    {
        void Refresh();
    }
}
