using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Models.WidgetViewModels
{
    public class HotWidgetViewModel
    {
        public long ID { get; set; }
        public int Like { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
