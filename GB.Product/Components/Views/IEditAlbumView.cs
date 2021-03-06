﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Web.Mvp;
using GB.Product.Components.Args;
using GB.Product.Components.Models;
using GB.Product.Components.Entities;

namespace GB.Product.Components.Views
{
    public interface IEditAlbumView:IModuleView<EditAlbumModel>
    {
        void Refresh();
        event EventHandler<EditAlbumEventArgs<AlbumInfo,bool,string>> SaveData;
    }
}
