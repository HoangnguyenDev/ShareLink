using ShareLink.Models.WidgetViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Data
{
    public interface ISidebarRepository
    {
        Task<StyleHomeViewModel> StyleHome();
        Task<List<HotWidgetViewModel>> WidgetHot();
    }
}
