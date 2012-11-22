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
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(AlbumSettingsPresenter))]
    public partial class AlbumSettings : SettingsView<AlbumSettingsModel>,IAlbumSettingsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public event EventHandler<AlbumSettingsEventArgs<string,string>> addSetting;

        protected void Click_SaveSetting(object sender, EventArgs e)
        {
            addSetting(sender,new AlbumSettingsEventArgs<string,string>("key_s",this.txtInput.Text));
        }
    }
}