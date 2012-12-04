using System;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using GB.Album.Components.Views;
using WebFormsMvp;

namespace GB.Album
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class Home : ModuleView<HomeModel>,IHomeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

    }
}