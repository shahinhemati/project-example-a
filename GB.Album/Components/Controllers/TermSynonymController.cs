using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Entities;

namespace GB.Common.Controller
{
    public class TermSynonymController
    {
        #region Variables

        public static string PrefixCache { set; get; }

        #endregion

        #region Create new Instance

        public interface IFactory
        {
            TermSynonymController GetInstance();
        }

        private static IFactory Factory { get; set; }

        public static TermSynonymController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new TermSynonymController();
        }

        [ThreadStatic] private static TermSynonymController _instance;

        #endregion

        public IEnumerable<TermSynonymInfo> GetTermSynonymVotes(int relatedTermId, int portalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TermSynonymInfo> GetPostVotes(int currentPostId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TermSynonymInfo> GetTermSynonyms(int portalId)
        {
            throw new NotImplementedException();
        }
    }
}