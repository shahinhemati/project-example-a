using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Common.Entities;

namespace GB.Album.Components.Controllers
{
    public class ContentItemController
    {
        #region Create new Instance
        public interface IFactory
        {
            ContentItemController GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static ContentItemController GetInstance()
        {
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