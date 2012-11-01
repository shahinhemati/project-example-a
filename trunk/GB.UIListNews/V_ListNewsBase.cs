using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

namespace UIListNews
{
    public class V_ListNewsBase :IB.Common.Base.V_Base
    {

        public int CatID
        {
            get
            {
                int _catid = -1;
                if (Request["catnews"] == null)
                {
                    if (Settings["CatNews"] != null)
                    {
                        if (!int.TryParse(Settings["CatNews"].ToString(), out _catid))
                        {
                            _catid = -1;
                        }
                    }
                }
                else
                {
                    _catid = int.Parse(Request["catnews"]);
                }
                return _catid;
            }
        }
        
        public int NewsID
        {
            get
            {
                int prdid = -1;
                if (Request["detailnews"] != null)
                {
                    if (!int.TryParse(Request["detailnews"].ToString(), out prdid))
                    {
                        prdid = -1;
                    }
                }
                return prdid;
            }
        }

        
    }
}
