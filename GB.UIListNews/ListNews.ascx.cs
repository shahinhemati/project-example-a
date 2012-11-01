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
using DotNetNuke.UI.Utilities;
using IB.Common;
using IB.Common.Base;
using IB.Common.Entities;
using IB.Paging;

namespace UIListNews
{
    public partial class ListNews : V_ListNewsBase
    {
        private TempService tempService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            tempService=new TempService(this);
            if (!IsPostBack)
            {
                if (NewsID == -1)
                {
                    var Data = IB.Common.Base.V_Base.Data;

                    var news = from nw in Data.CV_News
                               join cat_ in Data.CV_CatNews on nw.CatNewsID
                                   equals cat_.CatID
                               where (nw.CatNewsID == CatID || CatID == -1) && cat_.PortalID == PortalId
                               orderby nw.NewsID descending
                               select
                                   new NewsInfo{
                                           Content = nw.Content,
                                           CreatedDate = nw.CreatedDate.Value,
                                           ImageName = nw.ImageName,
                                           NewsId = nw.NewsID,
                                           ShortContent = nw.ShortContent,
                                           Title = nw.Title,
                                           Url = WriteUrl(TabId.ToString(), "detailnews",nw.NewsID.ToString(),nw.Title)
                                       };

                    //1 . chuyen truy van thanh list
                    IB.Paging.PagedList<NewsInfo> pl = new IB.Paging.PagedList<NewsInfo>(news, PageCurr - 1, PageSize);
                    //2 . gan vao repeater
                    if (pl.Count > 0)
                    {
                        rptnews.DataSource = pl;
                        rptnews.DataBind();
                        //3 . chuyen thanh thanh phan trang
                        IB.Paging.Pager pg = new IB.Paging.Pager(PageSize, PageCurr, pl.TotalItemCount, TabId);
                        //4. tao thanh phan trang
                        pnPaging.Text = pg.RenderHtml();
                    }
                    mv.SetActiveView(vList);
                }
                else
                {
                    NewsDetail c = (NewsDetail)Page.LoadControl(ControlPath + "/NewsDetail.ascx");
                    c.ListNews = this;
                    c.TempService = this.tempService;
                    c.DataBinding();
                    plhDetail.Controls.Add(c);
                    mv.SetActiveView(vDetail);
                }
            }
        }

        private int count = 0;

        protected void OnDataBinding(object sender, RepeaterItemEventArgs e)
        {
            count++;
            NewsInfo item = (NewsInfo)e.Item.DataItem;
            NewsTokenReplace newsTokenReplace = new NewsTokenReplace(item);
            string str = newsTokenReplace.ReplaceNewsInfo(tempService.GetContentTempFromDB(TypeTemp.List));
            Literal lt = new Literal();
            lt.Text = str;
            e.Item.Controls.Add(lt);
            if(count%Column==0)
            {
                HtmlGenericControl g=new HtmlGenericControl("div");
                g.Attributes.Add("class","clear");
                e.Item.Controls.Add(g);
            }
        }
    }
}