using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Entities;

namespace GB.Common.Controllers
{
    public class ContentItemController
    {
        #region Variables

        public static string PrefixCache { set; get; }

        #endregion
        #region Create new Instance
        public interface IFactory
        {
            ContentItemController GetInstance();
        }

        static IFactory Factory { get; set; }
        public static ContentItemController GetInstance(string prefixCache)
        {
            PrefixCache = prefixCache;

            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new ContentItemController();
        }

        [ThreadStatic]
        static ContentItemController _instance;
        #endregion

        public List<ContentItemDnn> GetContentItemsByTypeAndCreated(int contentTypeId, DateTime lastRunDate, DateTime currentRunDate)
        {
            throw new NotImplementedException();
        }
    }
}