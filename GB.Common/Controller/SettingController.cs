using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Entities;

namespace GB.Common.Controllers
{
    public class SettingController
    {
        #region Create new Instance
        public interface IFactory
        {
            SettingController GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static SettingController GetInstance()
        {
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

        public List<SettingInfo> GetQaPortalSettings(object portalId)
        {
            throw new NotImplementedException();
        }
    }
}