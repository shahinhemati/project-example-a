using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Models;

namespace GB.Album.Components.Views
{
    public interface IAlbumSettingsView:ISettingsView<AlbumSettingsModel>
    {
        event EventHandler<AlbumSettingsEventArgs<string, String>> addSetting;
    }
}