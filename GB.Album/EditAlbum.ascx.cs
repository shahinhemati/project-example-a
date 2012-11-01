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


namespace IB.Album
{
    public partial class EditAlbum : IB.Common.Base.V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["albumid"] != null&&!IsPostBack)
            {
                LoadAlbum();
            }
            else
            {
                CreateAlbum();
            }
        }

        public int AlbumID
        {
            get
            {
                int albumid = -1;
                if (Request["albumid"] != null)
                {
                    if (int.TryParse(Request["albumid"].ToString(), out albumid))
                    {
                    }
                }
                return albumid;
            }
        }


        private void CreateAlbum()
        {
            this.txtAlbum.Text = string.Format("Album {0}", DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void LoadAlbum()
        {
            int albumid = 0;
            if (int.TryParse(Request["albumid"].ToString(), out albumid))
            {

                var album = (from al in Data.CV_Albums
                             where al.AlbumID == albumid
                             select al).FirstOrDefault();

                if (album != null)
                {
                    this.txtAlbum.Text = album.AlbumName;
                    this.txtDes.Text = album.ShortContent;
                    this.img_Album.ImageUrl = GetWebImageOfThumb(IB.Common.Base.LocationImage.Album, album.ImageName);

                    this.addImage.NavigateUrl = EditUrl("", "", "AddImageToAlbum", "albumid=" + albumid.ToString());
                    this.addImage.Text = "Thêm ảnh";

                    this.rptImgOfAlbum.DataSource = from i in Data.CV_ImageAlbums where i.AlbumID==albumid select i;
                    this.rptImgOfAlbum.DataBind();
                }
            }
        }

        protected void DeleteImageOfAlbum_Click(object sender, EventArgs e)
        {

            int imgid = int.Parse((sender as LinkButton).CommandArgument);
            var img = (from i in Data.CV_ImageAlbums
                       where i.ImageID == imgid
                       select i).FirstOrDefault();

            if (img != null)
            {

                Data.CV_ImageAlbums.DeleteOnSubmit(img);
                Data.SubmitChanges();

                int albumid = 0;
                if (int.TryParse(Request["albumid"].ToString(), out albumid))
                {
                    if (albumid != 0)
                    {
                        this.rptImgOfAlbum.DataSource = from i in Data.CV_ImageAlbums where i.AlbumID == albumid select i;
                        this.rptImgOfAlbum.DataBind();
                    }
                }
            }

        }

        protected void SaveAlbum_Click(object sender, EventArgs e)
        {


            if (Request["albumid"] != null)
            {
                //Luu thay doi
                int albumid = 0;
                if (int.TryParse(Request["albumid"].ToString(), out albumid))
                {

                    var album = (from al in Data.CV_Albums
                                 where al.AlbumID == albumid
                                 select al).FirstOrDefault();

                    if (album != null)
                    {
                        album.AlbumName = txtAlbum.Text.Trim();
                        album.ShortContent = txtDes.Text.Trim();
                       
                        if (flUpload.HasFile)
                        {
                            string imagname = this.SaveImage(flUpload.FileContent, flUpload.FileName, IB.Common.Base.LocationImage.Album);
                            album.ImageName = imagname;
                        }

                        Data.SubmitChanges();
                        Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId));
                    }
                }
            }
            else
            {
                //them album moi
                var album = new CV_Album
                {
                    AlbumName = txtAlbum.Text.Trim(),
                    ShortContent = txtDes.Text.Trim(),
                    ImageName="no_img.gif",
                    PortalID = PortalId
                };

                if (flUpload.HasFile)
                {
                    string imagname = this.SaveImage(flUpload.FileContent, flUpload.FileName, IB.Common.Base.LocationImage.Album);
                    album.ImageName = imagname;
                }

                Data.CV_Albums.InsertOnSubmit(album);
                Data.SubmitChanges();
                Response.Redirect(EditUrl("","","AddImageToAlbum","albumid="+album.AlbumID.ToString()));
            }
        }

    }
}