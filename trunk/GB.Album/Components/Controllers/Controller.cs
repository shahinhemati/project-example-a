﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Controller;
using IB.Album.Components.Controllers;

namespace GB.Common.Controllers
{
    public class Controller : CommonController
    {
        public AlbumController AlbumCtr
        {
            get
            {
                return new AlbumController();
            }
        }


        public AlbumImageController ImageCtr
        {
            get
            {
                return new AlbumImageController();
            }
        }

    }
}
