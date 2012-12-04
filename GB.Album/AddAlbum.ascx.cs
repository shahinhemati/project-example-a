using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Client.ClientResourceManagement;
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
            if(!IsPostBack)
            {
                //teContent.Mode
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DotNetNuke.Framework.jQuery.RequestUIRegistration();
            ClientResourceManager.RegisterScript(Page, "http://ajax.microsoft.com/ajax/jquery.templates/beta1/jquery.tmpl.js");
            ClientResourceManager.RegisterScript(Page, TemplateSourceDirectory + "/js/jquery.tagify.js");
        }

        public void Btn_Click(object sender,EventArgs e)
        {
            AlbumInfo albumInfo=new AlbumInfo();
            
            albumInfo.Title = txtTitle.Text.Trim();
            albumInfo.PortalId = ModuleContext.PortalId;
            albumInfo.Body ="--";
            albumInfo.TabID = ModuleContext.TabId;
            albumInfo.Score = 1;
            albumInfo.Approved = true;
            albumInfo.Deleted = false;
            albumInfo.Closed = false;
            albumInfo.Protected = false;
            albumInfo.CreatedByUserID = ModuleContext.PortalSettings.UserId;
            albumInfo.CreatedDate = DateTime.UtcNow;

            string tags = txtTags.Text;
            //set up value from form
            var evt = new AlbumEventArgs<AlbumInfo,string>(albumInfo,tags);

            //save album 
            AddNewAlbum(this, evt);
        }

        public event EventHandler<AlbumEventArgs<AlbumInfo,string>> AddNewAlbum;
    }
}