using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Category
    {
        //data annotation call key
        [Key]

        // prop id 
        public int Id { get; set; }

        // few more data annotations, Required prop which will fall back to the Key notation, and Display prop which is the view of our "string Name"
        [Required]
        [Display(Name="Category Name")]

        // next we will have a "name" and "display order"
        public string Name { get; set; }

        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }



    }
}
