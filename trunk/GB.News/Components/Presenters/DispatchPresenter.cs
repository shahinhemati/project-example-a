//
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2012
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//


using DotNetNuke.Web.Mvp;
using GB.Album.Components.Controllers;
using GB.Album.Components.Models;
using GB.Album.Components.Views;
using System;
using DotNetNuke.Common.Utilities;

namespace GB.Album.Components.Presenters {

	/// <summary>
	/// 
	/// </summary>
	public class DispatchPresenter : ModulePresenter<IDispatchView, DispatchModel> {

		#region Private Members


		/// <summary>
		/// 
		/// </summary>
		private string ControlView {
			get {
				var controlView = Null.NullString;
				if (!String.IsNullOrEmpty(Request.Params["view"]))
				{
					controlView = (Request.Params["view"]);
				}
				return controlView;
			}
		}

		private const string CtlHome = "/Home.ascx";
		private const string CtlQuestion = "/Question.ascx";
		private const string CtlAskQuestion = "/AskQuestion.ascx";
		private const string CtlBrowse = "/Browse.ascx";
		private const string CtlTagList = "/TagList.ascx";
		private const string CtlTagDetail = "/TagDetail.ascx";
		private const string CtlSubscriptions = "/Subscriptions.ascx";
		private const string CtlTagHistory = "/TagHistory.ascx";
		private const string CtlEditTag = "/EditTerm.ascx";
		private const string CtlPostHistory = "/PostHistory.ascx";
		private const string CtlPrivilege = "/Privilege.ascx";
		private const string CtlEditPost = "/EditPost.ascx";
		private const string CtlProfile = "/Profile.ascx";

		#endregion

		#region Constructor

		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="view"></param>
		/// <param name="controller"></param>
		public DispatchPresenter(IDispatchView view):base(view){
			if (view == null) {
				throw new ArgumentException(@"View is nothing.", "view");
			}

		}

		#endregion

		#region Events

		/// <summary>
		/// 
		/// </summary>
		protected override void OnInit() {
			base.OnInit();

			View.Model.IsEditable = IsEditable;


			if ((ModuleContext.PortalSettings.ActiveTab.ParentId == ModuleContext.PortalSettings.UserTabId) || (ModuleContext.TabId == ModuleContext.PortalSettings.UserTabId))
			{
				// profile mode
				View.Model.ControlToLoad = CtlProfile;
				View.Model.InProfileMode = true;
			}
			else
			{
				switch (ControlView.ToLower())
				{
					case "termsynonyms":
						View.Model.ControlToLoad = CtlTagDetail;
						break;
					case "home":
						View.Model.ControlToLoad = CtlHome;
						break;
					case "question":
						View.Model.ControlToLoad = CtlQuestion;
						break;
					case "browse":
						View.Model.ControlToLoad = CtlBrowse;
						break;
					case "ask":
						View.Model.ControlToLoad = CtlAskQuestion;
						break;
					case "tags":
						View.Model.ControlToLoad = CtlTagList;
						break;
					case "termdetail":
						View.Model.ControlToLoad = CtlTagDetail;
						break;
					case "subscriptions":
						View.Model.ControlToLoad = CtlSubscriptions;
						break;
					case "termhistory":
						View.Model.ControlToLoad = CtlTagHistory;
						break;
					case "editterm":
						View.Model.ControlToLoad = CtlEditTag;
						break;
					case "posthistory":
						View.Model.ControlToLoad = CtlPostHistory;
						break;
					case "privileges":
						View.Model.ControlToLoad = CtlPrivilege;
						break;
					case "editpost":
						View.Model.ControlToLoad = CtlEditPost;
						break;
					//case "badges":
					//    View.Model.ControlToLoad = CtlBadges;
					//    break;
					//case "badge":
					//    View.Model.ControlToLoad = CtlBadge;
					//    break;
					default:
						View.Model.ControlToLoad = CtlHome;
						break;
				}
			}

			View.Refresh();
		}

		#endregion

	}
}