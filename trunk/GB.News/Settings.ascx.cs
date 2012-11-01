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
using DotNetNuke.Entities.Modules;

namespace IB.News
{
    public partial class Settings : ModuleSettingsBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public override void UpdateSettings()
        {
            base.UpdateSettings();
            int pgsize=10;
            if (Settings["pagesize"] != null) {
                pgsize = int.Parse((string)Settings["pagesize"]);                
            }

            this.txtSize.Text = pgsize.ToString();
        }
        public override void LoadSettings()
        {
            base.LoadSettings();
            if (Settings["pagesize"] != null) {
                int pgsize;
                if (int.TryParse((string)Settings["pagesize"],out pgsize)&&pgsize>0) {
                    ModuleController mc = new ModuleController();
                    mc.UpdateModuleSetting(ModuleId, "pagesize", pgsize.ToString());
                }
            }
        }
    }
}