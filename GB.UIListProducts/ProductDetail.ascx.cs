using System;
using System.Collections;
using System.Collections.Generic;
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
using IB.Common;
using IB.Common.EntityInfo;

namespace UIListProducts
{
    public partial class ProductDetail : V_UIProductBase
    {

        private TempService tempService;
        private ListProducts listProduct = null;

        public TempService TempService
        {
            get { return tempService; }
            set { tempService = value; }
        }

        public ListProducts ListProduct
        {
            get { return listProduct; }
            set { listProduct = value; }
        }
        public void DataBinding()
        {
            var product = (from p in V_Base.Data.CV_Products
                           where p.ProductID == ProductID
                           select new ProductInfo
                                      {
                                          Content = p.Content,
                                          CreateDate = p.CreatedDate.Value,
                                          Id = p.ProductID,
                                          ImageOrgUrl = GetWebImgOf(LocationImage.Product, p.ImageName),
                                          ImageThumUrl = GetWebImageOfThumb(LocationImage.Product, p.ImageName),
                                          Price = ConvertPrice(p.Price),
                                          ShortContent = p.ShortContent,
                                          Title = p.Title,
                                          Url = ListProduct.WriteUrl(ListProduct.TabId.ToString(), "detailproduct", p.ProductID.ToString(), p.Title)
                                      }

                           ).FirstOrDefault();

            if (product != null)
            {
                // hien thi chi tiet san pham
                ProductTokenReplace newsTokenReplace = new ProductTokenReplace(product);
                string str = newsTokenReplace.ReplaceProductInfo(TempService.GetContentTempFromDB(TypeTemp.Detail));
                Literal lt = new Literal();
                lt.Text = str;
                plhDetail.Controls.Add(lt);


                // hien thi cac anh gioi thieu san pham
                var imgs = from im in V_Base.Data.CV_ImageProducts
                           where im.ProductID == ProductID
                           select new ImageInfo
                                      {
                                          ImageOrgUrl = GetWebImgOf(LocationImage.Product, im.FileName),
                                          ImageThumUrl = GetWebImageOfThumb(LocationImage.Product, im.FileName)
                                      };

                rptImgProduct.DataSource = imgs;
                rptImgProduct.DataBind();


                //lay cac san pham lien quan

                var pronewer = (from pr in V_Base.Data.CV_Products
                                join cat_ in V_Base.Data.CV_CatProducts on pr.CatID equals cat_.CatID
                                where pr.ProductID > ProductID && (cat_.PortalID == PortalId)
                                orderby pr.ProductID ascending
                                select new ProductInfo
                                {
                                    Content = pr.Content,
                                    CreateDate = pr.CreatedDate.Value,
                                    Id = pr.ProductID,
                                    ImageOrgUrl = GetWebImgOf(LocationImage.Product, pr.ImageName),
                                    ImageThumUrl = GetWebImageOfThumb(LocationImage.Product, pr.ImageName),
                                    Price = ConvertPrice(pr.Price),
                                    ShortContent = pr.ShortContent,
                                    Title = pr.Title,
                                    Url = ListProduct.WriteUrl(ListProduct.TabId.ToString(), "detailproduct", pr.ProductID.ToString(), pr.Title)
                                }
                           ).Take(10);

                var proolder = (from pr in V_Base.Data.CV_Products
                                join cat_ in V_Base.Data.CV_CatProducts on pr.CatID equals cat_.CatID
                                where pr.ProductID < ProductID && (cat_.PortalID == PortalId)
                                orderby pr.ProductID descending
                                select new ProductInfo
                                {
                                    Content = pr.Content,
                                    CreateDate = pr.CreatedDate.Value,
                                    Id = pr.ProductID,
                                    ImageOrgUrl = GetWebImgOf(LocationImage.Product, pr.ImageName),
                                    ImageThumUrl = GetWebImageOfThumb(LocationImage.Product, pr.ImageName),
                                    Price = ConvertPrice(pr.Price),
                                    ShortContent = pr.ShortContent,
                                    Title = pr.Title,
                                    Url = ListProduct.WriteUrl(ListProduct.TabId.ToString(), "detailproduct", pr.ProductID.ToString(), pr.Title)
                                }).Take(10);
                List<ProductInfo> p = pronewer.ToList();
                p.AddRange(proolder.ToList());
                rptRelative.DataSource = p;
                rptRelative.DataBind();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
           // TempService = new TempService(this);
        }

        protected void OnDataBindingImge(object sender, RepeaterItemEventArgs e)
        {
            ProductInfo item = (ProductInfo)e.Item.DataItem;
            ProductTokenReplace newsTokenReplace = new ProductTokenReplace(item);
            string str = newsTokenReplace.ReplaceProductInfo(tempService.GetContentTempFromDB(TypeTemp.Image));
            Literal lt = new Literal();
            lt.Text = str;
            e.Item.Controls.Add(lt);
        }

        protected void OnDataBindingProduct(object sender, RepeaterItemEventArgs e)
        {
            ProductInfo item = (ProductInfo)e.Item.DataItem;
            ProductTokenReplace newsTokenReplace = new ProductTokenReplace(item);
            string str = newsTokenReplace.ReplaceProductInfo(tempService.GetContentTempFromDB(TypeTemp.Relative));
            Literal lt = new Literal();
            lt.Text = str;
            e.Item.Controls.Add(lt);
        }


        protected void Relative_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            ProductInfo item = (ProductInfo)e.Item.DataItem;
            ProductTokenReplace newsTokenReplace = new ProductTokenReplace(item);
            string str = newsTokenReplace.ReplaceProductInfo(tempService.GetContentTempFromDB(TypeTemp.Relative));
            Literal lt = new Literal();
            lt.Text = str;
            e.Item.Controls.Add(lt);
        }

       
    }
}