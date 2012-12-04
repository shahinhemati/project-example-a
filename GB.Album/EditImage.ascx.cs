using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(EditImagePresenter))]
    public partial class EditImage : ModuleView<EditImageModel>,IEditImageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}