using System;
using System.Collections.Generic;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Args;
using GB.Album.Components.Common;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using GB.Album.Entities;

namespace GB.Album.Components.Presenters
{

    public class AlbumSettingsPresenter : ModulePresenter<IAlbumSettingsView, AlbumSettingsModel>
    {
        public AlbumSettingsPresenter(IAlbumSettingsView view)
            : base(view)
        {
            this.View.Load += Load;
            this.View.GetSettings += GetSettings;
            this.View.SaveSettings += SaveSettings;
        }

        private void Load(object sender, EventArgs e)
        {
            // page load equivalent

        }

        private void GetSettings(object sender, EventArgs eventArgs)
        {
            View.Model.Description = GetSetting("Description");
            View.Model.Title = GetSetting("Title");

            #region Assign ModuleSetting to Model
            


            #endregion

            #region Assign PortalSetting To Model
            
            #endregion

        }

        private void SaveSettings(object sender, EventArgs eventArgs)
        {
            var moduleController = new ModuleController();
            moduleController.UpdateModuleSetting(this.ModuleId, "Description", this.View.Model.Description);
            moduleController.UpdateModuleSetting(this.ModuleId, "Title", this.View.Model.Title);

            #region Save ModuleSetting 

            #endregion

            #region Save PortalSetting 

            #endregion
        }

        private string GetSetting(string settingKey)
        {
            return this.Settings.ContainsKey(settingKey) ? this.Settings[settingKey] : string.Empty;
        }
    }
}