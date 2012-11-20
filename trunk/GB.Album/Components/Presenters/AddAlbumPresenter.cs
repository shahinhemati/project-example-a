using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class AddAlbumPresenter:ModulePresenter<IAddAlbumView,AddAlbumModel>
    {
        public AddAlbumPresenter(IAddAlbumView view) : base(view)
        {
            view.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            View.AddNewAlbum += new EventHandler<Args.AlbumEventArgs<Entities.AlbumInfo>>(View_AddNewAlbum);
        }

        void View_AddNewAlbum(object sender, Args.AlbumEventArgs<Entities.AlbumInfo> e)
        {
            //Insert new Album to DataBase

            throw new NotImplementedException();
        }
    }
}