using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareLink.Models.HomeViewModels;
using Microsoft.EntityFrameworkCore;
using ShareLink.Services;
using Microsoft.AspNetCore.Http;

namespace ShareLink.Data
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeRepository(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<IndexViewModel>> GetIndex()
        {
            var db = await _context.SLink
                .Where(p => p.CreateDT < DateTime.Now)
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Approved == "A")
                .Include(p => p.Author)
                .Include(p => p.Category)

                .ToListAsync();
            List<IndexViewModel> listIndex = new List<IndexViewModel>();
            foreach (var item in db)
            {
                IndexViewModel indexViewModel = new IndexViewModel
                {
                    ID = item.ID,
                    Like = 0,
                    Title = item.Name,
                    Views = item.Views,
                    ShowCreateDT = DateTimeExtension.CurrentDay(item.CreateDT.Value),
                    Domain = _httpContextAccessor.HttpContext.Request.Scheme,
                    CreateDT = item.CreateDT,
                    Author = item.Author,
                    Category = item.Category
                };
                listIndex.Add(indexViewModel);
            }
            return listIndex.OrderByDescending(p => p.CreateDT).Take(30).ToList();
        }
    }
}
