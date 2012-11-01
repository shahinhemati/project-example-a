using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DotNetNuke.Services.Tokens;
using PetaPoco;

namespace IB.Common
{
    [TableName("CV_CatProduct")]
    [PrimaryKey("CatID")]
    [ExplicitColumns]
    public class CategoryInfo : IPropertyAccess
    {
        #region Column
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
        #endregion

        #region set get properties
        private int _catId;
        private string _catName;
        private string _imageName;
        private int _parentId;
        private string _url;
        #endregion

        #region Contructor
        public CategoryInfo(int id, string name, string catname, string image, int parentid, string url)
        {
            _catId = id;
            _catName = catname;
            _imageName = image;
            _parentId = parentid;
            Url = url;
        }

        public CategoryInfo()
        {

        }
        #endregion

        #region Properties

        public int CatId
        {
            get { return _catId; }
            set { _catId = value; }
        }

        public string CatName
        {
            get { return _catName; }
            set { _catName = value; }
        }

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        #endregion

        #region IPropertyAccess Members

        public CacheLevel Cacheability
        {
            get { return CacheLevel.fullyCacheable; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }


        public string GetProperty(string propertyName, string format, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, Scope accessLevel, ref bool propertyNotFound)
        {
            propertyNotFound = false;
            switch (propertyName.ToLower())
            {
                case "name":
                    return PropertyAccess.FormatString(_catName, format);
                case "id":
                    return PropertyAccess.FormatString(_catId.ToString(), format);
                case "img":
                    return PropertyAccess.FormatString(_imageName.ToString(), format);
                case "parentid":
                    return PropertyAccess.FormatString(_parentId.ToString(), format);
                case "url":
                    return PropertyAccess.FormatString(Url.ToString(), format);
                default:
                    propertyNotFound = true;
                    return string.Empty;
            }
        }

        #endregion
    }
}
