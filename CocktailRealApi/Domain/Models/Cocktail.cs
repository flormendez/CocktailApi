using CocktailRealApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailRealApi.Models
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Instructions { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public IList<IngredientsAndCocktailsRelation> IngredientsTo { get; set; }

    }
}
