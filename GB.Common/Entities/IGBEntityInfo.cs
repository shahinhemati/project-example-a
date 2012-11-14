using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GB.Common.Entities
{
    public interface IGBEntityInfo
    {
        int AlbumID { get; set; }

        string AlbumName { get; set; }

        string ShortContent { get; set; }

        string ImageName { get; set; }

        int PortalID { get; set; }

        int Score { set; get; }
    }
}
