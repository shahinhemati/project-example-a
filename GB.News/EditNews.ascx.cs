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
    public partial class EditNews : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["newsid"] != null)
            {
                LoadNews();
            }
            if(!IsPostBack)   InnitCBCat();
            
        }

        private void InnitCBCat()
        {
            int newsid = Request["newsid"] == null ? -1 : int.Parse(Request["newsid"]);
            int catid = -1;
            
                if (newsid != -1)
                {

                    var news = (from n in Data.CV_News
                                where n.NewsID == newsid
                                select n).FirstOrDefault();
                    if (news != null)
                    {
                        catid = news.CatNewsID.Value;
                    }
                }
           
            System.Collections.Generic.List<ListItem> cats = new System.Collections.Generic.List<ListItem>();
            var catnews = from cn in Data.CV_CatNews
                          where  cn.PortalID==PortalId
                          select new ListItem { Value = cn.CatID.ToString(), Selected = cn.CatID == catid, Text = cn.CatName };

            foreach (var c in catnews)
            {
                cats.Add(c);
            }

            this.ddlCatNews.Items.Clear();
            this.ddlCatNews.Items.AddRange(cats.ToArray());

        }

        private void LoadNews()
        {
            int newid;
            if (int.TryParse(Request["newsid"].ToString(), out newid))
            {

                var news = (from n in Data.CV_News
                            where n.NewsID == newid
                            select n).FirstOrDefault();

                if (news != null && !IsPostBack)
                {

                    txtTitle.Text = news.Title;
                    txtDes.Text = news.ShortContent;
                    (txtContent as DotNetNuke.UI.UserControls.TextEditor).RichText.Text = news.Content;
                    img_P.ImageUrl = GetWebImageOfThumb(LocationImage.News, news.ImageName);
                        
                }
            }
        }

        private void UpdateNews()
        {
            int newid;
            if (int.TryParse(Request["newsid"].ToString(), out newid))
            {

                var news = (from n in Data.CV_News
                            where n.NewsID == newid
                            select n).FirstOrDefault();

                if (news != null)
                {

                    news.Title = txtTitle.Text.Trim();
                    news.ShortContent = txtDes.Text.Trim();
                    news.Content = (txtContent as DotNetNuke.UI.UserControls.TextEditor).RichText.Text;
                    news.CatNewsID = int.Parse(ddlCatNews.SelectedValue);

                    if (flImge.HasFile)
                    {
                        string imagename = SaveImage(flImge.FileContent, flImge.FileName, LocationImage.News);
                        news.ImageName = imagename;
                    }

                    Data.SubmitChanges();
                    Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId));
                }
            }
        }


        protected void SaveNews_Click(object sender, EventArgs e)
        {
            if (Request["newsid"] != null)
            {
                UpdateNews();
            }
            else
            {
                CreateNews();
            }
        }

        private void CreateNews()
        {

            var news = new CV_New
            {
                Title = txtTitle.Text.Trim(),
                CreatedDate = DateTime.Now.Date,
                ShortContent = txtDes.Text.Trim(),
                Content = (txtContent as DotNetNuke.UI.UserControls.TextEditor).RichText.Text,
                CatNewsID = int.Parse(ddlCatNews.SelectedValue),
                ImageName="no_img.gif"
            };

            if (flImge.HasFile)
            {
                string imagename = SaveImage(flImge.FileContent, flImge.FileName, LocationImage.News);
                news.ImageName = imagename;
            }

            Data.CV_News.InsertOnSubmit(news);
            Data.SubmitChanges();

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId));
        }
    }
}