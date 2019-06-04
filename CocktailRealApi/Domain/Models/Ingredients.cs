using CocktailRealApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailRealApi.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public IList<Cocktail> Cocktails { get; set; } = new List<Cocktail>(); 
        //public List<IngredientsAndCocktailsRelation> IngredientsAndCocktailsRelations { get; set; } = new List<IngredientsAndCocktailsRelation>();
        public IList<IngredientsAndCocktailsRelation> CocktailWith { get; set; }


    }
}
