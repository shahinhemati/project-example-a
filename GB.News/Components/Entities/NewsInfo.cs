using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DotNetNuke.Entities.Content;
using DotNetNuke.Services.Tokens;

namespace IB.Common
{
    public class NewsInfo : ContentItem, IPropertyAccess
    {

        #region private field

        private int _newsId;
        private string _title;
        private DateTime _createdDate;
        private string _shortContent;
        private string _content;
        private string _imageName;
        private string _url;

        #endregion

        #region Contructor

        public NewsInfo(int id,string title,DateTime date,string shortcontent,string content,string imagename,string url)
        {

            _newsId = id;
            _title = title;
            _createdDate = date;
            _shortContent = shortcontent;
            _content = content;
            _imageName = imagename;
        }

        public NewsInfo()
        {
            
        }
        #endregion

        #region Properties
        public int NewsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
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

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
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
                case "id":   
                    return PropertyAccess.FormatString(_newsId.ToString(), format);
                case "title":
                    return PropertyAccess.FormatString(_title, format);
                case "shortcontent":
                    return PropertyAccess.FormatString(_shortContent, format);
                case "content":
                    return PropertyAccess.FormatString(_content, format);
                case "datecreated":
                    return _createdDate.ToString(String.IsNullOrEmpty(format) ? "d" : format, formatProvider);
                case "image":
                    return PropertyAccess.FormatString(_imageName, format);
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
