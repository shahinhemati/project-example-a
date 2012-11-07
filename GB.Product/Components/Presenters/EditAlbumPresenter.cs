using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Entities;
using GB.Album.Components.Views;
using GB.Album.Components.Models;
using IB.Album.Components.Controllers;

namespace GB.Album.Components.Presenters
{
    public class EditAlbumPresenter:ModulePresenter<IEditAlbumView,EditAlbumModel>
    {
        private AlbumController Controller;

        public EditAlbumPresenter(IEditAlbumView view) : base(view)
        {
            Controller = AlbumController.Factory.GetInstance();
            view.Load+=LoadAlbumView;
        }

        private void LoadAlbumView(object sender, EventArgs e)
        {
            //Load Data to Model
            View.Model.Album = Controller.GetAlbum(1);
            View.SaveData+=SaveAlbum;
        }

        private void SaveAlbum(object sender, EditAlbumEventArgs<AlbumInfo, bool, string> e)
        {
            //Store Model Info  to Data base 

            AlbumInfo albumInfo=new AlbumInfo();
            albumInfo.AlbumName = e.Album.AlbumName;

            Controller.AddAlbum(albumInfo);

            throw new NotImplementedException();
        }
    }
}