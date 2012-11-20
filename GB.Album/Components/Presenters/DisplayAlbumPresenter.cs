using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class DisplayAlbumPresenter:ModulePresenter<IDisplayAlbumView,DisplayAlbumModel>
    {
        public DisplayAlbumPresenter(IDisplayAlbumView view) : base(view)
        {
        }
    }
}