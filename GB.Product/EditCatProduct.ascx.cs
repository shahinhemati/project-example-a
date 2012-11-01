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
    public partial class EditCatProduct : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["catid"] != null)
            {
                LoadCatToForm();
            }
            if (!IsPostBack)
            {
                LoadCat();
            }
        }

        /// <summary>
        /// Thiết lập combobox 
        /// Yêu cầu : 
        /// 1 - Không hiển thị các mục con của nó vào combobox
        /// 2 - Mặc định mục gốc là có giá trị -1
        /// 3 - Không thuộc mục nào thì có parentid = null
        /// 4 - Nếu là thao tác thêm mới thì hiển thị tất cả
        /// </summary>
        private void LoadCat()
        {
            int _catid = -1;
            if (Request["catid"] != null)
            {
                if (!int.TryParse(Request["catid"].ToString(), out _catid))
                {
                    _catid = -1;
                }
            }

            int parentcatid = -1;
            string parentcatpath = "";
            if (_catid != -1)
            {
                var cat = (from c in Data.CV_CatProducts
                           where c.CatID == _catid && c.PortalID==PortalId
                           select c).FirstOrDefault();
                if (cat != null && cat.ParentID.HasValue)
                {
                    parentcatid = cat.ParentID.Value;
                }
                parentcatpath = cat.CatPath;
            }

            ddlCatPrd.Items.Clear();
            ddlCatPrd.Items.Add(new ListItem { Text = "Gốc", Value = "-1" });

            var its = from i in V_Base.Data.CV_CatProducts
                      where ( !i.CatPath.Contains(parentcatpath) || _catid == -1) && i.PortalID==PortalId
                      select new ListItem { Value = i.CatID.ToString(), Selected = (parentcatid == -1) ? false : (parentcatid == i.CatID), Text = i.CatName };
            if (its.Count() > 0)
            {
                ddlCatPrd.Items.AddRange(its.ToArray());
            }

            ddlCatPrd.DataBind();
        }


        private void LoadCatToForm()
        {
            if (Request["catid"] != null)
            {
                //cap nhat tin tuc
                int catid = 0;
                if (int.TryParse(Request["catid"].ToString(), out catid))
                {
                    var catprds = (from c in Data.CV_CatProducts
                                   where c.CatID == catid
                                   select c).FirstOrDefault();

                    if (catprds != null && !IsPostBack)
                    {
                        txtCatProductsName.Text = catprds.CatName;
                    }
                }
            }
        }


        /// <summary>
        /// Thêm mới hoặc cập nhật danh mục
        /// Yêu cầu : 
        /// 1 - Tên danh mục không trùng
        /// 2 - Khi cập nhật danh mục phải cập nhật cả tabpath của các danh mục con
        /// 3 - Khi thêm mới thiết lập catpath từ tên danh mục
        /// 4 - Không thuộc mục nào thì có parentid = null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SaveCatProduct_Click(object sender, EventArgs e)
        {
            int? catparent;
            string _writeName = "//" + WriteString(txtCatProductsName.Text.Trim());
            string catpath = _writeName;

            if (int.Parse(ddlCatPrd.SelectedValue) != -1)
            {
                catparent = int.Parse(ddlCatPrd.SelectedValue);

                var catparentObj = (from c in Data.CV_CatProducts
                                    where catparent == c.CatID && c.PortalID==PortalId
                                    select c).FirstOrDefault();

                if (catparentObj != null)
                {
                    catpath = catparentObj.CatPath + "//" + WriteString(txtCatProductsName.Text.Trim());
                }
            }
            else
            {
                catparent = null;
            }

            if (Request["catid"] != null)
            {
                //cap nhat tin tuc
                int catid = 0;
                if (int.TryParse(Request["catid"].ToString(), out catid))
                {

                    var _catCheck = from c in Data.CV_CatProducts
                                    where c.CatPath.Contains(_writeName) && c.CatID != catid && c.PortalID==PortalId
                                    select c;
                    
                    var catprd = (from c in Data.CV_CatProducts
                                  where c.CatID == catid
                                  select c).FirstOrDefault();

                    if (_catCheck.Count() > 0)
                    {
                        //thong bao trung ten
                        ltr.Text = "\"" + txtCatProductsName.Text + "\" đã có vui lòng chọn tên khác";
                        txtCatProductsName.Text = catprd.CatName;
                    }
                    else
                    {
                        string tabpathOlder = "";

                        tabpathOlder = catprd.CatPath;
                        if (catprd != null)
                        {
                            catprd.CatName = txtCatProductsName.Text.Trim();
                            catprd.ParentID = catparent;
                            catprd.CatPath = catpath;

                            var catchild = from c in Data.CV_CatProducts
                                           where c.CatPath.Contains(tabpathOlder) && c.PortalID==PortalId
                                           select c;
                            //cap nhat catpath con
                            foreach (CV_CatProduct cp in catchild)
                            {
                                cp.CatPath = cp.CatPath.Replace(tabpathOlder, catpath);
                            }
                            Data.SubmitChanges();
                            Response.Redirect(EditUrl("CatProduct"));
                        }
                    }
                }
            }
            else
            {
                //kiem tra trung ten danh muc hay khong
                var _catCheck = from c in Data.CV_CatProducts
                                where c.CatPath.Contains(_writeName) && c.PortalID==PortalId
                                select c;
                if (_catCheck.Count() > 0)
                {
                    //thong bao trung ten
                    ltr.Text = "\"" + txtCatProductsName.Text + "\" đã có vui lòng chọn tên khác";
                }
                else
                {
                    //them moi ti
                    var catprd = new CV_CatProduct
                    {
                        CatName = txtCatProductsName.Text.Trim(),
                        ParentID = catparent,
                        CatPath = catpath,
                        PortalID = PortalId
                    };
                    Data.CV_CatProducts.InsertOnSubmit(catprd);
                    Data.SubmitChanges();
                    Response.Redirect(EditUrl("CatProduct"));
                }
            }
        }
    }
}