using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.SlideShow.Components.Args;
using GB.SlideShow.Components.Entities;
using GB.SlideShow.Components.Views;
using GB.SlideShow.Components.Models;

namespace GB.SlideShow.Components.Presenters
{
    public class AddImagePresenter : ModulePresenter<IAddImageView,AddImageModel>
    {
        public AddImagePresenter(IAddImageView view) : base(view)
        {
            view.Load += LoadView;
        }

        private void LoadView(object sender, EventArgs e)
        {
            //Load Data to Model in the view
            //Save Data
            View.SaveData += SaveData;
        }

        private void SaveData(object sender, AddImageEventArgs<AlbumInfo, bool, string> e)
        {
            throw new NotImplementedException();
        }
    }
    
}