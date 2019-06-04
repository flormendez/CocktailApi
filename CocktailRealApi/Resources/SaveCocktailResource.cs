using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CocktailRealApi.Models;

namespace CocktailRealApi.Resources
{
    public class SaveCocktailResource
    {
 
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Thumb { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public int CategoryId { get; set; }

        //[Required]
        //public CategoryResource Category { get; set; }

        [Required]
        public List<Ingredients> Ingredients { get; set; }

    }
}
