using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Entities;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using IB.Album.Components.Controllers;

namespace GB.Album.Components.Presenters
{
    public class EditAlbumPresenter : ModulePresenter<IEditAlbumView, EditAlbumModel>
    {
        private readonly AlbumController Controller;

        public EditAlbumPresenter(IEditAlbumView view) : base(view)
        {
            Controller = AlbumController.GetInstance();
            view.Load += LoadAlbumView;
        }

        private void LoadAlbumView(object sender, EventArgs e)
        {
            //Load Data to Model
            View.Model.Album = Controller.GetAlbum(1);
            View.SaveData += SaveAlbum;
        }

        private void SaveAlbum(object sender, EditAlbumEventArgs<AlbumInfo, bool, string> e)
        {
            //Store Model Info  to Data base 
            var albumInfo = new AlbumInfo();
            albumInfo.Title = e.Album.Title;
            Controller.AddAlbum(albumInfo);

        }
    }
}