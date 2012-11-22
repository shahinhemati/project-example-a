using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{

    public class AlbumSettingsPresenter : ModuleSettingsPresenter<IAlbumSettingsView, AlbumSettingsModel>
    {
        public AlbumSettingsPresenter(IAlbumSettingsView view): base(view)
        {
            view.addSetting += new EventHandler<AlbumSettingsEventArgs<string,string>>(view_addSetting);
        }

        void view_addSetting(object sender, AlbumSettingsEventArgs<string,string> e)
        {
            this.Settings.Add(e.Key,e.Value);
            this.SaveSettings();
        }
    }
}