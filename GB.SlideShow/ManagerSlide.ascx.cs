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

namespace SlideShow
{
    public partial class ManagerSlide : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {

                var imgs = from sl in Data.CV_SlideItems
                           where  sl.PortalID==PortalId
                           select sl;
                rptSlide.DataSource = imgs;
                rptSlide.DataBind();
                
            
            }
        }

        protected void DeletSlideItem_Click(object sender, EventArgs e)
        {

            int slidenid = int.Parse((sender as LinkButton).CommandArgument);

            var sliden = (from sl in Data.CV_SlideItems
                         where sl.ItemID == slidenid
                         select sl).FirstOrDefault();
            if (sliden != null)
            {
                Data.CV_SlideItems.DeleteOnSubmit(sliden);
                Data.SubmitChanges();
            }

            var imgs = from sl in Data.CV_SlideItems
                       where  sl.PortalID==PortalId
                       select sl;
            rptSlide.DataSource = imgs;
            rptSlide.DataBind();
        }
    }
}