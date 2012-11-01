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
using DotNetNuke.Entities.Modules;

namespace SlideShow
{
    public partial class Settings : DotNetNuke.Entities.Modules.ModuleSettingsBase
    {

        public int WidthSlide
        {
            get
            {
                int _wth = 940;
                if (Settings["WidthSlide"] != null)
                {
                    if (!int.TryParse(Settings["WidthSlide"].ToString(), out _wth))
                    {
                        _wth = 940;
                    }
                }

                return _wth;
            }
        }
        public int HeightSlide
        {
            get
            {
                int _hegt = 300;
                if (Settings["HeightSlide"] != null)
                {
                    if (!int.TryParse(Settings["HeightSlide"].ToString(), out _hegt))
                    {
                        _hegt = 300;
                    }
                }
                return _hegt;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void LoadSettings()
        {
            base.LoadSettings();

            txtWidth.Text = WidthSlide.ToString();
            txtHeight.Text = HeightSlide.ToString();
        }

        public override void UpdateSettings()
        {
            base.UpdateSettings();

            //
            ModuleController mc = new ModuleController();
            mc.UpdateModuleSetting(ModuleId, "WidthSlide", txtWidth.Text);
            mc.UpdateModuleSetting(ModuleId, "HeightSlide", txtHeight.Text);

            
        }
    }
}