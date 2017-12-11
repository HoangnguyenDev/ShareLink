using ShareLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Areas.AutoTool.ViewModels
{
    public class AutoGetShareLinkViewModel
    {
        public string URL { get; set; }
        public List<ShareLinkSimple> ListLink { get; set; }
    }
    public class ShareLinkSimple {
        public string URL { get; set; }
        public string Title { get; set; }
    }
}
