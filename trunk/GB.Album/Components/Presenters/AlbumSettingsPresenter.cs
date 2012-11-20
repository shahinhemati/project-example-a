using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
   
    public class AlbumSettingsPresenter:ModuleSettingsPresenter<IAlbumSettingsView,AlbumSettingsModel>
    {
        public AlbumSettingsPresenter(IAlbumSettingsView view) : base(view)
        {
        }
    }
}