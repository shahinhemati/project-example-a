using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;
using GB.News.Components.Args;
using GB.News.Components.Models;
using GB.News.Components.Entities;

namespace GB.News.Components.Views
{
    public interface IAddImageView :IModuleView<AddImageModel>
    {
        void Refresh();
        event EventHandler<AddImageEventArgs<AlbumInfo, bool, string>> SaveData;
    }
}
