using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareLink.Data;
using System.Text;

namespace ShareLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _repository;
        private readonly ISidebarRepository _sidebarRepository;
        public HomeController(IHomeRepository repository,
            ISidebarRepository sidebarRepository)
        {
            _repository = repository;
            _sidebarRepository = sidebarRepository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("New");
        }
        [Route("link/new")]
        public async Task<IActionResult> New()
        {
            var application = await _repository.GetIndex();
            ViewData["sidebar"] = await _sidebarRepository.StyleHome();
            return View("index", application);
        }
        [Route("link/hot")]
        public async Task<IActionResult> Hot()
        {
            ViewData["sidebar"] = await _sidebarRepository.StyleHome();
            var application = await _repository.GetIndex();
            return View("index",application);
        }
        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Error()
        {
            return View();
        }

        [Route("robots.txt", Name = "GetRobotsText")]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("User-agent: *");
            stringBuilder.AppendLine("Disallow: /quan-ly-web/");
            stringBuilder.AppendLine("Disallow: /WebManager/");
            stringBuilder.AppendLine("Disallow: /wwwroot");
            stringBuilder.AppendLine("User-agent: Googlebot-Image");
            stringBuilder.AppendLine("Allow: /wwwroot/images");
            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }
    }
}
