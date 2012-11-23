using System;
using System.Collections.Generic;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Models;
using GB.Common.Entities;

namespace GB.Album.Components.Views
{
    public interface IAlbumSettingsView : IModuleView<AlbumSettingsModel>
    {
        event EventHandler GetSettings;
        event EventHandler SaveSettings;
    }
}