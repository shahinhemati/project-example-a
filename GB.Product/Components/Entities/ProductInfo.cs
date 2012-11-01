using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DotNetNuke.Entities.Content;
using DotNetNuke.Services.Tokens;

namespace IB.Common
{
    public class ProductInfo : ContentItem,IPropertyAccess
    {

        #region Field set

        private int _id;
        private DateTime _createDate;
        private string _title;
        private string _shortContent;
        private string _content;
        private string _imageOrgUrl;
        private string _imageThumUrl;
        private string _price;
        private string _url;

        #endregion

        #region Contructor

        public ProductInfo()
        {


        }

        public ProductInfo(int id, DateTime date, string title, string shortcontent, string content, string imageOrgUrl, string imageThumUrl, string price, string url)
        {
            _id = id;
            _createDate = date;
            _title = title;
            _shortContent = shortcontent;
            _content = content;
            _imageOrgUrl = imageOrgUrl;
            _imageThumUrl = imageThumUrl;
            _price = price;
            Url = url;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string ShortContent
        {
            get { return _shortContent; }
            set { _shortContent = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public string Price
        {
            get { return _price; }
            set { _price = value; }
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

        public string ImageOrgUrl
        {
            get { return _imageOrgUrl; }
            set { _imageOrgUrl = value; }
        }

        public string ImageThumUrl
        {
            get { return _imageThumUrl; }
            set { _imageThumUrl = value; }
        }

        public string GetProperty(string propertyName, string format, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, Scope accessLevel, ref bool propertyNotFound)
        {
            propertyNotFound = false;
            switch (propertyName.ToLower())
            {
                case "id":
                    return PropertyAccess.FormatString(_id.ToString(), format);
                case "title":
                    return PropertyAccess.FormatString(_title, format);
                case "shortcontent":
                    return PropertyAccess.FormatString(_shortContent, format);
                case "content":
                    return PropertyAccess.FormatString(_content, format);
                case "datecreated":
                    return _createDate.ToString(String.IsNullOrEmpty(format) ? "d" : format, formatProvider);
                case "imageorgurl":
                    return PropertyAccess.FormatString(_imageOrgUrl, format);
                case "imagethumurl":
                    return PropertyAccess.FormatString(_imageThumUrl, format);
                case "price":
                    return PropertyAccess.FormatString(_price, format);
                case "url":
                    return PropertyAccess.FormatString(Url, format);
                default:
                    propertyNotFound = true;
                    return string.Empty;
            }
        }

        #endregion
    }
}
