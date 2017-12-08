﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Models
{
    public class ShareLink : Base
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Thông điệp chính")]
        public string Name { get; set; }
        [MaxLength(200)]
        [Display(Name = "Thông điệp phụ")]
        public string Description { get; set; }
        [Display(Name = " Slug")]
        [MaxLength(30)]
        [Required]
        public string Slug { get; set; }
        [Display(Name = "Kênh")]
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Lượt xem")]
        public int Views { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Like> Like { get; set; }
        [Display(Name = "Loại nội dung")]
        public TypeContent Type { get; set; }
    }
    public enum TypeContent
    {
        Undefine,
        Old16,
    };
}
