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

namespace UIListProducts.ListType
{
    public partial class ProductListOnlyImgPrice : V_ListTypeBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            var Data = IB.Common.Base.V_Base.Data;
            int catid = ParentLoad.CatID;
            var products = from nw in Data.CV_Products
                           join cat_ in Data.CV_CatProducts on nw.CatID equals cat_.CatID
                           where (nw.CatID == catid || catid == -1) && (cat_.PortalID == ParentLoad.PortalId)
                           orderby nw.ProductID descending
                           select nw;


            //1 . chuyen truy van thanh list

            IB.Paging.PagedList<IB.Common.Entities.CV_Product> pl = new IB.Paging.PagedList<IB.Common.Entities.CV_Product>(products, ParentLoad.PageCurr - 1, ParentLoad.PageSize);

            if (pl.Count > 0)
            {
                //2 . gan vao repeater

                rptproducts.DataSource = pl;
                rptproducts.DataBind();

                //3 . chuyen thanh thanh phan trang

                //Pager pg = new Pager(PageSize, PageCurr, pl.TotalItemCount, TabPager);

                //4. tao thanh phan trang


            }
        }
    }
}