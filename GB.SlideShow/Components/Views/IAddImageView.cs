using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;
using GB.SlideShow.Components.Args;
using GB.SlideShow.Components.Models;
using GB.SlideShow.Components.Entities;

namespace GB.SlideShow.Components.Views
{
    public interface IAddImageView :IModuleView<AddImageModel>
    {
        void Refresh();
        event EventHandler<AddImageEventArgs<AlbumInfo, bool, string>> SaveData;
    }
}
