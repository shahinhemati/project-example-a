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
using IB.Paging;
using IB.Common.Entities;
using IB.Common.Base;
using IB.Common;
namespace IB.News
{
    public partial class ManagerNews : V_Base
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
                SearchNews();
            }
            InnitCBCat();
        }

        private void SearchNews()
        {
            int _catnews = (ddlCatNews.Items.Count > 0) ? int.Parse(ddlCatNews.SelectedValue) : -1;

            var news = from nw in Data.CV_News join ct in Data.CV_CatNews on nw.CatNewsID equals ct.CatID
                       where ct.PortalID==PortalId&& (nw.CatNewsID == _catnews || (_catnews == -1)) && (nw.Content.Contains(SearchKeyWord) || nw.Title.Contains(SearchKeyWord) || nw.ShortContent.Contains(SearchKeyWord))
                       orderby nw.NewsID descending
                       select nw;
                      
            //1 . chuyen truy van thanh list

            PagedList<CV_New> pl = new PagedList<CV_New>(news, PageCurr - 1, PageSize);

            //2 . gan vao repeater

            rptnews.DataSource = pl.ToList();
            rptnews.DataBind();

            //3 . chuyen thanh thanh phan trang

            Pager pg = string.IsNullOrEmpty(SearchKeyWord) ? new Pager(PageSize, PageCurr, pl.TotalItemCount, TabId) : new Pager(PageSize, PageCurr, pl.TotalItemCount, TabId, "searchkeyword", SearchKeyWord);

            //4. tao thanh phan trang

            pnPaging.Text = pg.RenderHtml();

        }

        private void InnitCBCat()
        {
            int catid = string.IsNullOrEmpty(ddlCatNews.SelectedValue) ? -1 : int.Parse(ddlCatNews.SelectedValue);

            System.Collections.Generic.List<ListItem> cats = new System.Collections.Generic.List<ListItem>();
            cats.Add(new ListItem { Text="Tất cả",Value="-1"});

            var catnews = from cn in Data.CV_CatNews
                          where  cn.PortalID==PortalId
                          select new ListItem {Value=cn.CatID.ToString(),Selected=cn.CatID==catid,Text=cn.CatName };
            
            foreach(var c in catnews){
                cats.Add(c);
            }

            this.ddlCatNews.Items.Clear();
            this.ddlCatNews.Items.AddRange(cats.ToArray());
            
        }

        protected void DeleteNews_Click(object sender, EventArgs e)
        {
            int newsid = int.Parse((sender as LinkButton).CommandArgument);
            var news = (from n in Data.CV_News
                       where n.NewsID == newsid
                       select n).FirstOrDefault();

            if (news != null) {

                Data.CV_News.DeleteOnSubmit(news);
                Data.SubmitChanges();
                SearchNews();
            }
        }
    }
}