using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Controllers;
using GB.Common.Entities;
using PetaPoco;


namespace GB.Album.Components.Entities
{
    [TableName("CV_Album")]
    [PrimaryKey("AlbumID")]
    [ExplicitColumns]
    public partial class AlbumInfo : Record<AlbumInfo>, IGBEntityInfo
    {
        [Column("AlbumID")]
        public int EntityId { get; set; }
        [Column("AlbumName")]
        public string Title { get; set; }
        [Column]
        public string ShortContent { get; set; }
        [Column]
        public string ImageName { get; set; }
        [Column("PortalID")]
        public int PortalID { get; set; }
        [Column("Score")]
        public int Score { set; get; }
    }
}