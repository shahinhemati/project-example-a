using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.Product.Components.Models;
using GB.Product.Components.Views;

namespace GB.Product.Components.Presenters
{
    public class HomePresenter:ModulePresenter<IHomeView,HomeModel>
    {
        public HomePresenter(IHomeView view) : base(view)
        {

        }
    }
}