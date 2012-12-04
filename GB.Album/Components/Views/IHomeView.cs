using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;

namespace GB.Album.Components.Views
{
    public interface IHomeView :IModuleView<HomeModel>
    {
        void Refresh();
    }
}
