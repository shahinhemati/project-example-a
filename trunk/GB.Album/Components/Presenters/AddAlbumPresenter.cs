using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Content.Taxonomy;
using DotNetNuke.Security;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Common;
using GB.Album.Components.Controller;
using GB.Album.Components.Controllers;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using GB.Album.CommonBase;
using GB.Album.Controller;
using GB.Album.Controllers;
using GB.Album.Integration;
using IB.Album.Components.Controllers;

namespace GB.Album.Components.Presenters
{
    public class AddAlbumPresenter:ModulePresenter<IAddAlbumView,AddAlbumModel>
    {
        #region innit value 

        private FileAlbumController fileAlbum=new FileAlbumController();

        #endregion

        private string Tag
        {
            
            get
            {
                var tag = Null.NullString;
                if (!String.IsNullOrEmpty(Request.Params["term"])) tag = (Request.Params["term"]);
                var objSecurity = new PortalSecurity();

                return objSecurity.InputFilter(tag, PortalSecurity.FilterFlag.NoSQL);
            }
        }

        private int VocabularyId
        {
            get { return 1; }
        }

        public AddAlbumPresenter(IAddAlbumView view) : base(view)
        {
            view.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            View.AddNewAlbum += new EventHandler<Args.AlbumEventArgs<Entities.AlbumInfo,string>>(View_AddNewAlbum);
        }

        /// <summary>
        /// Add New album
        /// 1 add tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_AddNewAlbum(object sender, Args.AlbumEventArgs<Entities.AlbumInfo,string> e)
        {
            //Insert new Album to DataBase
            string[] tags = e.Tags.Split(new[] {','});
            if(tags.Length<2)
            {
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(sender as UserControl,LocalizeString("RequiredTagInput"),ModuleMessage.ModuleMessageType.RedError);
                return;
            }
            
            var userEnteredTerms = e.Tags.Split(',')
                    .Where(s => s != string.Empty)
                    .Select(p => p.Trim())
                    .Distinct().ToList();

            foreach (var s in userEnteredTerms)
            {
                if (!Utils.ContainsSpecialCharacter(s)) continue;
                var msg = Localization.GetString("UnAllowedCharacters", LocalResourceFile);
                msg = msg.Replace("{0}", Constants.DisallowedCharacters);
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(sender as UserControl, msg, ModuleMessage.ModuleMessageType.RedError);
                return;
            }

            try
            {
                var terms = new List<Term>();
                userEnteredTerms.ForEach(t => terms.Add(Terms.CreateAndReturnTerm(t, VocabularyId)));
                AlbumController album = new AlbumController();
                album.AddAlbum(e.AlbumInfo, ModuleContext.TabId);

                DotNetNuke.UI.Skins.Skin.AddModuleMessage(sender as UserControl, "Thanh công lưu", ModuleMessage.ModuleMessageType.GreenSuccess);
            }catch(Exception ex)
            {
                ProcessModuleLoadException(ex);
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(sender as UserControl, LocalizeString("SaveSuccess"), ModuleMessage.ModuleMessageType.RedError);
            }
        }
    }
}