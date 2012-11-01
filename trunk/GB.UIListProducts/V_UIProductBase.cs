using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace UIListProducts
{
    public class V_UIProductBase : IB.Common.Base.V_Base
    {

        public int CatID
        {
            get
            {
                int _catid = -1;
                if (Request["CatProduct"] == null)
                {
                    if (Settings["CatProduct"] != null)
                    {
                        if (!int.TryParse(Settings["CatProduct"].ToString(), out _catid))
                        {
                            _catid = -1;
                        }
                    }
                }
                else
                {
                    _catid = int.Parse(Request["CatProduct"]);
                }
                return _catid;
            }
        }

        public string ListType
        {
            get
            {
                string _lttype = "ProductListFull.ascx";
                if (Settings["ListType"] != null)
                {
                    _lttype = Settings["ListType"].ToString();
                }
                return "/ListType/" + _lttype;
            }
        }

        public string ConvertPrice(int? Price)
        {
            return

                (Price.HasValue && Price.Value != 0)
                    ? Price.Value.ToString("##,###,###") + ",000 VND"
                    : NoPrice;
        }
        public int ProductID
        {
            get
            {
                int prdid = -1;
                if (Request["detailproduct"] != null)
                {
                    if (!int.TryParse(Request["detailproduct"].ToString(), out prdid))
                    {
                        prdid = -1;
                    }
                }
                return prdid;
            }
        }

        public string NoPrice
        {
            get
            {
                string str = "Call";
                if (Settings["NoPrice"] != null)
                {
                    str = Settings["NoPrice"].ToString();
                }
                return str;
            }
        }
    }
}
