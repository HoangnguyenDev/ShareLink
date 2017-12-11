using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareLink.Models;
using ShareLink.Models.ShareViewModels;
using ShareLink.Services;

namespace ShareLink.Data
{
    public class ShareLinkRepository : IShareLinkRepository
    {
        private readonly ApplicationDbContext _context;
        public ShareLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string RedirectExternal(long ID)
        {
            var db = _context.SLink.SingleOrDefault(p => p.ID == ID);
            return db.URL;

        }

        public async Task SendLink(ShareLinkViewModel model, ApplicationUser user)
        {
            
            //try
            //{
                ShareLink.Models.SLink shareLink = new ShareLink.Models.SLink
                {
                    Active = "T",
                    Approved = "U",
                    CreateDT = DateTime.Now,
                    AuthorID = user.Id,
                    Slug = StringExtensions.ConvertToUnSign3(model.Title),
                    IsDeleted = false,
                    Note = "",

                    URL = model.Link,
                    CategoryID = model.CategoryID,
                    Description = SEOExtension.GetStringToLength(model.Description,190),
                    Name = SEOExtension.GetStringToLength(model.Title, 190),
                };
            _context.SLink.Add(shareLink);
            _context.SaveChanges();
            //}
            //catch { }
        }
    }
}
