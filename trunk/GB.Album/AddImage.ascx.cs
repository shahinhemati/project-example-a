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
using DotNetNuke.Web.Mvp;
using GB.Album.Components.Models;
using GB.Album.Components.Presenters;
using WebFormsMvp;


namespace IB.Album
{
    [PresenterBinding(typeof(AddImagePresenter))]
    public partial class AddImageToAlbum : ModuleView<AddImageModel>,IAddImageToAlbum
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["albumid"] != null)
            {

            }
        }

        public string AlbumID
        {
            get
            {
                return Request["albumid"].ToString();
            }
        }
    }


}