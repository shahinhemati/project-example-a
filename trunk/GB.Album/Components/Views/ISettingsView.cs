using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;

namespace GB.Album.Components.Views
{
    public interface IAlbumSettingsView : IModuleView<AlbumSettingsModel>
    {
        event EventHandler GetSettings;
        event EventHandler SaveSettings;
    }
}