using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class Contact
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Mail { get; set; }//must be unick
        public Category? Category { get; set; } //can be null
        public int? CategoryID { get; set; }//can be null
        public SubCategory? SubCategory { get; set; } //can be null
        public int? SubCategoryId { get; set; }
        [Required]
        public string Telepfone { get; set; } 
        public DateTime? Birthdate { get; set; } //can be null



    }
}
