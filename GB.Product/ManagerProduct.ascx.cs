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
using IB.Paging;

namespace IB.Product
{
    public partial class ManagerProduct : V_Base
    {


        public string SearchKeyWord
        {
            get
            {
                string key = "";
                if (Request["SearchKeyWord"] != null)
                {
                    key = Request["SearchKeyWord"];
                }
                if (IsPostBack)
                {
                    key = txtSearch.Text;
                }
                return key;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchProducts();
            }
            InnitCBCat();
        }

        private void SearchProducts()
        {
            int _catprd = (ddlCatProducts.Items.Count > 0) ? int.Parse(ddlCatProducts.SelectedValue) : -1;

            var products = from nw in Data.CV_Products join ct_ in Data.CV_CatProducts on nw.CatID equals ct_.CatID
                           where ct_.PortalID==PortalId && (nw.CatID == _catprd || _catprd == -1) && (nw.Title.Contains(SearchKeyWord) || nw.ShortContent.Contains(SearchKeyWord) || nw.Content.Contains(SearchKeyWord))
                           orderby nw.ProductID descending
                           select nw;

            //1 . chuyen truy van thanh list

            PagedList<CV_Product> pl = new PagedList<CV_Product>(products, PageCurr - 1, PageSize);

            //2 . gan vao repeater

            rptproducts.DataSource = pl.ToList();
            rptproducts.DataBind();

            //3 . chuyen thanh thanh phan trang

            Pager pg = string.IsNullOrEmpty(SearchKeyWord) ? new Pager(PageSize, PageCurr, pl.TotalItemCount, TabId) : new Pager(PageSize, PageCurr, pl.TotalItemCount, TabId, "searchkeyword", SearchKeyWord);

            //4. tao thanh phan trang

            pnPaging.Text = pg.RenderHtml();

        }

        private void InnitCBCat()
        {
            int catid = string.IsNullOrEmpty(ddlCatProducts.SelectedValue) ? -1 : int.Parse(ddlCatProducts.SelectedValue);

            System.Collections.Generic.List<ListItem> cats = new System.Collections.Generic.List<ListItem>();
            cats.Add(new ListItem { Text = "Tất cả", Value = "-1" });

            var catnews = from cn in Data.CV_CatProducts
                          where  cn.PortalID==PortalId
                          select new ListItem { Value = cn.CatID.ToString(), Selected = cn.CatID == catid, Text = cn.CatName };

            foreach (var c in catnews)
            {
                cats.Add(c);
            }

            this.ddlCatProducts.Items.Clear();
            this.ddlCatProducts.Items.AddRange(cats.ToArray());


        }

        protected void DeleteProduct_Click(object sender, EventArgs e)
        {
            int productid = int.Parse((sender as LinkButton).CommandArgument);

            var img_prod = from i in Data.CV_ImageProducts
                           where i.ProductID == productid
                           select i;

            var product = (from n in Data.CV_Products
                           where n.ProductID == productid
                           select n).FirstOrDefault();

            if (product != null)
            {
                Data.CV_ImageProducts.DeleteAllOnSubmit(img_prod);
                Data.SubmitChanges();
                Data.CV_Products.DeleteOnSubmit(product);
                Data.SubmitChanges();
                SearchProducts();
            }
        }
    }
}