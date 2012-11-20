using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(AddAlbumPresenter))]
    public partial class AddAlbum : ModuleView<AddAlbumModel>, IAddAlbumView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}