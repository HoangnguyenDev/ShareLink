using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareLink.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Tên danh mục")]
        [MaxLength(60)]
        public string Name { get; set; }
        public string Description { get; set; }
        public long? ImagesID { get; set; }
        public Images Images { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        [Display(Name = "Ghi chú")]
        public bool IsDeleted { get; set; }
        public string Note { get; set; }
    }
}