using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;

namespace GB.News.Components.Views
{
    public interface IHomeView :IModuleView<GB.News.Components.Models.HomeModel>
    {
        void Refresh();
    }
}
