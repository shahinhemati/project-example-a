<%@ WebHandler Language="C#" Class="Handler" Debug="true" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using DotNetNuke.Services.Localization;


public class Handler : IHttpHandler
{
    static readonly object _locker = new object();
    public  void  ProcessRequest(HttpContext context)
    {
        lock (_locker)
        {
            var db = Apcom.Common.Base.V_Base.Data;
            var cmb = new  Apcom.Common.Base.V_Base();


            int albumid = int.Parse(context.Request.QueryString["albumid"].ToString());
            
            //tim va thiet lap thong tin con thieu cho lop V_Base
            int portalid = int.Parse(context.Request.QueryString["portalid"].ToString());
            var portalInfo = new DotNetNuke.Entities.Portals.PortalController().GetPortal(portalid);
            cmb.HomeDirectoryPortal = "/"+portalInfo.HomeDirectory+"/";
            
            context.Response.ContentType = "text/plain";//"application/json";

            var r = new System.Collections.Generic.List<ViewDataUploadFilesResult>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            foreach (string file in context.Request.Files)
            {
                HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;
                string FileName = string.Empty;
                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
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
                string FileNameImg = SaveImageAlbumToDB(FileName, albumid,hpf, cmb, db);

                r.Add(new ViewDataUploadFilesResult()
                {
                    Thumbnail_url = cmb.GetWebImageOfThumb(Apcom.Common.Base.LocationImage.Product,FileNameImg),
                    Name = FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
                var uploadedFiles = new
                {
                    files = r.ToArray()
                };
                var jsonObj = js.Serialize(uploadedFiles);
                context.Response.Write(jsonObj.ToString());
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public string SaveImageAlbumToDB(string fileNameFriendly, int productid, HttpPostedFile pf, Apcom.Common.Base.V_Base cb, Apcom.Common.Entities.VCDataDataContext db)
    {
        string filename = cb.SaveImage(pf.InputStream,fileNameFriendly,Apcom.Common.Base.LocationImage.Product);
        var img = new Apcom.Common.Entities.CV_ImageProduct
        {
            ProductID = productid,
            FileName = filename,
        };

        db.CV_ImageProducts.InsertOnSubmit(img);
        db.SubmitChanges();
        return filename;
    }
}
public class ViewDataUploadFilesResult
{
    public string Thumbnail_url { get; set; }
    public string Name { get; set; }
    public int Length { get; set; }
    public string Type { get; set; }
}
