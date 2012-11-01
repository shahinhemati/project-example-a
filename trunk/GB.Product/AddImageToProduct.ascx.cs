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

namespace IB.Product
{
    public partial class AddImageToProduct : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["productid"] != null) {

                LoadProduct();
            
            }
        }
        public string AlbumID {

            get {

               return Request["productid"].ToString();
            
            }
        }
        public string PortalID {

            get {

                return PortalId.ToString();

            }
        }

        private void LoadProduct()
        {
            int id = int.Parse(Request["productid"].ToString());
            var product = (from p in Data.CV_Products
                          where p.ProductID == id
                          select p).FirstOrDefault();

            if (product != null) {

                lblTitle.Text = product.Title;
                lblPrice.Text = product.Price.Value.ToString();
                img.ImageUrl = GetWebImageOfThumb(LocationImage.Product, product.ImageName);
                lblDescription.Text = product.ShortContent;
            
            }
        }
    }
}