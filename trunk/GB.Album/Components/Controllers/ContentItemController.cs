using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Content;
using DotNetNuke.Entities.Content.Common;
using GB.Album.CommonBase;
using GB.Album.Components.Entities;
using GB.Album.Entities;
using GB.Album.Integration;

namespace GB.Album.Controllers
{
    public class ContentItemController
    {

        /// <summary>
        /// This should only run after the Post exists in the data store. 
        /// </summary>
        /// <returns>The newly created ContentItemID from the data store.</returns>
        /// <remarks>This is for the first question in the thread. Not for replies or items with ParentID > 0.</remarks>
        public ContentItem CreateContentItem(AlbumInfo objPost, int tabId)
        {
            var typeController = new ContentTypeController();
            var colContentTypes = (from t in typeController.GetContentTypes() where t.ContentType == Constants.ContentTypeName select t);
            int contentTypeID;

            if (colContentTypes.Count() > 0)
            {
                var contentType = colContentTypes.Single();
                contentTypeID = contentType == null ? CreateContentType() : contentType.ContentTypeId;
            }
            else
            {
                contentTypeID = CreateContentType();
            }

            var objContent = new ContentItem
            {
                Content = objPost.Body,
                ContentTypeId = contentTypeID,
                Indexed = false,
                ContentKey = "view=" + Constants.PageScope.Question.ToString().ToLower() + "&id=" + objPost.PostId,
                ModuleID = objPost.ModuleID,
                TabID = tabId
            };

            objContent.ContentItemId = Util.GetContentController().AddContentItem(objContent);

            // Add Terms
            var cntTerm = new Terms();
            cntTerm.ManageQuestionTerms(objPost, objContent);

            return objContent;
        }

        /// <summary>
        /// This is used to update the content in the ContentItems table. Should be called when a question is updated.
        /// </summary>
        public void UpdateContentItem(AlbumInfo objAlbum, int tabId)
        {
            var objContent = Util.GetContentController().GetContentItem(objAlbum.ContentItemId);

            if (objContent == null) return;
            objContent.Content = objAlbum.Body;
            objContent.TabID = tabId;
            objContent.ContentKey = "view=" + Constants.PageScope.Question.ToString().ToLower() + "&id=" + objAlbum.PostId;

            Util.GetContentController().UpdateContentItem(objContent);

            // Update Terms
            var cntTerm = new Terms();
            cntTerm.ManageQuestionTerms(objAlbum, objContent);
        }

        /// <summary>
        /// This removes a content item associated with a question/thread from the data store. Should run every time an entire thread is deleted.
        /// </summary>
        /// <param name="contentItemID"></param>
        public void DeleteContentItem(int contentItemID)
        {
            if (contentItemID <= Null.NullInteger) return;
            var objContent = Util.GetContentController().GetContentItem(contentItemID);
            if (objContent == null) return;

            // remove any metadata/terms associated first (perhaps we should just rely on ContentItem cascade delete here?)
            var cntTerms = new Terms();
            cntTerms.RemoveQuestionTerms(objContent);

            Util.GetContentController().DeleteContentItem(objContent);
        }

        /// <summary>
        /// This is used to determine the ContentTypeID (part of the Core API) based on this module's content type. If the content type doesn't exist yet for the module, it is created.
        /// </summary>
        /// <returns>The primary key value (ContentTypeID) from the core API's Content Types table.</returns>
        public static int GetContentTypeID()
        {
            var typeController = new ContentTypeController();
            var colContentTypes = (from t in typeController.GetContentTypes() where t.ContentType == Constants.ContentTypeName select t);
            int contentTypeId;

            if (colContentTypes.Count() > 0)
            {
                var contentType = colContentTypes.Single();
                contentTypeId = contentType == null ? CreateContentType() : contentType.ContentTypeId;
            }
            else
            {
                contentTypeId = CreateContentType();
            }

            return contentTypeId;
        }

        #region Private Methods

        /// <summary>
        /// Creates a Content Type (for taxonomy) in the data store.
        /// </summary>
        /// <returns>The primary key value of the new ContentType.</returns>
        private static int CreateContentType()
        {
            var typeController = new ContentTypeController();
            var objContentType = new ContentType { ContentType = Constants.ContentTypeName };

            return typeController.AddContentType(objContentType);
        }

        #endregion

        public IEnumerable<ContentItem> GetContentItemsByTypeAndCreated(int contentTypeId, DateTime lastRunDate, DateTime currentRunDate)
        {
            throw new NotImplementedException();
        }
    }
}