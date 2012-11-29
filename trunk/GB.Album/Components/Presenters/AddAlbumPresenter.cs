using System;
using System.Web.UI;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Controller;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using GB.Common.Integration;

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

        void View_AddNewAlbum(object sender, Args.AlbumEventArgs<Entities.AlbumInfo,string> e)
        {
            //Insert new Album to DataBase
            string[] tags = e.Tags.Split(new[] {','});
            if(tags.Length<2)
            {
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(sender as UserControl,"Nhap tag",ModuleMessage.ModuleMessageType.RedError);
                var nt =new Notifications();
                nt.ItemNotification();
            }

            return;

            throw new NotImplementedException();
        }
    }
}