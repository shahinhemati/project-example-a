using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.News.Components.Args;
using GB.News.Components.Entities;
using GB.News.Components.Views;
using GB.News.Components.Models;

namespace GB.News.Components.Presenters
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