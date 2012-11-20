using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class AddAlbumPresenter:ModulePresenter<IAddAlbumView,AddAlbumModel>
    {
        public AddAlbumPresenter(IAddAlbumView view) : base(view)
        {

        }
    }
}