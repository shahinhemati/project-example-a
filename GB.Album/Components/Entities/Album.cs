﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using sqlserver;

namespace GB.Album.Components.Entities
{
    [TableName("CV_Album")]
    [PrimaryKey("AlbumID")]
    [ExplicitColumns]
    public partial class Album : SqlServerDb.Record<Album>
    {
        [Column]
        public int AlbumID { get; set; }
        [Column]
        public string AlbumName { get; set; }
        [Column]
        public string ShortContent { get; set; }
        [Column]
        public string ImageName { get; set; }
        [Column]
        public int? PortalID { get; set; }
        [Column]
        public int? ContentID { get; set; }
        
    }
}