using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Album.Components.Args
{
    public class AlbumSettingsEventArgs<TKey,TValue>:EventArgs
    {
        public TKey Key { set; get; }
        public TValue Value { set; get; }

        public AlbumSettingsEventArgs(TKey key,TValue value)
        {
            Key = key;
            Value = Value;
        }
    }
}