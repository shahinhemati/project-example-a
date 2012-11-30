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
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Presenters;
using GB.Album.Entities;
using GB.Album.Views;
using GB.Album.CommonBase;
using IB.Album.Components.Controllers;
using WebFormsMvp;
using System.Linq;
using DotNetNuke.Entities.Content.Common;
using DotNetNuke.Common.Utilities;

namespace GB.Album
{

    /// <summary>
    /// A series of services to be used with the QA module, primarily for ajax integration in the module itself. 
    /// </summary>
    [WebService(Namespace = "http://www.dotnetnuke.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    [PresenterBinding(typeof(QaServicePresenter), ViewType = typeof(IQaServiceView))]
    public class Qa : WebServiceView, IQaServiceView
    {
        
        public event EventHandler<SearchQuestionTitleEventArgs> ListQuestionTitleCalled;
        public event EventHandler<UploadEventArgs<HttpContext>> UploadProcess;

        protected void OnSearchQuestionTitleCalled(SearchQuestionTitleEventArgs args)
        {
            if (ListQuestionTitleCalled != null)
            {
                ListQuestionTitleCalled(this, args);
            }
        }
        
        /// <summary>
        /// Process Upload multiple
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UploadImages(HttpContext context)
        {
            var eventArgs = new UploadEventArgs<HttpContext>(context);
            UploadProcess(this,eventArgs);
            return eventArgs.Results.ToJson();
        }
        /// <summary>
        /// This method is used to search existing question titles and return the matching results, if any exist. 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="searchPhrase"></param>
        /// <returns>A collection of questions that have a similar title (and module) based on the searchPhrase passed in.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<QuestionServiceInfo> SearchQuestionTitle(int moduleId, string searchPhrase)
        {
            var args = new SearchQuestionTitleEventArgs(moduleId, searchPhrase);
            OnSearchQuestionTitleCalled(args);
            return args.Result;
        }

        /// <summary>
        /// This method is used to get the last QuestionPostId in order to display divMessage box alerting user a new answer has been submitted.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Returns the last postId in the answers collection.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int GetLastQuestionPostId(int postId)
        {
            var dnnqa =new  AlbumController();
            var ps =  DotNetNuke.Common.Globals.GetPortalSettings();

            var answers = dnnqa.GetAnswers(postId, ps.PortalId);
            if (answers.Count > 0)
            {
                var firstOrDefault = (from p in answers
                                      orderby p.CreatedOnDate descending
                                      select p).FirstOrDefault();
                if (firstOrDefault != null)
                    return firstOrDefault.EntityId;
            }

            return 0;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SearchTags(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) { return ""; }

            var terms = Util.GetTermController().GetTermsByVocabulary(1)
                .Where(t => t.Name.ToLower().Contains(searchTerm.ToLower()))
                .Where(t => t.Name.IndexOfAny(Constants.DisallowedCharacters.ToCharArray()) == -1)
                .Select(term => term.Name);
            return terms.ToJson();
        }
    }
}
