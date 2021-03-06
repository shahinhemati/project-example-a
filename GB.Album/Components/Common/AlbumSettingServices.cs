﻿

namespace GB.Album.Components.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using GB.Album.CommonBase;
    using GB.Album.Entities;

    public class AlbumSettingServices
    {
        /// <summary>
        /// get setting from folder
        /// </summary>
        /// <param name="colSettings"></param>
        /// <param name="portalId"></param>
        /// <returns></returns>
        public static List<SettingInfo> GetPrivilegeCollection(List<SettingInfo> colSettings, int portalId)
        {
            var colPrivSettings = (from t in colSettings where t.TypeId == (int)Constants.SettingTypes.PrivilegeLevelScore select t);
            var colPrivileges = new List<SettingInfo>();
            colPrivileges.AddRange(colPrivSettings);
            return colPrivileges;
        }
    }
}