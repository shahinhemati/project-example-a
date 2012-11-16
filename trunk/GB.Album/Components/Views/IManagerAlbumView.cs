using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;

namespace GB.Album.Components.Views
{
    public interface IManagerAlbumView : IModuleView<ManagerAlbumModel>
    {
        void Refresh();
        event EventHandler Delete;
    }
}