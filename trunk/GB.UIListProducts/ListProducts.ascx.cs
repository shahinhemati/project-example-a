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
using IB.Paging;
using IB.Common.Entities;

namespace UIListProducts
{
    public partial class ListProducts : V_UIProductBase
    {
        private TempService tempService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            tempService = new TempService(this);
            if (!IsPostBack)
            {
                if (ProductID == -1)
                {
                    var products = from nw in Data.CV_Products
                                   join cat_ in Data.CV_CatProducts on nw.CatID equals cat_.CatID
                                   where (nw.CatID == CatID || CatID == -1) && (cat_.PortalID == PortalId)
                                   orderby nw.ProductID descending
                                   select new ProductInfo
                                              {
                                                  Content = nw.Content,
                                                  CreateDate = nw.CreatedDate.Value,
                                                  Id = nw.ProductID,
                                                  ImageThumUrl = GetWebImgOf(LocationImage.Product,nw.ImageName),
                                                  Price = ConvertPrice(nw.Price),
                                                  ShortContent = nw.ShortContent,
                                                  Title = nw.Title,
                                                  Url = WriteUrl(TabId.ToString(), "detailproduct", nw.ProductID.ToString(), nw.Title)
                                              };

                    //1 . chuyen truy van thanh list

                    PagedList<ProductInfo> pl = new PagedList<ProductInfo>(products, PageCurr - 1, PageSize);

                    if (pl.Count > 0)
                    {
                        //2 . gan vao repeater

                        rptproducts.DataSource = pl;
                        rptproducts.DataBind();

                        //3 . chuyen thanh thanh phan trang

                        Pager pg = new Pager(PageSize, PageCurr, pl.TotalItemCount, TabId);

                        //4. tao thanh phan trang

                        pnPaging.Text = pg.RenderHtml();
                    }
                    mv.SetActiveView(vList);
                }
                else
                {
                    ProductDetail c = (ProductDetail)Page.LoadControl(ControlPath + "/ProductDetail.ascx");
                    c.ListProduct = this;
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
            ProductInfo item = (ProductInfo)e.Item.DataItem;
            ProductTokenReplace newsTokenReplace = new ProductTokenReplace(item);
            string str = newsTokenReplace.ReplaceProductInfo(tempService.GetContentTempFromDB(TypeTemp.List));
            Literal lt = new Literal();
            lt.Text = str;
            e.Item.Controls.Add(lt);
            if (count % Column == 0)
            {
                HtmlGenericControl g = new HtmlGenericControl("div");
                g.Attributes.Add("class", "clear");
                e.Item.Controls.Add(g);
            }
        }
    }
}