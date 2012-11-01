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

using System.Collections.Generic;
using GB.Album.Components.Entities;
using DotNetNuke.Entities.Content.Taxonomy;

namespace GB.Album.Components.Models
{

	public class BrowseModel 
	{

		public List<FilterInfo> AppliedFilters { get; set; }
		public string AppliedKeyword { get; set; }
		public string AppliedType { get; set; }
		public int AppliedUser { get; set; }
		public bool ApplyUnanswered { get; set; }	
		public List<QuestionInfo> ColQuestions { get; set; }
		public int CurrentPage { get; set; }
		public string HeaderTitle { get; set; }
		public string NextPageLink { get; set; }
		public string PageDescription { get; set; }
		public string PageLink { get; set; }
		public string PageTitle { get; set; }
		public string PrevPageLink { get; set; }
		public List<TermInfo> RelatedTags { get; set; }
		public TermInfo SelectedTerm { get; set; }
		public string SortBy { get; set; }
		public string TagDetailUrl { get; set; }
		
	}
}