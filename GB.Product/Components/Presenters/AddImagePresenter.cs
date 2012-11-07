using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.Product.Components.Args;
using GB.Product.Components.Entities;
using GB.Product.Components.Views;
using GB.Product.Components.Models;

namespace GB.Product.Components.Presenters
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