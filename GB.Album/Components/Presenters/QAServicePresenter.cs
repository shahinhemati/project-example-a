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

using System;
using DotNetNuke.ComponentModel;
using DotNetNuke.Web.Mvp;
using GB.Album.Views;
using IB.Album.Components.Controllers;

namespace GB.Album.Components.Presenters
{

    /// <summary>
    /// 
    /// </summary>
    public class QaServicePresenter : WebServicePresenter<IQaServiceView>
    {

        #region Private Members

        protected AlbumController Controller { get; private set; }

        #endregion

        #region Constructors

        public QaServicePresenter(IQaServiceView view)
            : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(@"View is nothing.", "view");
            }
            View.ListQuestionTitleCalled += SearchQuestionTitle;
        }

        #endregion

        #region Private Methods

        private void SearchQuestionTitle(object sender, SearchQuestionTitleEventArgs e)
        {
            e.Result = Controller.SearchQuestionTitles(e.ModuleId, e.SearchPhrase);
        }

        
        #endregion

    }
}