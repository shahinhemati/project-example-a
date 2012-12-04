using System;
using System.Collections.Generic;
using GB.Album.Entities;

namespace GB.Album.Controllers
{
    public class SettingController
    {
        #region PrefixCache

        public static string PrefixCache { set; get; }

        #endregion
        #region Create new Instance
        public interface IFactory
        {
            SettingController GetInstance();
        }

        private static IFactory Factory { get; set; }
        public static SettingController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new SettingController();
        }

        [ThreadStatic]
        static SettingController _instance;

        #endregion

        public void AddSetting(SettingInfo infoSS)
        {
            
        }

        public void UpdateSetting(SettingInfo infoSS)
        {

        }

        public List<SettingInfo> GetQaPortalSettings(int portalId)
        {
            throw new NotImplementedException();
        }
    }
}