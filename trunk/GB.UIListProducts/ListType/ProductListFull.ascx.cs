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
using IB.Paging;

namespace UIListProducts
{
    public partial class ProductListFull : V_ListTypeBase
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var Data = V_Base.Data;
            int catid =  ParentLoad.CatID;
           
            var products = from nw in Data.CV_Products
                           join cat_ in Data.CV_CatProducts on nw.CatID equals cat_.CatID
                           where (nw.CatID==catid||catid==-1) && (cat_.PortalID==ParentLoad.PortalId)
                           orderby nw.ProductID descending
                           select nw;

            //1 . chuyen truy van thanh list

            PagedList<IB.Common.Entities.CV_Product> pl = new PagedList<IB.Common.Entities.CV_Product>(products, ParentLoad.PageCurr - 1, ParentLoad.PageSize);

            if (pl.Count > 0)
            {
                //2 . gan vao repeater

                rptproducts.DataSource = pl;
                rptproducts.DataBind();

                //3 . chuyen thanh thanh phan trang

                Pager pg = new Pager(ParentLoad.PageSize, ParentLoad.PageCurr, pl.TotalItemCount, ParentLoad.TabId);

                //4. tao thanh phan trang

                pnPaging.Text = pg.RenderHtml();
            }
        }
    }
}