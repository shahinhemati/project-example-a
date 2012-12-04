using System.Collections.Generic;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Social.Notifications;
using GB.Album.CommonBase;
using GB.Album.Components.Entities;

namespace GB.Album.Components.Controllers
{
    public class NotificationController
    {

        /// <summary>
        /// This method will create a new notification message in the data store.
        /// </summary>
        /// <param name="objEntity"></param>
        /// <param name="portalId"></param>
        /// <param name="tabId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <remarks>The last part of this method is commented out but was setup to send to a role (based on a group). You can utilize this and/or also pass a list of users.</remarks>
        internal void ItemNotification(AlbumInfo objEntity, int portalId, int tabId, string subject, string body)
        {
            var notificationType = NotificationsController.Instance.GetNotificationType(Constants.NotificationQaFlag);

            var notificationKey = string.Format("{0}:{1}:{2}", Constants.ContentTypeName, objEntity.PostId, tabId);
            var objNotification = new Notification
            {
                NotificationTypeID = notificationType.NotificationTypeId,
                Subject = subject,
                Body = body,
                IncludeDismissAction = true,
                SenderUserID = objEntity.CreatedByUserID,
                Context = notificationKey
            };

            //// invite the members of the group
            //var colRoles = new List<RoleInfo>();
            //var objGroup = TestableRoleController.Instance.GetRole(portalId, r => r.RoleID == objEntity.GroupId);
            //colRoles.Add(objGroup);

            //NotificationsController.Instance.SendNotification(objNotification, portalId, colRoles, null);
        }

        #region Install Methods

        /// <summary>
        /// This will create a notification type used by the module and also handle the actions that must be associated with it.
        /// </summary>
        /// <remarks>This should only ever run once, during 1.0.0 install (via IUpgradeable). 
        /// </remarks>
        static internal void AddNotificationTypes()
        {
            var actions = new List<NotificationTypeAction>();
            var deskModuleId = DesktopModuleController.GetDesktopModuleByFriendlyName("DNNQA").DesktopModuleID;

            var objNotificationType = new NotificationType
            {
                Name = Constants.NotificationQaFlag,
                Description = "Q&A Notification",
                DesktopModuleId = deskModuleId
            };

            if (NotificationsController.Instance.GetNotificationType(objNotificationType.Name) != null) return;
            var objAction = new NotificationTypeAction
            {
                NameResourceKey = "AcceptInvite",
                DescriptionResourceKey = "AcceptInvite_Desc",
                APICall = "DesktopModules/DNNQA/API/SocialModuleService.ashx/ActionMethod",
                Order = 1
            };
            actions.Add(objAction);

            NotificationsController.Instance.CreateNotificationType(objNotificationType);
            NotificationsController.Instance.SetNotificationTypeActions(actions, objNotificationType.NotificationTypeId);
        }

        #endregion

    }
}