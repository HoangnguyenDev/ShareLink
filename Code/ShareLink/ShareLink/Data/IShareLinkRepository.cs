using ShareLink.Models;
using ShareLink.Models.ShareViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Data
{
    public interface IShareLinkRepository
    {
        Task SendLink(ShareLinkViewModel model, ApplicationUser user);
        string RedirectExternal(long ID);
    }
}
