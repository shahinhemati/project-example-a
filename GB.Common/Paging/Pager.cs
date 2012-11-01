using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using DotNetNuke.Entities.Modules;

namespace IB.Paging
{
    public class Pager
    {

        private readonly int pageSize;
        private readonly int currentPage;
        private readonly int totalItemCount;
        private readonly int tabid;
        private readonly List<string> prs = new List<string>();
        private readonly PortalModuleBase pmb = null;
        private readonly string key;

        //GlobalEditURl()
        public Pager(int pageSize, int currentPage, int totalItemCount, int tabid)
        {

            this.pageSize = pageSize;
            this.currentPage = currentPage;
            this.totalItemCount = totalItemCount;
            this.tabid = tabid;

        }

        //GlobalEditURl()
        public Pager(int pageSize, int currentPage, int totalItemCount, int tabid, params  string[] _prs)
        {

            this.pageSize = pageSize;
            this.currentPage = currentPage;
            this.totalItemCount = totalItemCount;
            this.tabid = tabid;
            foreach (string p in _prs)
            {

                prs.Add(p);

            }

        }

        //edit url
        public Pager(int pageSize, int currentPage, int totalItemCount,int tabid,string key, PortalModuleBase _pm, params  string[] _prs)
        {

            this.pageSize = pageSize;
            this.currentPage = currentPage;
            this.totalItemCount = totalItemCount;
            this.tabid = tabid;

            foreach (string p in _prs)
            {

                prs.Add(p);

            }
            this.key = key;
            this.pmb = _pm;


        }

        public string RenderHtml()
        {
            int pageCount = (int)Math.Ceiling(this.totalItemCount / (double)this.pageSize);
            int nrOfPagesToDisplay = 10;

            var sb = new StringBuilder();

            // Previous
            if (this.currentPage > 1)
            {
                sb.Append(GeneratePageLink("&lt;", this.currentPage - 1));
            }
            else
            {
                sb.Append("<span class=\"disabled\">&lt;</span>");
            }

            int start = 1;
            int end = pageCount;

            if (pageCount > nrOfPagesToDisplay)
            {
                int middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
                int below = (this.currentPage - middle);
                int above = (this.currentPage + middle);

                if (below < 4)
                {
                    above = nrOfPagesToDisplay;
                    below = 1;
                }
                else if (above > (pageCount - 4))
                {
                    above = pageCount;
                    below = (pageCount - nrOfPagesToDisplay);
                }

                start = below;
                end = above;
            }

            if (start > 3)
            {
                sb.Append(GeneratePageLink("1", 1));
                sb.Append(GeneratePageLink("2", 2));
                sb.Append("...");
            }
            for (int i = start; i <= end; i++)
            {
                if (i == this.currentPage)
                {
                    sb.AppendFormat("<span class=\"current\">{0}</span>", i);
                }
                else
                {
                    sb.Append(GeneratePageLink(i.ToString(), i));
                }
            }
            if (end < (pageCount - 3))
            {
                sb.Append("...");
                sb.Append(GeneratePageLink((pageCount - 1).ToString(), pageCount - 1));
                sb.Append(GeneratePageLink(pageCount.ToString(), pageCount));
            }

            // Next
            if (this.currentPage < pageCount)
            {
                sb.Append(GeneratePageLink("&gt;", (this.currentPage + 1)));
            }
            else
            {
                sb.Append("<span class=\"disabled\">&gt;</span>");
            }
            return sb.ToString();
        }

        private string GeneratePageLink(string linkText, int pageNumber)
        {

            string url = "";

            string[] prams = new string[((prs == null) ? 0 : prs.Count) + 1];
            prams[0] = "page=" + pageNumber.ToString();

            if (prs != null)
            {
                for (int i = 1; i < prs.Count + 1; i++)
                {
                    prams[i] = prs[i - 1];
                }
            }

            
            // yêu cầu tạo từ Global
            if (pmb == null)
            {
                url = DotNetNuke.Common.Globals.NavigateURL(tabid, "", prams);
            }
            else//tạo từ editurl
            {
                
                url = pmb.EditUrl("","",key, prams);

            }


            string link = "<a href=\"{0}\">{1}</a>";
            link = String.Format(link, url, linkText);

            return link;
        }
    }


}
