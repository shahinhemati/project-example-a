using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.News.Components.Models;
using GB.News.Components.Views;

namespace GB.News.Components.Presenters
{
    public class HomePresenter:ModulePresenter<IHomeView,HomeModel>
    {
        public HomePresenter(IHomeView view) : base(view)
        {

        }
    }
}