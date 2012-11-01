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

using System.Web.UI.HtmlControls;
using GB.Album.Controls;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Common;
using System.Web.UI.WebControls;
using GB.Album.Components.Entities;
using System;
using DotNetNuke.Web.UI.WebControls;

namespace GB.Album.Components.Views
{

	/// <summary>
	/// 
	/// </summary>
	public interface IQuestionView : IModuleView<Models.QuestionModel>
	{
		void SaveEnabled(bool enabled);
		void SubscribeButtonMode(bool subscribed);
		void ShowBackButton(bool show);
		void ShowNextButton(bool show);
	    void ShowAnswerArea(bool show);
		void Refresh();

		event EventHandler<QuestionEventArgs<Literal, Voting, Literal, DnnBinaryImage, Literal, DnnBinaryImage, Literal, Controls.Tags, HtmlGenericControl, Literal, Literal, Literal, Literal, Literal, Comments, Literal, Literal>> QuestionDataBound;
		event EventHandler<AddAnswerEventArgs<PostInfo>> Save;
		event EventHandler Subscribe;
		event EventHandler<FlagPostEventArgs<ModerationLogInfo>> FlagPost;
		event EventHandler<DeletePostEventArgs<ModerationLogInfo>> DeletePost;
		event EventHandler<AcceptAnswerEventArgs<int, int, int>> AcceptAnswer;
		event EventHandler<AnswersEventArgs<Literal, PostInfo, Literal, Voting, Image, HtmlGenericControl, Literal, Literal, LinkButton, Literal, DnnBinaryImage, Comments, Literal, DnnBinaryImage>> ItemDataBound;
		event EventHandler<PagerChangedEventArgs<LinkButton, string>> PagerChanged;

	}
}