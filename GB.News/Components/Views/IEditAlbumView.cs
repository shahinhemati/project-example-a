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
    public interface IEditAlbumView:IModuleView<EditAlbumModel>
    {
        void Refresh();
        event EventHandler<EditAlbumEventArgs<AlbumInfo,bool,string>> SaveData;
    }
}
