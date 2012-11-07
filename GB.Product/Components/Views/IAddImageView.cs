using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;
using GB.Product.Components.Args;
using GB.Product.Components.Models;
using GB.Product.Components.Entities;

namespace GB.Product.Components.Views
{
    public interface IAddImageView :IModuleView<AddImageModel>
    {
        void Refresh();
        event EventHandler<AddImageEventArgs<AlbumInfo, bool, string>> SaveData;
    }
}
