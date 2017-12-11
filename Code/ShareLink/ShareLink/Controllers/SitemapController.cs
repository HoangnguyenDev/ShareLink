using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareLink.Data;
using ShareLink.Services;
using Microsoft.EntityFrameworkCore;

namespace ShareLink.Controllers
{
    public class SitemapController : Controller
    {
        public const string APPROVED = "A";
        public const string UNAPPROVED = "U";
        private readonly ApplicationDbContext _blogService;
        public SitemapController(ApplicationDbContext blogService)
        {
            _blogService = blogService;
        }

        [Route("sitemap.xml")]
        public async Task<ActionResult> Sitemap()
        {
            string scheme = HttpContext.Request.Scheme;
            string host = HttpContext.Request.Host.Host;
            string port = HttpContext.Request.Host.Port.ToString();
            string root = string.Format("{0}://{1}", scheme, host);

            // get last modified date of the home page
            var siteMapBuilder = new SitemapBuilder();

            // add the home page to the sitemap
            siteMapBuilder.AddUrl(root, modified: DateTime.UtcNow, changeFrequency: ChangeFrequency.Weekly, priority: 1.0);
            #region song, sheet, chord
            var song = await _blogService.SLink
                .Where(p => p.Approved == Global.APPROVED)
                .Where(p => p.CreateDT <= DateTime.Now)
                .Where(p => !p.IsDeleted)
                .ToListAsync();
            string DIR_SONG = root + "/sharelink/item/click/";
            foreach (var item in song)
            {
                siteMapBuilder.AddUrl(DIR_SONG + item.ID, modified: item.CreateDT, changeFrequency: null, priority: 0.9);
            }
            #endregion
          
            // generate the sitemap xml
            string xml = siteMapBuilder.ToString();
            return Content(xml, "text/xml");
        }
    }
}