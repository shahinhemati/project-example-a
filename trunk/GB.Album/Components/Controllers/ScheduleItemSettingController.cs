using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Album.Components.Entities;

namespace GB.Album.Components.Controllers
{
    public class ScheduleItemSettingController
    {
        #region Create new Instance
        public interface IFactory
        {
            ScheduleItemSettingController GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static ScheduleItemSettingController GetInstance()
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new ScheduleItemSettingController();
        }

        [ThreadStatic]
        static ScheduleItemSettingController _instance;

        #endregion
        public void UpdateScheduleItemSetting(int scheduleId, string toString, string p2)
        {
            throw new NotImplementedException();
        }

        internal object GetContentItemsByTypeAndCreated(int p, DateTime lastRunDate, DateTime currentRunDate)
        {
            throw new NotImplementedException();
        }

        public object GetQuestionByContentItem(object contentItemId)
        {
            throw new NotImplementedException();
        }

        public List<SubscriberInfo> GetSubscribersByContentItem(object contentItemId, int instantTerm, object portalId)
        {
            throw new NotImplementedException();
        }

    }
}