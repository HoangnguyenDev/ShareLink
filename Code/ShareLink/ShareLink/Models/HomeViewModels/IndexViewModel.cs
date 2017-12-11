using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareLink.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public string Domain { get; set; }
        public long ID { get; set; }
        public string Title { get; set; }
        public int Like { get; set; }
        public int Views { get; set; }
        public ApplicationUser Author { get; set; }
        public Category Category { get; set; }
        public int Comment { get; set; }
        public string ShowCreateDT { get; set; }
        public DateTime? CreateDT { get; set; }
    }
    
}
