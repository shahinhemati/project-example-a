using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Models;
using GB.Album.Components.Entities;

namespace GB.Album.Components.Views
{
    public interface IAddImageView :IModuleView<AddImageModel>
    {
        void Refresh();
        event EventHandler<AddImageEventArgs<AlbumInfo, bool, string>> SaveData;
    }
}
