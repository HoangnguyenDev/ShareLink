using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Models
{
    public class SLink : Base
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }
        [StringLength(200, MinimumLength = 3)]
        [Required]
        [Display(Name = "Thông điệp chính")]
        public string Name { get; set; }
        public string URL { get; set; }
        [MaxLength(200)]
        [Display(Name = "Thông điệp phụ")]
        public string Description { get; set; }
        [Display(Name = " Slug")]
        [StringLength(200)]
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
