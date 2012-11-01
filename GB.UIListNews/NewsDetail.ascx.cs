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
using IB.Common;
using IB.Common.Base;

namespace UIListNews
{
    public partial class NewsDetail : V_ListNewsBase
    {
        private TempService tempService;
        private ListNews listNews = null;

        public ListNews ListNews
        {
            get { return listNews; }
            set { listNews = value; }
        }

        public TempService TempService
        {
            get { return tempService; }
            set { tempService = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
           // TempService=new TempService(this);
        }

        public void DataBinding()
        {
            int newsid = NewsID;
            var Data = IB.Common.Base.V_Base.Data;
            var news = (from nw in Data.CV_News
                        where nw.NewsID == newsid
                        select new NewsInfo
                                       {
                                           Content = nw.Content,
                                           CreatedDate = nw.CreatedDate.Value,
                                           ImageName = nw.ImageName,
                                           NewsId = nw.NewsID,
                                           ShortContent = nw.ShortContent,
                                           Title = nw.Title,
                                           Url = ListNews.WriteUrl(ListNews.TabId.ToString(), "detailnews", nw.NewsID.ToString(), nw.Title)
                                       }).FirstOrDefault();
            if (news != null)
            {

                NewsTokenReplace newsTokenReplace = new NewsTokenReplace(news);
                string str = newsTokenReplace.ReplaceNewsInfo(TempService.GetContentTempFromDB(TypeTemp.Detail));
                Literal lt = new Literal();
                lt.Text = str;
                plh_detail.Controls.Add(lt);

                var newsnewer = (from n in Data.CV_News
                                 join cat_ in Data.CV_CatNews on n.CatNewsID
                                 equals cat_.CatID
                                 where n.NewsID > newsid && cat_.PortalID == PortalId
                                 orderby n.NewsID ascending
                                 select new NewsInfo
                                       {
                                           Content = n.Content,
                                           CreatedDate = n.CreatedDate.Value,
                                           ImageName = n.ImageName,
                                           NewsId = n.NewsID,
                                           ShortContent = n.ShortContent,
                                           Title = n.Title,
                                           Url = ListNews.WriteUrl(ListNews.TabId.ToString(), "detailnews", n.NewsID.ToString(), n.Title)
                                       }).Take(10);

                var newolder = (from n in Data.CV_News
                                join cat_ in Data.CV_CatNews on n.CatNewsID
                                equals cat_.CatID
                                where n.NewsID < newsid && cat_.PortalID == PortalId
                                orderby n.NewsID descending
                                select new NewsInfo
                                       {
                                           Content = n.Content,
                                           CreatedDate = n.CreatedDate.Value,
                                           ImageName = n.ImageName,
                                           NewsId = n.NewsID,
                                           ShortContent = n.ShortContent,
                                           Title = n.Title,
                                           Url = ListNews.WriteUrl(ListNews.TabId.ToString(), "detailnews", n.NewsID.ToString(), n.Title)
                                       }).Take(10);

                this.rptNewer.DataSource = newsnewer;
                rptNewer.DataBind();

                this.rptOlder.DataSource = newolder;
                rptOlder.DataBind();
            }
        }

        protected void OnDataBinding(object sender, RepeaterItemEventArgs e)
        {
            NewsInfo item = (NewsInfo)e.Item.DataItem;
            NewsTokenReplace newsTokenReplace = new NewsTokenReplace(item);
            string str = newsTokenReplace.ReplaceNewsInfo(TempService.GetContentTempFromDB(TypeTemp.Relative));
            Literal lt = new Literal();
            lt.Text = str;
            e.Item.Controls.Add(lt);
        }
    }
}