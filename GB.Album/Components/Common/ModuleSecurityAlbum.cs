using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security.Permissions;
using GB.Album.CommonBase;

namespace GB.Album.Components.Common
{
    public class ModuleSecurityAlbum:ModuleSecurity
    {
        //constants
        public const string PermissionCode = "PermisionAlbumCode";
        public const string PermissionRead = "PermissionRead";

        //private 
        private bool _permissionRead;

        public ModuleSecurityAlbum(ModuleInfo moduleInfo)
        {
            ModulePermissionCollection permCollection = moduleInfo.ModulePermissions;
            _permissionRead =ModulePermissionController.HasModulePermission(permCollection, PermissionRead);     
        }
    }
}