using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Album.Components.Args
{
    public class AlbumEventArgs<TBody,TTags>:EventArgs
    {
        public TBody AlbumInfo { set; get; }
        public TTags Tags { set; get; }
        public AlbumEventArgs(TBody tBody,TTags tags)
        {
            AlbumInfo = tBody;
            Tags = tags;
        }
    }
}