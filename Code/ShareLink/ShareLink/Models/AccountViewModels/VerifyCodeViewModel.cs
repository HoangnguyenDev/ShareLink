using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Models.AccountViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser this browser?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "ReApplicationUser me?")]
        public bool RememberMe { get; set; }
    }
}
