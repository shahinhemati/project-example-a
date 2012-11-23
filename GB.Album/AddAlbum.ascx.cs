using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Entities;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(AddAlbumPresenter))]
    public partial class AddAlbum : ModuleView<AddAlbumModel>, IAddAlbumView
    {
        #region Control

        protected  DotNetNuke.UI.UserControls.TextEditor teShortContent;
        protected DotNetNuke.UI.UserControls.TextEditor teContent;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Btn_Click(object sender,EventArgs e)
        {
            AlbumInfo albumInfo=new AlbumInfo();
            albumInfo.Title = txtTitle.Text.Trim();
            albumInfo.ShortContent = teShortContent.Text;
            albumInfo.Content = teContent.Text;

            //set up value from form
            var evt = new AlbumEventArgs<AlbumInfo>(albumInfo);

            //save album 
            AddNewAlbum(sender, evt);
        }

        public event EventHandler<AlbumEventArgs<AlbumInfo>> AddNewAlbum;
    }
}