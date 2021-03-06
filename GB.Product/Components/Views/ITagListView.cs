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

using GB.Product.Components.Entities;
using DotNetNuke.Web.Mvp;
using GB.Product.Components.Common;
using System.Web.UI.WebControls;
using System;

namespace GB.Product.Components.Views
{

	/// <summary>
	/// 
	/// </summary>
	public interface ITagListView : IModuleView<Models.TagListModel>
	{

		void Refresh();
		void ShowBackButton(bool show);
		void ShowNextButton(bool show);

		event EventHandler<TagListEventArgs<Literal, Literal, TermInfo, Controls.Tags, Literal>> ItemDataBound;
		event EventHandler<PagerChangedEventArgs<LinkButton, string>> PagerChanged;
		event EventHandler<TagSearchEventArgs<string>> TagFiltered;

	}
}