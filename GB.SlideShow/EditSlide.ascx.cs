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
using IB.Common.Entities;

namespace SlideShow
{
    public partial class EditSlide : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["slideid"] != null && !IsPostBack)
            {
                LoadSlideItem();
            }
        }

        private void LoadSlideItem()
        {
            int itemid = int.Parse(Request["slideid"].ToString());
            var imgs = (from sl in Data.CV_SlideItems
                        where sl.ItemID == itemid
                        select sl).FirstOrDefault();
            if (imgs != null)
            {

                txtTitle.Text = imgs.Title;
                txtDes.Text = imgs.Description;
                url.Text = imgs.URL;
                img.ImageUrl = GetWebImageOfThumb(LocationImage.Slide,imgs.FileImage);
            }
        }

        protected void SaveChange_Click(object sender, EventArgs e)
        {
            if (Request["slideid"] != null)
            {
                //thay doi gia tri slide item
                int itemid = int.Parse(Request["slideid"].ToString());

                var itsl = (from i in Data.CV_SlideItems
                           where i.ItemID == itemid
                           select i).FirstOrDefault();
                if (itsl != null) {

                    itsl.Title = txtTitle.Text.Trim();
                    itsl.Description = txtDes.Text.Trim();
                    itsl.URL = url.Text.Trim();


                    if (flUpload.HasFile) {
                        itsl.FileImage=SaveImage(flUpload.FileContent, flUpload.FileName, LocationImage.Slide);
                    }
                    Data.SubmitChanges();
                }
            }
            else
            {
                //them moi

                var itsl = new CV_SlideItem
                {
                    Title = txtTitle.Text.Trim(),
                    Description = txtDes.Text.Trim(),
                    URL = url.Text.Trim(),
                    FileImage = "no_img.gif",
                    PortalID = PortalId
                };

                if (flUpload.HasFile)
                {
                    itsl.FileImage = SaveImage(flUpload.FileContent, flUpload.FileName, LocationImage.Slide);
                }

                Data.CV_SlideItems.InsertOnSubmit(itsl);
                Data.SubmitChanges();
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId));
        }
    }
}