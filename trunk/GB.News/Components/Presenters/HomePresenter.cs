using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class HomePresenter:ModulePresenter<IHomeView,HomeModel>
    {
        public HomePresenter(IHomeView view) : base(view)
        {

        }
    }
}