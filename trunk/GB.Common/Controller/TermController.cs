using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Content.Taxonomy;
using GB.Common.Entities;

namespace GB.Common.Controllers
{
    public class TermController
    {
        #region Variables
        public static string PrefixCache { set; get; }
        #endregion

        #region Create new Instance
        public interface IFactory
        {
            TermController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static TermController GetInstance(string prefixCache)
        {

            PrefixCache = prefixCache;
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new TermController();
        }

        [ThreadStatic]
        static TermController _instance;
        #endregion


        #region Methods 
        
        

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portalId"></param>
        /// <param name="contentTypeId"></param>
        /// <param name="moduleId"></param>
        /// <param name="vocabularyId"></param>
        /// <returns></returns>
        public List<Term> GetTermsByContentType(int portalId, int contentTypeId, int moduleId, int vocabularyId)
        {
            //get Terms  
            
            throw new NotImplementedException();
        }

        public List<Term> GetTermsByAlbumID(int albumId)
        {
            throw new NotImplementedException();
        }

        public List<TermInfo> GetTermsByContentType(int p, int p_2, int VocabularyId)
        {
            throw new NotImplementedException();
        }

        public List<SettingInfo> GetQaPortalSettings(int portalId)
        {
            throw new NotImplementedException();
        }

        public List<TermHistoryInfo> GetTermHistory(int p, int p_2)
        {
            throw new NotImplementedException();
        }

        public UserScoreInfo GetUserScore(int userId, int portalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TermSynonymInfo> GetTermSynonyms(int portalId)
        {
            throw new NotImplementedException();
        }

        public void AddTermSynonym(TermSynonymInfo objSynonym)
        {
            throw new NotImplementedException();
        }

        public List<UserScoreLogInfo> GetUserScoreLogByKey(int relatedTermId, int p)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserScoreLog(int userId, int portalId, int userScoringActionId, int score, int relatedTermId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTermSynonym(int termId, int relatedTermId, int portalId)
        {
            throw new NotImplementedException();
        }

       
    }
}