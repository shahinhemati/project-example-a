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
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using GB.Album.CommonBase;
using GB.Album.Controller;
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

            var terms = new List<Term>();
            userEnteredTerms.ForEach(t => terms.Add(Terms.CreateAndReturnTerm(t, VocabularyId)));

            //var colOpThresholds = QaSettings.GetOpThresholdCollection(Controller.GetQaPortalSettings(ModuleContext.PortalId), ModuleContext.PortalId);
            //var objTermApprove = colOpThresholds.Single(s => s.Key == Constants.OpThresholds.TermSynonymApproveCount.ToString());
            //var portalSynonyms = TermSynonymController.GetInstance().GetTermSynonyms(ModuleContext.PortalId);
            //var postTerms = new List<Term>();

            //foreach (var term in tags)
            //{
            //    var matchedSynonym = (from t in portalSynonyms where t.RelatedTermId == term.TermId && t.Score >= objTermApprove.Value select t).SingleOrDefault();
            //    if (matchedSynonym != null)
            //    {
            //        var masterTerm = Terms.GetTermById(matchedSynonym.MasterTermId, VocabularyId);
            //        // we have to make sure the masterTerm is not already in the list of terms
            //        if (!terms.Contains(masterTerm))
            //        {
            //            postTerms.Add(masterTerm);
            //            // update replaced count (for synonym)
            //            Controller.TermSynonymReplaced(matchedSynonym.RelatedTermId, ModuleContext.PortalId);
            //        }
            //        //else
            //        //{
            //        //    // show it was removed?				
            //        //}	
            //    }
            //    else
            //    {
            //        postTerms.Add(term);
            //    }
            //}

            AlbumController album = new AlbumController();
            album.AddAlbum(e.AlbumInfo, ModuleContext.TabId);

            DotNetNuke.UI.Skins.Skin.AddModuleMessage(sender as UserControl, LocalizeString("SaveSuccess"), ModuleMessage.ModuleMessageType.GreenSuccess);
            
        }
    }
}