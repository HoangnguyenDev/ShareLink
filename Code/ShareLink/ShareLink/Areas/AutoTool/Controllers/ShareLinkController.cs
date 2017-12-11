using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareLink.Areas.AutoTool.ViewModels;
using ShareLink.Areas.AutoTool.Session;
using HopAmNhacThanh.Areas.AutoGetTool.Services;
using HtmlAgilityPack;
using ShareLink.Areas.AutoTool.Services.NhanDienMau;
using ShareLink.Data;
using ShareLink.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ShareLink.Services;

namespace ShareLink.Areas.AutoTool.Controllers
{
    [Area("AutoTool")]
    [Authorize(Roles = "Admin, Manager")]
    public class ShareLinkController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShareLinkController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("cong-cu-tu-dong/chia-se-link")]
        public async Task<IActionResult> Index(AutoGetShareLinkViewModel model)
        {
            if (model == null)
            {
                model = new AutoGetShareLinkViewModel { ListLink = new List<ShareLinkSimple>() };
            }
            if (!String.IsNullOrEmpty(model.URL))
            {
                string url = "";
                switch (model.URL)
                {
                    case "1":
                        url = "https://vnexpress.net/";
                        break;
                    case "2":
                        url = "http://vietnamnet.vn/";
                        break;
                    case "3":
                        url = "http://dantri.com.vn/";
                        break;
                    default:
                        url = "https://vnexpress.net/";
                        break;
                }

                var result = (await GetLyrics(url));
                model.ListLink = result.ListLink;
                SessionShareLink.SetSessionGoogleSearch(model.ListLink, this.HttpContext);
            }
            return View(model);
        }
        public async Task<IActionResult> Send(string time)
        {
            List<ShareLinkSimple> list = SessionShareLink.GetSessionGoogleSearch(this.HttpContext);
            DateTime newDate = DateTime.Now;
            DateTime oldDate = DateTime.Now;
            foreach (var item in list)
            {
                switch (time)
                {
                    case "1":
                        newDate = oldDate.AddMinutes(10);
                        break;
                    case "2":
                        newDate = oldDate.AddMinutes(30);
                        break;
                    case "3":
                        newDate = oldDate.AddHours(1);
                        break;
                    case "4":
                        newDate = oldDate.AddHours(2);
                        break;
                    case "5":
                        newDate = oldDate.AddHours(6);
                        break;
                    default:
                        newDate = oldDate.AddHours(1);
                        break;
                }
                oldDate = newDate;

                await Create(item, newDate);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task Create(ShareLinkSimple item, DateTime dateTime)
        {
            SLink shareLink = new SLink
            {
                Active = "T",
                Approved = "A",
                AuthorID = (await GetCurrentUser()).Id,
                Note = "",
                CreateDT = dateTime,

                CategoryID = (_context.Category.First()).ID,
                Slug = StringExtensions.ConvertToUnSign3(SEOExtension.GetStringToLength(item.Title, 190)),
                Name = SEOExtension.GetStringToLength(item.Title, 190),
                URL = item.URL,    
            };
            _context.Add(shareLink);

        }
        public async Task<NhanDienShareLinkViewModel> GetLyrics(string url)
        {
            NhanDienShareLinkViewModel listResult = null;
            bool daThem = false;
            try
            {
                string source = await NhanDienMauServices.FormatHtml(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                bool isVnexpress = Vnexpress.Check(doc);
                bool isVietnamnet = Vietnamnet.Check(doc);
                bool isDantri = Dantri.Check(doc);
                if (isVnexpress)
                {
                    listResult = Vnexpress.GetContent(doc, url);
                    daThem = true;
                }
                if (isVietnamnet)
                {
                    listResult = Vietnamnet.GetContent(doc, url);
                    daThem = true;
                }
                if (isDantri)
                {
                    listResult = Dantri.GetContent(doc, url);
                    daThem = true;
                }
            }
            catch { }
            if (!daThem)
                listResult = new NhanDienShareLinkViewModel(new List<ShareLinkSimple>(), "Not Template");

            return listResult;
        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}