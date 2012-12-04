using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Entities;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using WebFormsMvp;
using GB.Album.Components.Views;


namespace IB.Album
{
    [PresenterBinding(typeof(EditAlbumPresenter))]
    public partial class EditAlbum : ModuleView<EditAlbumModel>,IEditAlbumView
    {
        public void Refresh()
        {
            //load data
        }

        public event EventHandler<EditAlbumEventArgs<AlbumInfo, bool, string>> SaveData;

        protected void SaveAlbum_Click(object sender, EventArgs e)
        {
            AlbumInfo albumInfo=new AlbumInfo()
                                    {
                                        //Title =  txtName.Text
                                    };
            SaveData(sender,new EditAlbumEventArgs<AlbumInfo, bool, string>(albumInfo,true,"tag1,tag2"));
        }

        protected void CmdSaveClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void CmdDeleteClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}   