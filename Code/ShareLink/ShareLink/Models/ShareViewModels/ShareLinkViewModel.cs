using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Models.ShareViewModels
{
    public class ShareLinkViewModel
    {
        [DataType(DataType.Url)]
        public string Link { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public int CategoryID { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string CurrentUrl { get; set; }
    }
}
