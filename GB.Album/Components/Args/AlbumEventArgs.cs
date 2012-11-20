using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Album.Components.Args
{
    public class AlbumEventArgs<TBody>:EventArgs
    {
        public TBody AlbumInfo { set; get; }
        public AlbumEventArgs(TBody tBody)
        {
            AlbumInfo = tBody;
        }
    }
}