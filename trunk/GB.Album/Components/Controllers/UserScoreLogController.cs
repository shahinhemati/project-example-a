using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Album.Components.Entities;
using GB.Album.Entities;

namespace GB.Album.Controller
{
    public class UserScoreLogController
    {
        #region Variables

        public static string PrefixCache { set; get; }

        #endregion
        #region Create new Instance
        public interface IFactory
        {
            UserScoreLogController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static UserScoreLogController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new UserScoreLogController();
        }

        [ThreadStatic]
        static UserScoreLogController _instance;
        #endregion

        public void DeleteUserScoreLog(int p, int p_2, int p_3, int voteSDown, int RelatedTermId)
        {
            throw new NotImplementedException();
        }

        public void AddScoringLog(UserScoreLogInfo objScoreLog, IEnumerable<QaSettingInfo> privilegeCollection)
        {
            throw new NotImplementedException();
        }
    }
}