using System;

namespace GB.Album.Controller
{
    public class BadgeController
    {
        #region Variables

        public static string PrefixCache { set; get; }

        #endregion
        #region Create new Instance
        public interface IFactory
        {
            BadgeController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static BadgeController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new BadgeController();
        }

        [ThreadStatic]
        static BadgeController _instance;
        #endregion
    }
}