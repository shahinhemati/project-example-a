using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.SlideShow.Components.Models;
using GB.SlideShow.Components.Views;

namespace GB.SlideShow.Components.Presenters
{
    public class HomePresenter:ModulePresenter<IHomeView,HomeModel>
    {
        public HomePresenter(IHomeView view) : base(view)
        {

        }
    }
}