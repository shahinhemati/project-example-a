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
using DotNetNuke.Common.Utilities;
using System.IO;

namespace UICateNews
{
    public partial class ListCatNews : V_Base
    {

        public int CatIDSelect
        {
            get
            {
                int _catid = -1;
                if (Request["catnews"] != null)
                {
                    _catid = int.Parse(Request["catnews"]);
                }
                return _catid;
            }
        }

        public int CatID
        {
            get
            {
                int _catid = -1;
                if (Settings["CatNews"] != null)
                {
                    if (!int.TryParse(Settings["CatNews"].ToString(), out _catid))
                    {
                        _catid = -1;
                    }
                }
                return _catid;
            }
        }

        private IList ltCat;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string catpath = "//";
                if (CatID != -1)
                {
                    var cat = (from c in Data.CV_CatNews
                               where c.CatID == CatID && c.PortalID == PortalId
                               select c).FirstOrDefault();
                    if (cat != null) catpath = cat.CatPath;
                }

                var cats = from c in Data.CV_CatNews
                           where c.CatPath.Contains(catpath) && c.PortalID == PortalId
                           select c;
                if (cats.Count() > 0)
                {
                    ltCat = cats.ToList();
                    ltDisplay.Text = LoadBaseNodes();
                }
            }
        }


        private string LoadBaseNodes()
        {
            string str = "<ul>";
            int parentid = -1;
            foreach (CV_CatNew cat in ltCat)
            {
                parentid = cat.ParentID.HasValue ? cat.ParentID.Value : -1;
                if (parentid == CatID)
                {
                    str += (CatIDSelect != cat.CatID) ? "<li>" : "<li class=\"ctselected\">";
                    str += "<a href=\"" + WriteUrlCat(TabForward, "catnews=" + cat.CatID.ToString()) + "\">" + cat.CatName + "</a>";
                    str += getChildren(cat);
                    str += "</li>";
                }
            }

            str += "</ul>";

            return str;
        }

        // recursive tree loader. Passes back in a node to retireve its childre
        // until there are no more children for this node.
        private string getChildren(CV_CatNew node)
        {
            bool tagcover = false;
            string rt = "";
            foreach (CV_CatNew cat in ltCat) // locate all children of this category
            {
                if (cat.ParentID.HasValue && cat.ParentID.Value == node.CatID) // found a child
                {
                    if (!tagcover)
                    {
                        rt += "<ul>";
                    }
                    rt += (CatIDSelect != cat.CatID) ? "<li>" : "<li class=\"ctselected\">";
                    rt += "<a href=\"" + WriteUrlCat(TabForward, "catnews=" + cat.CatID.ToString()) + "\">" + cat.CatName + "</a></li>";
                    rt += getChildren(cat); // find this child's children
                    if (!tagcover)
                    {
                        rt += "</ul>";
                        tagcover = true;
                    }
                }
            }

            return rt;
        }
    }
}
