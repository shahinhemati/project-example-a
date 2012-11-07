using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using IB.Common.Entities;

namespace GB.Album.UI
{
    public partial class ManagerAlbum : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Request["detailalbum"] == null)
                {
                    var albums = from a in Data.CV_Albums
                                 where  a.PortalID==PortalId
                                 select a;
                    rptAlbum.DataSource = albums;
                    rptAlbum.DataBind();

                    mv.SetActiveView(vList);
                }
                else {

                    int albumid = int.Parse(Request["detailalbum"].ToString());
                    var album = (from al in Data.CV_Albums
                                where al.AlbumID == albumid
                                select al).FirstOrDefault();

                    if (album != null) {

                        txtTitle.Text = album.AlbumName;
                        txtDes.Text = album.ShortContent;

                        var imgs = from im in Data.CV_ImageAlbums
                                   where im.AlbumID == albumid
                                   select im;

                        rptAlbumDtl.DataSource = imgs;
                        rptAlbumDtl.DataBind();
                        mv.SetActiveView(vDetail);
                    }
                }
            }
        }


        protected void DeleteAlbum_Click(object sender, EventArgs e) { 
        
            int albumid=int.Parse((sender as LinkButton).CommandArgument);

            var images= from img in Data.CV_ImageAlbums
                        where img.AlbumID==albumid
                        select img;

            var album = (from al in Data.CV_Albums
                        where al.AlbumID == albumid
                        select al).FirstOrDefault();

            Data.CV_ImageAlbums.DeleteAllOnSubmit(images);
            Data.CV_Albums.DeleteOnSubmit(album);
            Data.SubmitChanges();


            var albums = from a in Data.CV_Albums
                         select a;
            rptAlbum.DataSource = albums;
            rptAlbum.DataBind();
        }
    }
}