using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Album.Components.Args
{
    public class EditAlbumEventArgs<TAlbumInfo,TNotify,TTags> :EventArgs
    {
        public TAlbumInfo Album { set; get; }
        public TNotify Notify { set; get; }
        public TTags Tags { set; get; }

        public EditAlbumEventArgs(TAlbumInfo albumInfo,TNotify notify,TTags tags)
        {
            Album = albumInfo;
            Notify = notify;
            Tags = tags;
        }
    }
}