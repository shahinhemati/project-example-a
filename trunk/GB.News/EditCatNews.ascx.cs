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
using System.Collections.Generic;

namespace IB.News
{
    public partial class EditCatNews : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["catid"] != null)
            {
                LoadCatToForm();
            }
            if (!IsPostBack) { LoadCat(); }

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

                var cat = (from c in Data.CV_CatNews
                           where c.CatID == _catid && c.PortalID==PortalId
                           select c).FirstOrDefault();

                if (cat != null && cat.ParentID.HasValue)
                {
                    parentcatid = cat.ParentID.Value;
                }
                parentcatpath = cat.CatPath;
            }

            ddlCatNews.Items.Clear();
            ddlCatNews.Items.Add(new ListItem { Text = "Gốc", Value = "-1" });

            var its = from i in V_Base.Data.CV_CatNews
                      where (!i.CatPath.Contains(parentcatpath) || _catid == -1) && i.PortalID==PortalId
                      select new ListItem { Value = i.CatID.ToString(), Selected = (parentcatid == -1) ? false : (parentcatid == i.CatID), Text = i.CatName };
            if (its.Count() > 0)
            {
                ddlCatNews.Items.AddRange(its.ToArray());
            }

            ddlCatNews.DataBind();
        }

        private void LoadCatToForm()
        {
            if (Request["catid"] != null)
            {
                //cap nhat tin tuc
                int catid = 0;
                if (int.TryParse(Request["catid"].ToString(), out catid))
                {
                    var catnews = (from c in Data.CV_CatNews
                                   where c.CatID == catid && c.PortalID==PortalId
                                   select c).FirstOrDefault();

                    if (catnews != null)
                    {
                        if (!IsPostBack) txtCatNewsName.Text = catnews.CatName;
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
        protected void SaveCatNews_Click(object sender, EventArgs e)
        {
            int? catparent;
            string rewriteName = "//" + WriteString(txtCatNewsName.Text.Trim());
            string catpath = rewriteName;

            if (int.Parse(ddlCatNews.SelectedValue) != -1)
            {
                catparent = int.Parse(ddlCatNews.SelectedValue);
                var catparentObj = (from c in Data.CV_CatNews
                                    where catparent == c.CatID
                                    select c).FirstOrDefault();

                if (catparentObj != null)
                {
                    catpath = catparentObj.CatPath + "//" + WriteString(txtCatNewsName.Text.Trim());
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
                    //kiem tra co doi ten danh muc trung voi ten danh muc nao khong
                    var _CatCheck = from c in Data.CV_CatNews
                                    where (c.CatPath.Contains(rewriteName) && c.CatID != catid)&&c.PortalID==PortalId
                                    select c;
                    var catnews = (from c in Data.CV_CatNews
                                   where c.CatID == catid && c.PortalID==PortalId
                                   select c).FirstOrDefault();

                    if (_CatCheck.Count() > 0)
                    {

                        //thong bao trung ten
                        ltr.Text = "\""+txtCatNewsName.Text+"\" đã có vui lòng chọn tên khác";
                        txtCatNewsName.Text = catnews.CatName;
                    }
                    else
                    {
                        //cap nhat thay doi vao co so dl
                        string tabpathOlder = "";

                        tabpathOlder = catnews.CatPath;
                        if (catnews != null)
                        {
                            catnews.CatName = txtCatNewsName.Text.Trim();
                            catnews.ParentID = catparent;
                            catnews.CatPath = catpath;

                            //cap nhat cat danh muc con
                            var cats = from c in Data.CV_CatNews
                                       where c.CatPath.Contains(tabpathOlder) && c.PortalID==PortalId
                                       select c;

                            foreach (var c in cats)
                            {
                                c.CatPath = c.CatPath.Replace(tabpathOlder, catpath);
                            }

                            Data.SubmitChanges();
                            Response.Redirect(EditUrl("CatNews"));
                        }
                    }
                }
            }
            else
            {
                //kiem tra da ton tai danh mucj nao trong he thong chua
                var _CatCheck = from c in Data.CV_CatNews
                                where c.CatPath.Contains(rewriteName) && c.PortalID==PortalId
                                select c;
                if (_CatCheck.Count() > 0)
                {

                    //thong bao trung ten
                    ltr.Text = "\"" + txtCatNewsName.Text + "\" đã có vui lòng chọn tên khác";
                }
                else
                {

                    //them moi ti
                    var catnews = new CV_CatNew
                    {
                        CatName = txtCatNewsName.Text.Trim(),
                        ParentID = catparent,
                        CatPath = catpath,
                        PortalID = PortalId
                    };

                    Data.CV_CatNews.InsertOnSubmit(catnews);
                    Data.SubmitChanges();
                    Response.Redirect(EditUrl("CatNews"));
                }

            }
        }
    }
}