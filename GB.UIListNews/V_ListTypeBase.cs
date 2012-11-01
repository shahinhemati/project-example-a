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

namespace UIListNews
{
    public class V_ListTypeBase : UserControl
    {

        private V_ListNewsBase  parent;
        public V_ListNewsBase ParentLoad
        {
            set { parent = value; }
            get { return parent; }
        }
    }
}
