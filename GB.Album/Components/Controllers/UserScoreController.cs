using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Entities;

namespace GB.Common.Controller
{
    public class UserScoreController
    {
        #region Variables

        public static string PrefixCache { set; get; }

        #endregion
        #region Create new Instance
        public interface IFactory
        {
            UserScoreController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static UserScoreController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new UserScoreController();
        }

        [ThreadStatic]
        static UserScoreController _instance;
        #endregion

        public UserScoreInfo GetUserScore(int p, int p_2)
        {
            throw new NotImplementedException();
        }
    }
}