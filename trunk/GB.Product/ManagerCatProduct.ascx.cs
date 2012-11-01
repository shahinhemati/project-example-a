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

namespace IB.Product
{
    public partial class ManagerCatProduct : V_Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var catpr = from ct in Data.CV_CatProducts
                            where ct.PortalID==PortalId
                            select ct;
                rpt.DataSource = catpr;
                rpt.DataBind();

            }
        }

        protected void DeleteCatproduct_Click(object sender, EventArgs e)
        {
            int catid = int.Parse((sender as LinkButton).CommandArgument);
            DeleteCate(catid);
            Response.Redirect(EditUrl("CatProduct"));

        }


        public void DeleteCate(int ctid)
        {

            var cats = from c in Data.CV_CatProducts
                       where c.PortalID==PortalId && (c.ParentID.HasValue ? c.ParentID.Value : -1) == ctid
                       select c;
            if (cats.Count() > 0)
            {
                foreach (CV_CatProduct c in cats)
                {
                    DeleteCate(c.CatID);
                }
            }

            var products = from pr in Data.CV_Products 
                           where pr.CatID == ctid 
                           select pr;
            Data.CV_Products.DeleteAllOnSubmit(products);
            Data.SubmitChanges();


            var cat = (from c in Data.CV_CatProducts
                       where c.CatID == ctid 
                       select c).FirstOrDefault();
            if (cat != null)
            {
                Data.CV_CatProducts.DeleteOnSubmit(cat);
                Data.SubmitChanges();
            }
        }

    }
}