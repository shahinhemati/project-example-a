using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Album.Components.Args
{
    public class AddImageEventArgs<TImageInfo,TNotify,TTags>:EventArgs
    {
        public TImageInfo ImageInfo { set; get; }
        public TNotify Notify { set; get; }
        public TTags Tags { set; get; }

        public AddImageEventArgs(TImageInfo imageInfo,TNotify notify,TTags tags)
        {
            ImageInfo = imageInfo;
            Notify = notify;
            Tags = tags;
        }


    }
}