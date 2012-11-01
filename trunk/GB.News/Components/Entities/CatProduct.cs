using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using sqlserver;

namespace IB.Common.Entities
{
    [TableName("CV_CatProduct")]
    [PrimaryKey("CatID")]
    [ExplicitColumns]
    public partial class CV_CatProduct : SqlServerDb.Record<CV_CatProduct>
    {
        [Column]
        public int CatID { get; set; }
        [Column]
        public string CatName { get; set; }
        [Column]
        public int? ParentID { get; set; }
        [Column]
        public string ImageName { get; set; }
        [Column]
        public int? PortalID { get; set; }
        [Column]
        public string CatPath { get; set; }
    }
}