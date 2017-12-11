using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareLink.Data;
using Microsoft.AspNetCore.Identity;
using ShareLink.Models;
using ShareLink.Models.ShareViewModels;

namespace ShareLink.Controllers
{
    public class ShareLinkController : Controller
    {
        private readonly IShareLinkRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShareLinkController(IShareLinkRepository repository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _repository = repository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Route("sharelink/item/click/{id}")]
        public IActionResult Click(int id)
        {
            string url = _repository.RedirectExternal(id);
            //return Content("<script>window.location = '"+url+"';</script>");
            return Redirect(url);
        }

        [HttpPost]
        public async Task<IActionResult> SendLink(ShareLinkViewModel model)
        {
            var user = await GetCurrentUserAsync();
            await _repository.SendLink(model, user);
            return LocalRedirect(model.CurrentUrl);
        }


        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}