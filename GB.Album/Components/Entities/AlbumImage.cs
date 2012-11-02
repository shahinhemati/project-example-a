﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using sqlserver;

namespace GB.Album.Components.Entities
{
    [TableName("CV_ImageAlbum")]
    [PrimaryKey("ImageID")]
    [ExplicitColumns]
    public partial class AlbumImage : SqlServerDb.Record<AlbumImage>
    {
        [Column]
        public int ImageID { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public int? AlbumID { get; set; }
        [Column]
        public string ImageName { get; set; }
    }
}