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

namespace SlideShow
{
    public partial class Slide : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var itms = from i in Data.CV_SlideItems
                           where  i.PortalID==PortalId
                           select i;
                rpt.DataSource = itms;
                rpt.DataBind();

                if (IsEditable) {

                    this.hplManager.NavigateUrl = EditUrl("ManagerSlide");
                    this.hplManager.Text = "Quản lý";
                
                }
            }
        }

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


       
    }
}