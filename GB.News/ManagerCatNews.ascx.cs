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

namespace IB.News
{
    public partial class ManagerCatNews : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cats = from c in Data.CV_CatNews
                           where  c.PortalID==PortalId
                           select c;

                rpt.DataSource = cats;
                rpt.DataBind();
            }
        }


        protected void DeleteNews_Click(object sender, EventArgs e)
        {
            int catid = int.Parse((sender as LinkButton).CommandArgument);
            DeleteCate(catid);
            Response.Redirect(EditUrl("CatNews"));
        }

        public void DeleteCate(int ctid)
        {

            var cats = from c in Data.CV_CatNews
                       where (c.ParentID.HasValue ? c.ParentID.Value : -1) == ctid
                       select c;
            if (cats.Count() > 0)
            {
                foreach (CV_CatNew c in cats)
                {
                    DeleteCate(c.CatID);
                }
            }

            var news = from n in Data.CV_News
                       where n.CatNewsID == ctid
                       select n;
            Data.CV_News.DeleteAllOnSubmit(news);
            Data.SubmitChanges();

            var cat = (from c in Data.CV_CatNews
                       where c.CatID == ctid 
                       select c).FirstOrDefault();
            if (cat != null)
            {
                Data.CV_CatNews.DeleteOnSubmit(cat);
                Data.SubmitChanges();
            }
        }

    }
}