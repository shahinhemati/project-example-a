﻿//
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

using System;
using DotNetNuke.Common.Utilities;
using GB.Album.Components.Entities;
using GB.Album.CommonBase;

namespace GB.Album.Entities {

	public class QuestionServiceInfo : AlbumInfo {

		public int UpVotes { get; set; }

		public int DownVotes { get; set; }

		public int TotalAnswers { get; set; }

		public int LastApprovedUserId { get; set; }

		public DateTime LastApprovedDate { get; set; }

		//Read Only Props
		internal string CreatedByUsername
		{
			get
			{
				return CreatedByUserID > 0 ? DotNetNuke.Entities.Users.UserController.GetUserById(PortalID, CreatedByUserID).Username : "Anonymous";
			}
		}

		internal string LastModifiedUser
		{
			get
			{
				return LastModifiedByUserID > 0 ? DotNetNuke.Entities.Users.UserController.GetUserById(PortalID, LastModifiedByUserID).Username : "Anonymous";
			}
		}

		internal string LastApprovedUser
		{
			get
			{
				return LastApprovedUserId > 0 ? DotNetNuke.Entities.Users.UserController.GetUserById(PortalID, LastApprovedUserId).Username : "Anonymous";
			}
		}

		public int QuestionVotes
		{
			get { return (UpVotes - DownVotes); }
		}

		public string QuestionUrl
		{
			get { return Links.ViewQuestion(TabID, EntityId); } 
		}
	}
}