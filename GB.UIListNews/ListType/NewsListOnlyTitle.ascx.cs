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

namespace UIListNews.ListType
{
    public partial class NewsListOnlyTitle : V_ListTypeBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Data = IB.Common.Base.V_Base.Data;
            int catid = ParentLoad.CatID;
            var news = from nw in Data.CV_News
                       join cat_ in Data.CV_CatNews on nw.CatNewsID
                       equals cat_.CatID
                       where (nw.CatNewsID == catid || catid == -1) && cat_.PortalID==ParentLoad.PortalId
                       orderby nw.NewsID descending
                       select nw;

            //1 . chuyen truy van thanh list
            IB.Paging.PagedList<IB.Common.Entities.CV_New> pl = new IB.Paging.PagedList<IB.Common.Entities.CV_New>(news, ParentLoad.PageCurr - 1, ParentLoad.PageSize);

            //2 . gan vao repeater
            if (pl.Count > 0)
            {
                rptnews.DataSource = pl;
                rptnews.DataBind();
                //3 . chuyen thanh thanh phan trang
                //IB.Paging.Pager pg = new IB.Paging.Pager(PageSize, PageCurr, pl.TotalItemCount, TabPager);
                //4. tao thanh phan trang
                //pnPaging.Text = pg.RenderHtml();
            }
        }
    }
}