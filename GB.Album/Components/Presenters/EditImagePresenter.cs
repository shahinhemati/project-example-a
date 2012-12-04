﻿using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Views;

namespace GB.Album.Components.Presenters
{
    public class EditImagePresenter:ModulePresenter<IEditImageView,EditImageModel>
    {
        public EditImagePresenter(IEditImageView view) : base(view)
        {
            
        }
    }
}