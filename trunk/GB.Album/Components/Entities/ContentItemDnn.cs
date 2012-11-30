using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace GB.Album.Entities
{
    public class ContentItemDnn
    {
        [ResultColumn]
        public string Content { set; get; }

        [ResultColumn]
        public int ContentTypeID { set; get; }

        [ResultColumn]
        public int TabID { set; get; }

        [ResultColumn]
        public int ModuleID { set; get; }

        [ResultColumn]
        public string ContentKey { set; get; }

        [ResultColumn]
        public bool Indexed { set; get; }

        [ResultColumn]
        public int CreatedByUserID { set; get; }

        [ResultColumn]
        public DateTime CreatedOnDate { set; get; }

        [ResultColumn]
        public int LastModifiedByUserID { set; get; }

        [ResultColumn]
        public DateTime LastModifiedOnDate { set; get; }

        [ResultColumn]
        public int ContentItemId { set; get; }
    }
}