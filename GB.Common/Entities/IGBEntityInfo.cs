using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GB.Common.Entities
{
    public interface IGBEntityInfo
    {
        int EntityId { get; set; }

        string Title { get; set; }

        string ShortContent { get; set; }

        string ImageName { get; set; }

        int PortalID { get; set; }

        int Score { set; get; }

        int CreatedByUserID { set; get; }

        int ModuleID { set; get; }

        int ContentItemId { set; get; }
        int TabID { set; get; }

        DateTime CreatedOnDate { get; set; }
        DateTime LastModifiedOnDate { get; set; }
    }
}
