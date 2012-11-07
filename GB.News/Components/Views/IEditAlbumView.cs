using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Models;
using GB.Album.Components.Entities;

namespace GB.Album.Components.Views
{
    public interface IEditAlbumView:IModuleView<EditAlbumModel>
    {
        void Refresh();
        event EventHandler<EditAlbumEventArgs<AlbumInfo,bool,string>> SaveData;
    }
}
