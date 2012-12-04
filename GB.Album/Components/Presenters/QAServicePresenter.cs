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
using System.Web;
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Controller;
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
            View.UploadProcess += ProcessUploadFile;
        }

        #endregion

        #region Private Methods

        private void SearchQuestionTitle(object sender, SearchQuestionTitleEventArgs e)
        {
            e.Result = Controller.SearchQuestionTitles(e.ModuleId, e.SearchPhrase);
        }

        #endregion

        #region Process Upload File
        public void ProcessUploadFile(object sender,UploadEventArgs<HttpContext> e)
        {
            lock (_locker)
            {

                var db =new AlbumImageController();
                var flAlbum = new FileAlbumController();
                int albumid = int.Parse(e.HttpContextUpload.Request.QueryString["albumid"].ToString());

                //tim va thiet lap thong tin con thieu cho lop V_Base
                int portalid = int.Parse(e.HttpContextUpload.Request.QueryString["portalid"].ToString());
                var portalInfo = new DotNetNuke.Entities.Portals.PortalController().GetPortal(portalid);
                string pathImgThumb = "/" + portalInfo.HomeDirectory + "/"+GB.Album.CommonBase.Constants.FolderImageThum+"/";

                e.HttpContextUpload.Response.ContentType = "text/plain";//"application/json";

                var r = new System.Collections.Generic.List<ViewDataUploadFilesResult>();

                foreach (string file in e.HttpContextUpload.Request.Files)
                {
                    HttpPostedFile hpf = e.HttpContextUpload.Request.Files[file] as HttpPostedFile;
                    string FileName = string.Empty;
                    if (HttpContext.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = hpf.FileName.Split(new char[] { '\\' });
                        FileName = files[files.Length - 1];
                    }
                    else
                    {
                        FileName = hpf.FileName;
                    }
                    if (hpf.ContentLength == 0)
                        continue;

                    //save file to album
                    flAlbum.StoreImagesInAlbum(hpf.InputStream,FileName,portalid,44);
                    //add Image to DB
                    db.AddNewImage(albumid,FileName);

                    r.Add(new ViewDataUploadFilesResult()
                    {
                        Thumbnail_url = pathImgThumb+FileName,
                        Name = FileName,
                        Length = hpf.ContentLength,
                        Type = hpf.ContentType
                    });
                }

                e.Results = r;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        static readonly object _locker = new object();
        #endregion
    }

    public class ViewDataUploadFilesResult
    {
        public string Thumbnail_url { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }


}