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

namespace UICateProduct
{
    public partial class SettingsCatProduct : V_BaseSettings
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void UpdateSettings()
        {
            base.UpdateSettings();
            
            DotNetNuke.Entities.Modules.ModuleController mc = new DotNetNuke.Entities.Modules.ModuleController();
            mc.UpdateModuleSetting(ModuleId, "TabForward",ddlTabFw.SelectedValue);
            mc.UpdateModuleSetting(ModuleId, "catproduct", ddlCatPrds.SelectedValue);


            //thiet lap noi dung template
            mc.UpdateModuleSetting(ModuleId, "filenamelist", ddlListType.SelectedValue);
            mc.UpdateModuleSetting(ModuleId, "tempcontentlist", TemplateContent(FolderList, ddlListType.SelectedValue));


        
 
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

            int _catid = -1;
            if (Settings["catproduct"] != null)
            {
                if (!int.TryParse(Settings["catproduct"].ToString(), out _catid))
                {
                    _catid = -1;
                }
            }

            string _listType = Settings["filenamelist"] == null ? "default" : Settings["filenamelist"].ToString();
            //thiet lap combo box list 
            ddlListType.Items.Clear();
            ddlListType.Items.AddRange(LoadTypeList(FolderList, _listType).ToArray());
            imgPreview.ImageUrl = ControlPath + "/" + FolderList + "/" + _listType + ".gif";
            txtTemplate.Text = TemplateContent(FolderList, _listType);

            LoadCatPrd(_catid);
            LoadTab(_tabfw);

        }

        private void LoadCatPrd(int _catid)
        {
            ddlCatPrds.Items.Clear();
            ddlCatPrds.Items.Add(new ListItem { Text = "Gốc", Value = "-1" });

            var its = from i in V_Base.Data.CV_CatProducts
                      select new ListItem { Value = i.CatID.ToString(),Selected=(_catid==i.CatID) ,Text = i.CatName };
            if (its.Count() > 0)
            {
                ddlCatPrds.Items.AddRange(its.ToArray());
            }

            ddlCatPrds.DataBind();
        }

        private void LoadTab(int _tabfw)
        {
            this.ddlTabFw.Items.Clear();
            DotNetNuke.Entities.Tabs.TabController tc = new DotNetNuke.Entities.Tabs.TabController();
            DotNetNuke.Entities.Tabs.TabCollection tabs = tc.GetTabsByPortal(PortalId);
            System.Collections.Generic.List<ListItem> list = new System.Collections.Generic.List<ListItem>();

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

        protected void btnCancelList_Click(object sender, EventArgs e)
        {
            this.txtTemplate.Text = CurrentTemplateContentList;
        }
        protected void ddlListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtTemplate.Text = TemplateContent(FolderList, ddlListType.SelectedValue);
        }
    }
}