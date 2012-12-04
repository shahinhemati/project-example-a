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
		private const string CtlAddAlbum = "/AddAlbum.ascx";
		private const string CtlEditAlbum = "/EditAlbum.ascx";
		private const string CtlDisplayAlbum = "/DisplayAlbum.ascx";
        private const string CtlAddImage = "/AddImage.ascx";
        private const string CtlEditImage = "/EditImage.ascx";
        
		private const string CtlTagList = "/TagList.ascx";
		private const string CtlTagDetail = "/TagDetail.ascx";
		private const string CtlTagHistory = "/TagHistory.ascx";
		private const string CtlEditTag = "/EditTerm.ascx";
        private const string CtlManagerAlbum = "/ManagerAlbum.ascx";
        

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
				View.Model.InProfileMode = true;
			}
			else
			{
				switch (ControlView.ToLower())
				{
                    case "addalbum":
				        View.Model.ControlToLoad = CtlAddAlbum;
				        break;
                    case "editalbum":
                        View.Model.ControlToLoad = CtlEditAlbum;
                        break;
                    case "manageralbum":
                        View.Model.ControlToLoad = CtlManagerAlbum;
                        break;
                    case "addimage":
                        View.Model.ControlToLoad = CtlAddImage;
                        break;
                    case "editemage":
                        View.Model.ControlToLoad = CtlEditImage;
                        break;
                    case "displayalbum":
                        View.Model.ControlToLoad = CtlDisplayAlbum;
                        break;
					case "termsynonyms":
						View.Model.ControlToLoad = CtlTagDetail;
						break;
					case "home":
						View.Model.ControlToLoad = CtlHome;
						break;
					case "tags":
						View.Model.ControlToLoad = CtlTagList;
						break;
					case "termdetail":
						View.Model.ControlToLoad = CtlTagDetail;
						break;
					case "termhistory":
						View.Model.ControlToLoad = CtlTagHistory;
						break;
					case "editterm":
						View.Model.ControlToLoad = CtlEditTag;
						break;
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