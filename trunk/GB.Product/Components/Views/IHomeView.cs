using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;

namespace GB.Product.Components.Views
{
    public interface IHomeView :IModuleView<GB.Product.Components.Models.HomeModel>
    {
        void Refresh();
    }
}
