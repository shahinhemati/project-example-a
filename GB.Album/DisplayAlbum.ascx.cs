using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(DisplayAlbumModel))]
    public partial class DisplayAlbum : ModuleView<DisplayAlbumModel>,IDisplayAlbumView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}