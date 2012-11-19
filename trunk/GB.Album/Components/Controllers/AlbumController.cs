//
// GB (Globalization Bussiness)
// Copyright (c) 2002-2012
// by CuongVV
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//


using GB.Album.Entities;

namespace IB.Album.Components.Controllers
{


    using System;
    using System.Collections.Generic;
    using DotNetNuke.Common.Utilities;
    using GB.Album.Components.Entities;
    using GB.Common.CommonBase;
    using GB.Common.Controllers;
    using GB.Common.Entities;
    using GB.Common.Integration;

    public class AlbumController
    {
        #region Create new Instance
        public interface IFactory
        {
            AlbumController GetInstance();
        }

        private static IFactory Factory { get; set; }
        public static AlbumController GetInstance(string prefixCache)
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new AlbumController();
        }

        [ThreadStatic]
        static AlbumController _instance;
        #endregion

        #region CRUD Album
        /// <summary>
        /// Add Album To DataBase
        /// I - Steps :
        /// 1 . first : Add ContentItem 
        /// 2 . Second :Add Album to DataBase
        /// 3 . Store Album into Cache
        /// </summary>
        /// <param name="album"></param>
        /// <returns>
        /// Id of album
        /// </returns>
        public int AddAlbum(AlbumInfo album, int tabid)
        {
            int rt = -1;

            // # 1 Save ContentItem to DataBase
            Content content = new Content();
            content.CreateContentItem(album, tabid);

            // # 2 Store Album to DataBase
            rt = ((AlbumInfo)SqlServerDb.GetInstance().Insert(album)).EntityId;

            // # 3 Store Cache

            return rt;
        }

        #endregion

        #region Private functions ContentItem and so many
        #region Private Methods

        /// <summary>
        /// This completes the things necessary for creating a content item in the data store. 
        /// </summary>
        /// <param name="objPost">The PostInfo entity we just created in the data store.</param>
        /// <param name="tabId">The page we will associate with our content item.</param>
        /// <returns>The ContentItemId primary key created in the Core ContentItems table.</returns>
        private static int CompleteQuestionCreation(AlbumInfo objPost, int tabId)
        {
            var cntTaxonomy = new Content();
            var objContentItem = cntTaxonomy.CreateContentItem(objPost, tabId);
            return objContentItem.ContentItemId;
        }

        /// <summary>
        /// Handles any content item/taxonomy updates, then deals with cache clearing. 
        /// </summary>
        /// <param name="objAlbum"></param>
        /// <param name="tabId"></param>
        private static void CompleteQuestionUpdate(AlbumInfo objAlbum, int tabId)
        {
            var cntTaxonomy = new Content();
            cntTaxonomy.UpdateContentItem(objAlbum, tabId);

            DataCache.RemoveCache(Constants.ModuleCacheKey + Constants.HomeQuestionsCacheKey + objAlbum.ModuleID);

            //if (objAlbum.ParentId >= 1) return;
            DataCache.RemoveCache(Constants.ModuleCacheKey + Constants.HomeTermsCacheKey + objAlbum.ModuleID);
            DataCache.RemoveCache(Constants.ModuleCacheKey + Constants.ModuleTermsCacheKey + objAlbum.ModuleID);
            DataCache.RemoveCache(Constants.ModuleCacheKey + Constants.ModuleQuestionsCacheKey + objAlbum.ModuleID);
            DataCache.RemoveCache(Constants.ModuleCacheKey + Constants.ContentTermsCacheKey + objAlbum.ContentItemId);

        }

        /// <summary>
        /// Cleanup any taxonomy related items.
        /// </summary>
        /// <param name="contentItemID"></param>
        private static void CompleteQuestionDelete(int contentItemID)
        {
            var cntTaxonomy = new Content();
            cntTaxonomy.DeleteContentItem(contentItemID);
        }

        #endregion
        #endregion

        #region GetData Relative about albums

        /// <summary>
        /// Get Album
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlbumInfo GetAlbum(int id)
        {
            //todo 1 Get From Cache
            //todo 2 If exist in Cache then get from database and store to cache

            return null;
        }

        #endregion

        internal AlbumInfo GetAlbum(int questionId, int p)
        {
            SqlServerDb.GetInstance().SingleOrDefault<AlbumInfo>("select * from dnn_GBAlbum where id=@0",questionId);
            SqlServerDb.GetInstance().Query<AlbumInfo>(PetaPoco.Sql.Builder.Append("select * from dnn_GBAlbum").Append("where id =@0",questionId));



            throw new NotImplementedException();
        }

        public IEnumerable<AlbumInfo> GetSitemapQuestions(int portalId)
        {
            throw new NotImplementedException();
        }

        public AlbumInfo GetQuestionByContentItem(object contentItemId)
        {
            throw new NotImplementedException();
        }

        internal object GetAnswersByDate(DateTime lastRunDate, DateTime currentRunDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetUserSubscriptions(int portalId, int userId)
        {
            throw new NotImplementedException();
        }

        public int AddSubscription(SubscriptionInfo objSub)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubscription(int portalId, int id)
        {
            throw new NotImplementedException();
        }

        internal static AlbumController GetInstance()
        {
            throw new NotImplementedException();
        }

        internal AlbumInfo GetPost(int CurrentPostID, int p)
        {
            throw new NotImplementedException();
        }

        public List<QuestionServiceInfo> SearchQuestionTitles(int moduleId, string searchPhrase)
        {
            throw new NotImplementedException();
        }

        public List<AlbumInfo> GetAnswers(int postId, int portalId)
        {
            throw new NotImplementedException();
        }

        internal void AddAlbum(AlbumInfo albumInfo)
        {
            throw new NotImplementedException();
        }
    }
}

