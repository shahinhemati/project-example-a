using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Album.Components.Args
{
    public class AlbumSettingsEventArgs<TListSetting>:EventArgs
    {
        public TListSetting ListSetting { set; get; }
        

        public AlbumSettingsEventArgs(TListSetting ltSetting)
        {
            ListSetting = ltSetting;
        }
    }
}