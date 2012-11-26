using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class AddAlbumPresenter:ModulePresenter<IAddAlbumView,AddAlbumModel>
    {

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

        void View_AddNewAlbum(object sender, Args.AlbumEventArgs<Entities.AlbumInfo,string> e)
        {
            //Insert new Album to DataBase
            
            throw new NotImplementedException();
        }
    }
}