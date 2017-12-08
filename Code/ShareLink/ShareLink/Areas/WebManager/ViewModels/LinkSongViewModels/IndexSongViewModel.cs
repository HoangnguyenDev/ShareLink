﻿using HopAmNhacThanh.Areas.WebManager.ViewModels.CommonViewModels;
using HopAmNhacThanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HopAmNhacThanh.Areas.WebManager.ViewModels.LinkSongViewModels
{
    public class IndexLinkSongViewModel : PageListItemTemplate
    {
        public List<SimpleIndexLinkSongViewModel> ListLinkSong { get; set; }
    }
    public class SimpleIndexLinkSongViewModel : BaseIndexViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long? SongID { get; set; }
        public Song Song { get; set; }
        [MaxLength(5)]
        [Display(Name = "Tông chủ")]
        public string Tone { get; set; }
        [Required]
        [Display(Name = "Link")]
        public string Link { get; set; }
        [Display(Name = "Tên ca sỹ")]
        public int? SingleSongID { get; set; }
        public SingleSong SingleSong { get; set; }

    }
}
