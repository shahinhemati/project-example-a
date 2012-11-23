using System;
using System.Collections.Generic;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Common;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using GB.Common.Entities;

namespace GB.Album.Components.Presenters
{

    public class AlbumSettingsPresenter : ModuleSettingsPresenter<IAlbumSettingsView, AlbumSettingsModel>
    {
        public AlbumSettingsPresenter(IAlbumSettingsView view)
            : base(view)
        {
            view.addSetting += new EventHandler<AlbumSettingsEventArgs<IList<SettingInfo>>>(view_addSetting);
          
            //view.OnSaveSettings+=new EventHandler(view_OnSaveSettings);
        }

        void view_addSetting(object sender, AlbumSettingsEventArgs<IList<SettingInfo>> e)
        {
            IList<SettingInfo> settingInfo = e.ListSetting;

            //foreach (SettingInfo info in settingInfo)
            //{
            //    this.Settings.Add(info.Key, info.Value);
            //}

            Settings.Add("key1","value1");

            this.SaveSettings();
        }
    }
}