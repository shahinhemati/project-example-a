using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;

namespace GB.Album.Components.Views
{
    public interface IHomeView :IModuleView<GB.Album.Components.Models.HomeModel>
    {
        void Refresh();
    }
}
