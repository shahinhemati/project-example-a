using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IB.Common.Entities;
using PetaPoco;


namespace GB.News.Components.Entities
{
    [TableName("CV_Album")]
    [PrimaryKey("AlbumID")]
    [ExplicitColumns]
    public partial class AlbumInfo : SqlServerDb.Record<AlbumInfo>
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
        public int ContentItemId { get; set; }
        
    }
}