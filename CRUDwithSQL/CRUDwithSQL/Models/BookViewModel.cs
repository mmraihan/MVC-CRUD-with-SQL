using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDwithSQL.Models
{
    public class BookViewModel
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Sould be greater than 1 or equal 1")]
        public int Price { get; set; }
    }
}
