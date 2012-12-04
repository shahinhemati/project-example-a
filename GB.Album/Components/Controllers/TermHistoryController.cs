using System;

namespace GB.Album.Controller
{
    public class TermHistoryController
    {
        #region Variables

        public static string PrefixCache { set; get; }

        #endregion
        #region Create new Instance
        public interface IFactory
        {
            TermHistoryController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static TermHistoryController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new TermHistoryController();
        }

        [ThreadStatic]
        static TermHistoryController _instance;
        #endregion
    }
}