using System;
using GB.Album.Entities;
using PetaPoco;

namespace GB.Album.Components.Entities
{
    [TableName("dnn_GBAlbum_Post")]
    [PrimaryKey("PostId")]
    [ExplicitColumns]
    public partial class AlbumInfo : Record<AlbumInfo>
    {
        [Column]
        public int PostId { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Body { get; set; }
        [Column]
        public int Bounty { get; set; }
        [Column]
        public int ParentId { get; set; }
        [Column]
        public int PortalId { get; set; }
        [Column]
        public int ViewCount { get; set; }
        [Column]
        public int Score { get; set; }
        [Column]
        public bool Approved { get; set; }
        [Column]
        public DateTime? ApprovedDate { get; set; }
        [Column]
        public bool Deleted { get; set; }
        [Column]
        public DateTime? AnswerDate { get; set; }
        [Column]
        public bool Closed { get; set; }
        [Column]
        public DateTime? ClosedDate { get; set; }
        [Column]
        public bool Protected { get; set; }
        [Column]
        public DateTime? ProtectedDate { get; set; }
        [Column]
        public int CreatedUserId { get; set; }
        [Column]
        public DateTime CreatedDate { get; set; }
        [Column]
        public int LastModifiedUserId { get; set; }
        [Column]
        public DateTime? LastModifiedDate { get; set; }

    }
}