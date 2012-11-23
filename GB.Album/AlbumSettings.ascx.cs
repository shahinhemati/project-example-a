using System;
using System.Collections;
using System.Collections.Generic;
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
using GB.Album.Components.Common;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using GB.Common.Entities;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(AlbumSettingsPresenter))]
    public partial class AlbumSettings : SettingsView<AlbumSettingsModel>,IAlbumSettingsView
    {
        protected void Page_Load(object sender, EventArgs e){}

        protected void Click_SaveSetting(object sender, EventArgs e)
        {
            IList<SettingInfo> listSett = new List<SettingInfo>();
            //assing value to list
            listSett.Add(new SettingInfo(AlbumCommon.HomeTermsCacheKey,txtAnswerEmailTemplate.Text));

            addSetting(sender,new AlbumSettingsEventArgs<IList<SettingInfo>>(listSett));
          //  OnSaveSettings(sender, new AlbumSettingsEventArgs<IList<SettingInfo>>(listSett));
        }
        
        public event EventHandler<AlbumSettingsEventArgs<IList<SettingInfo>>> addSetting;
    }
}