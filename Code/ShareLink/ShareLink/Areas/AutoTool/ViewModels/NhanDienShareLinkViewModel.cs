using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Areas.AutoTool.ViewModels
{
    public class NhanDienShareLinkViewModel
    {
        public List<ShareLinkSimple> ListLink { get; set; }


        public string Template { get; set; }

        public NhanDienShareLinkViewModel(List<ShareLinkSimple>  ListLink, string Template)
        {
            this.ListLink = ListLink;
            this.Template = Template;
        }
    }
}
