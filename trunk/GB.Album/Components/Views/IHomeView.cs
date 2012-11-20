using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;

namespace GB.Album.Components.Views
{
    public interface IHomeView :IModuleView<HomeModel>
    {
        void Refresh();
    }
}
