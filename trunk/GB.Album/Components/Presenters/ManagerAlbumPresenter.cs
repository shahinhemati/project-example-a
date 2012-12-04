using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class ManagerAlbumPresenter:ModulePresenter<IManagerAlbumView,ManagerAlbumModel>
    {
        public ManagerAlbumPresenter(IManagerAlbumView view) : base(view)
        {
            view.Delete += new System.EventHandler(view_Delete);
            view.Load += new System.EventHandler(view_Load);
        }

        void view_Load(object sender, System.EventArgs e)
        {
           
        }

        void view_Delete(object sender, System.EventArgs e)
        {
           
        }
    }
}