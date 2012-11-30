using GB.Album.Entities;
using PetaPoco;


namespace GB.Album.Components.Entities
{
    [TableName("dnn_GBAlbum_Post")]
    [PrimaryKey("PostId")]
    [ExplicitColumns]
    public partial class AlbumInfo : Record<AlbumInfo>, IGBEntityInfo
    {
        [Column("PostId")]
        public int EntityId { get; set; }
        [Column("Title")]
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