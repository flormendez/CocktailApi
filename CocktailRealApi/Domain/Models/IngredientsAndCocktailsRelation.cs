using CocktailRealApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailRealApi.Domain.Models
{
    public class IngredientsAndCocktailsRelation
    {
         public int CocktailId { get; set; }
        public int IngredientId { get; set; }
       


        public Ingredients Ingredients { get; set; }
        public Cocktail Cocktail { get; set;  } 
    }
}
