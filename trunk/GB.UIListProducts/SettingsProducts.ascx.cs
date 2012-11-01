﻿using System;
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

namespace UIListProducts
{
    public partial class SettingsProducts : V_BaseSettings
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void UpdateSettings()
        {
            base.UpdateSettings();
            DotNetNuke.Entities.Modules.ModuleController mc = new DotNetNuke.Entities.Modules.ModuleController();
            mc.UpdateModuleSetting(ModuleId, "TabForward", ddlTabFw.SelectedValue);
            mc.UpdateModuleSetting(ModuleId, "PageSize", txtSize.Text);
            mc.UpdateModuleSetting(ModuleId, "CatProduct", ddlCat.SelectedValue);
            mc.UpdateModuleSetting(ModuleId, "NoPrice", txtNoPrice.Text.Trim());


            ////thiet lap noi dung template
            //mc.UpdateModuleSetting(ModuleId, "filenamelist", ddlListType.SelectedValue);
            //mc.UpdateModuleSetting(ModuleId, "tempcontentlist", TemplateContent(FolderList, ddlListType.SelectedValue));

            ////thiet lap template detail
            //mc.UpdateModuleSetting(ModuleId, "filenamedetail", ddlTempDetail.SelectedValue);
            //mc.UpdateModuleSetting(ModuleId, "tempcontentdetail", TemplateContent(FolderRelative, ddlTempDetail.SelectedValue));

            ////thiet lap template Relative
            //mc.UpdateModuleSetting(ModuleId, "filenamerelative", ddlTempDetail.SelectedValue);
            //mc.UpdateModuleSetting(ModuleId, "tempcontentrelative", TemplateContent(FolderRelative, ddlTempRelative.SelectedValue));


        }


        public override void LoadSettings()
        {
            base.LoadSettings();

            int _tabfw = TabId;
            if (Settings["TabForward"] != null)
            {
                if (!int.TryParse(Settings["TabForward"].ToString(), out _tabfw))
                {
                    _tabfw = TabId;
                }
            }

            int _size = new V_Base().PageSize;
            if (Settings["PageSize"] != null)
            {
                if (!int.TryParse(Settings["PageSize"].ToString(), out _size) || _size < 1)
                {
                    _size = new V_Base().PageSize;
                }
            }

            int _cat = -1;
            if (Settings["CatProduct"] != null)
            {
                if (!int.TryParse(Settings["CatProduct"].ToString(), out _cat))
                {
                    _cat = -1;
                }
            }

            if (Settings["NoPrice"] != null)
            {
                txtNoPrice.Text = Settings["NoPrice"].ToString();
            }
            else
            {
                txtNoPrice.Text = "Call";
            }


            //string _listType = Settings["filenamelist"] == null ? "default" : Settings["filenamelist"].ToString();

            TempService tsService = new TempService(this);

            //List 
            List<string> lt = tsService.GetFileLists(TypeTemp.List, "gif");
            List<ItemTemp> itemTemps = new List<ItemTemp>();
            for (int i = 0; i < lt.Count; i++)
            {
                itemTemps.Add(new ItemTemp { NameImage = lt[i], NameTemp = lt[i].Replace(".gif", ".htm") });
            }
            rptList.DataSource = itemTemps;
            rptList.DataBind();
            txtList.Text = tsService.GetContentTempFromDB(TypeTemp.List);

            //detail
            lt = tsService.GetFileLists(TypeTemp.Detail, "gif");
            itemTemps.Clear();
            for (int i = 0; i < lt.Count; i++)
            {
                itemTemps.Add(new ItemTemp { NameImage = lt[i], NameTemp = lt[i].Replace(".gif", ".htm") });
            }
            rptDetail.DataSource = itemTemps;
            rptDetail.DataBind();
            txtDetail.Text = tsService.GetContentTempFromDB(TypeTemp.Detail);

            //Relative
            lt = tsService.GetFileLists(TypeTemp.Relative, "gif");
            itemTemps.Clear();
            for (int i = 0; i < lt.Count; i++)
            {
                itemTemps.Add(new ItemTemp { NameImage = lt[i], NameTemp = lt[i].Replace(".gif", ".htm") });
            }
            rptRelative.DataSource = itemTemps;
            rptRelative.DataBind();
            txtRelative.Text = tsService.GetContentTempFromDB(TypeTemp.Relative);

            //tao cat
            LoadCat(_cat);
            this.txtSize.Text = _size.ToString();
            LoadTab(_tabfw);
        }

        private void LoadCat(int _cat)
        {
            ddlCat.Items.Clear();
            ddlCat.Items.Add(new ListItem { Value = "-1", Text = "Tất cả", Selected = (_cat == -1) });

            var cat = from c in V_Base.Data.CV_CatProducts
                      where c.PortalID == PortalId
                      select new ListItem { Selected = (c.CatID == _cat), Text = c.CatName, Value = c.CatID.ToString() };
            if (cat.Count() > 0)
            {
                ddlCat.Items.AddRange(cat.ToArray());
                ddlCat.DataBind();
            }
        }

        private void LoadTab(int _tabfw)
        {
            this.ddlTabFw.Items.Clear();

            // hien thi các tab không phải admin trong portal này
            DotNetNuke.Entities.Tabs.TabController tc = new DotNetNuke.Entities.Tabs.TabController();
            DotNetNuke.Entities.Tabs.TabCollection tabs = tc.GetTabsByPortal(PortalId);
            System.Collections.Generic.List<ListItem> list = new System.Collections.Generic.List<ListItem>();

            //kiem? tra neu portal nay co nhieu hon 1 ngon ngu 
            //thi chi chon danh sach cac tab thuoc ngon ngu dang chon 
            //neu cos 1 ngon ngu thi tai ca 


            //get current culturecode in combobox language 

            foreach (var tab in tabs.Values)
            {
                if (!tab.TabPath.StartsWith("//Admin") && !tab.TabPath.StartsWith("//Host") && !tab.IsSecure && !tab.IsDeleted)
                {
                    list.Add(new ListItem { Value = tab.TabID.ToString(), Text = tab.TabName, Selected = (tab.TabID == _tabfw) });
                }
            }

            this.ddlTabFw.Items.AddRange(list.ToArray());
            this.ddlTabFw.DataBind();

        }

        #region Change template


        #endregion

        protected void ChangeFileList_OnClick(object sender, EventArgs e)
        {
            TempService tsService = new TempService(this);
            Button b = (Button)sender;
            this.txtList.Text = tsService.GetContentFromFile(TypeTemp.List, b.CommandArgument);
        }

        protected void SaveListTemp_OnClick(object sender, EventArgs e)
        {
            TempService tsService = new TempService(this);
            tsService.SaveContentFileTempToDB(TypeTemp.List, this.txtList.Text);
        }

        protected void SaveDetailTemp_OnClick(object sender, EventArgs e)
        {
            TempService tsService = new TempService(this);
            tsService.SaveContentFileTempToDB(TypeTemp.Detail, this.txtDetail.Text);
        }

        protected void ChangeFileDetail_OnClick(object sender, EventArgs e)
        {
            TempService tsService = new TempService(this);
            Button b = (Button)sender;
            this.txtDetail.Text = tsService.GetContentFromFile(TypeTemp.Detail, b.CommandArgument);
        }

        protected void SaveRelativeTemp_OnClick(object sender, EventArgs e)
        {
            TempService tsService = new TempService(this);
            tsService.SaveContentFileTempToDB(TypeTemp.Relative, this.txtRelative.Text);
        }

        protected void ChangeFileRelative_OnClick(object sender, EventArgs e)
        {
            TempService tsService = new TempService(this);
            Button b = (Button)sender;
            this.txtRelative.Text = tsService.GetContentFromFile(TypeTemp.Relative, b.CommandArgument);
        }

    }
}