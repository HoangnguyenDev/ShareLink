using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareLink.Models.WidgetViewModels;
using Microsoft.EntityFrameworkCore;

namespace ShareLink.Data
{
    public class SidebarRepository : ISidebarRepository
    {
        private readonly ApplicationDbContext _context;
        public SidebarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StyleHomeViewModel> StyleHome()
        {
            return new StyleHomeViewModel { ListHot = await WidgetHot() };
        }

        public async Task<List<HotWidgetViewModel>> WidgetHot()
        {
            var db = await _context.SLink
                .Where(p => p.CreateDT < DateTime.Now)
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Approved == "A")
                .Take(10)
                .ToListAsync();

            List<HotWidgetViewModel> list = new List<HotWidgetViewModel>();
            foreach (var item in db)
            {
                HotWidgetViewModel hotWidgetViewModel = new HotWidgetViewModel
                {
                    ID = item.ID,
                    Slug = item.Slug,
                    Title = item.Name,
                };
                list.Add(hotWidgetViewModel);
            }
            return list;
        }
    }
}
