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

namespace IB.Product
{
    public partial class EditProduct : V_Base
    {
        public int ProductID
        {

            get
            {
                int productid=-1;
                if (Request["productid"] != null)
                {
                    if (int.TryParse(Request["productid"].ToString(), out productid))
                    {
                        
                    }
                }

                return productid;
            }
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["productid"] != null)
            {
                LoadProducts();
                
            }
            if (!IsPostBack) InnitCBCat();
        }

        private void InnitCBCat()
        {

            int productid = Request["productid"] == null ? -1 : int.Parse(Request["productid"]);
            int catid = -1;

            if (productid != -1)
            {

                var products = (from n in Data.CV_Products
                                where n.ProductID == productid
                                select n).FirstOrDefault();
                if (products != null)
                {
                    catid = products.CatID.Value;
                }
            }

            System.Collections.Generic.List<ListItem> cats = new System.Collections.Generic.List<ListItem>();
            var catnews = from cn in Data.CV_CatProducts
                          where cn.PortalID==PortalId
                          select new ListItem { Value = cn.CatID.ToString(), Selected = cn.CatID == catid, Text = cn.CatName };

            foreach (var c in catnews)
            {
                cats.Add(c);
            }

            this.ddlCatProduct.Items.Clear();
            this.ddlCatProduct.Items.AddRange(cats.ToArray());

        }

        private void LoadProducts()
        {
            int productid;
            if (int.TryParse(Request["productid"].ToString(), out productid))
            {

                var product = (from n in Data.CV_Products
                               where n.ProductID == productid
                               select n).FirstOrDefault();

                if (product != null && !IsPostBack)
                {

                    txtTitle.Text = product.Title;
                    txtDes.Text = product.ShortContent;
                    (txtContent as DotNetNuke.UI.UserControls.TextEditor).RichText.Text = product.Content;
                    img_P.ImageUrl = GetWebImageOfThumb(LocationImage.Product, product.ImageName);
                    this.txtPrice.Text = product.Price.Value.ToString();
                    LoadImgOfProduct();

                    this.addImage.NavigateUrl = EditUrl("", "", "AddImageToProduct", "productid=" + productid.ToString());
                    this.addImage.Text = "Thêm ảnh vào sản phẩm";
                }
            }
        }

        private void UpdateProduct()
        {
            int productid;
            if (int.TryParse(Request["productid"].ToString(), out productid))
            {

                var product = (from n in Data.CV_Products
                               where n.ProductID == productid
                               select n).FirstOrDefault();

                if (product != null)
                {

                    product.Title = txtTitle.Text.Trim();
                    product.ShortContent = txtDes.Text.Trim();
                    product.Content = (txtContent as DotNetNuke.UI.UserControls.TextEditor).RichText.Text;
                    product.CatID = int.Parse(ddlCatProduct.SelectedValue);
                    product.Price = int.Parse(txtPrice.Text.Trim() == "" ? "0" : txtPrice.Text);
                    if (flImge.HasFile)
                    {
                        string imagename = SaveImage(flImge.FileContent, flImge.FileName, LocationImage.Product);
                        product.ImageName = imagename;
                    }

                    Data.SubmitChanges();
                    Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(TabId));
                }
            }
        }


        protected void SaveProduct_Click(object sender, EventArgs e)
        {
            if (Request["productid"] != null)
            {
                UpdateProduct();
            }
            else
            {
                CreateProduct();
            }
        }

        protected void DeleteImage_Click(object sender, EventArgs e)
        {
            int imgid = int.Parse((sender as LinkButton).CommandArgument);

            var img = (from i in Data.CV_ImageProducts
                      where i.ImageID == imgid
                      select i).FirstOrDefault();
            if (img != null)
            {
                Data.CV_ImageProducts.DeleteOnSubmit(img);
                Data.SubmitChanges();
                LoadImgOfProduct();
              
            }

        
        }

        private void LoadImgOfProduct() { 
        
          var imgs = from i in Data.CV_ImageProducts
                           where i.ProductID == ProductID
                           select i;

                rptimgproduct.DataSource = imgs;
                rptimgproduct.DataBind();
        
        }

        private void CreateProduct()
        {

            var product = new CV_Product
            {
                Title = txtTitle.Text.Trim(),
                CreatedDate = DateTime.Now.Date,
                ShortContent = txtDes.Text.Trim(),
                Content = (txtContent as DotNetNuke.UI.UserControls.TextEditor).RichText.Text,
                CatID = int.Parse(ddlCatProduct.SelectedValue),
                Price = int.Parse(txtPrice.Text.Trim() == "" ? "0" : txtPrice.Text),
                ImageName = "no_img.gif"
            };

            if (flImge.HasFile)
            {
                string imagename = SaveImage(flImge.FileContent, flImge.FileName, LocationImage.Product);
                product.ImageName = imagename;
            }

            Data.CV_Products.InsertOnSubmit(product);
            Data.SubmitChanges();
            Response.Redirect(EditUrl("productid",product.ProductID.ToString(),"AddImageToProduct"));
        }

    }
}