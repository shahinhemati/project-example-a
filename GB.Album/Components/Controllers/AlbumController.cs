using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Content;
using GB.Album.Components.Common;
using GB.Album.Components.Entities;
using GB.Album.Components.Integration;
using GB.Common.Entities;

namespace IB.Album.Components.Controllers
{
    
    public class AlbumController
    {
        #region Create new Instance
        public interface IFactory
        {
            AlbumController GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static AlbumController GetInstance()
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
        /// 2 . Seconde :Add Album to DataBase
        /// 3 . Store Album into Cache
        /// </summary>
        /// <param name="album"></param>
        /// <returns>
        /// Id of album
        /// </returns>
        public int AddAlbum(GB.Album.Components.Entities.AlbumInfo album)
        {
            int rt=-1;
            
            ContentItem item=new ContentItem()
                                 {
                                     Content = album.Content,
                                     ContentKey = album.ContentKey,
                                     ContentTypeId = album.ContentTypeID,
                                     ModuleID = album.ModuleID,
                                     TabID = album.TabID,
                                 };
            Utils.
            //todo 1 store the album to database and store ContentItem to DataBase
            //todo 2 if process store error then store error in LogSystem dnn and throw an exception
            
            
            SqlServerDb.GetInstance().Insert(album);
            
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
		private static int CompleteQuestionCreation(AlbumInfo objPost, int tabId) {
			var cntTaxonomy = new Content();
			var objContentItem = cntTaxonomy.CreateContentItem(objPost, tabId);

			return objContentItem.ContentItemId;
		}

		/// <summary>
		/// Handles any content item/taxonomy updates, then deals with cache clearing. 
		/// </summary>
		/// <param name="objAlbum"></param>
		/// <param name="tabId"></param>
		private static void CompleteQuestionUpdate(AlbumInfo objAlbum, int tabId) {
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
    }
}