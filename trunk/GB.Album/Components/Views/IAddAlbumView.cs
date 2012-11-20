using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Entities;
using GB.Album.Components.Models;

namespace GB.Album.Components.Views
{
    public interface IAddAlbumView : IModuleView<AddAlbumModel>
    {
        event EventHandler<AlbumEventArgs<AlbumInfo>> AddNewAlbum;
    }
}