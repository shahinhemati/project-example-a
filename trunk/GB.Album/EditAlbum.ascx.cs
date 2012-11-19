using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Entities;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Common.Entities;
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