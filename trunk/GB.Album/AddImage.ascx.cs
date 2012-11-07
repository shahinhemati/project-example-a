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
using IB.Common.Base;

namespace IB.Album
{
    public partial class AddImageToAlbum : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["albumid"] != null)
            {
                LoadAlbum();
            }
        }

        public string AlbumID
        {
            get
            {
                return Request["albumid"].ToString();
            }
        }
        public string PortalID
        {
            get
            {
                return PortalId.ToString();
            }
        }

        private void LoadAlbum()
        {
            int id = int.Parse(Request["albumid"].ToString());
            var product = (from p in Data.CV_Albums
                           where p.AlbumID == id
                           select p).FirstOrDefault();
            if (product != null)
            {
                lblTitle.Text = product.AlbumName;
                lblDescription.Text = product.ShortContent;
                this.imgThumbAlbum.ImageUrl=GetWebImageOfThumb(LocationImage.Album,product.ImageName);
            }
        }
    }
}