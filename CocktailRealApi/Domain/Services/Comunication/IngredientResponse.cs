using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailRealApi.Models;

namespace CocktailRealApi.Domain.Services.Comunication
{
    public class IngredientResponse : BaseResponse
    {
        public Ingredients Ingredients  { get; private set; }

        private IngredientResponse(bool success, string message, Ingredients ingredients) : base(success, message)
        {
            Ingredients = ingredients;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="ingredients">Saved category.</param>
        /// <returns>Response.</returns>
        public IngredientResponse(Ingredients ingredients) : this(true, string.Empty, ingredients)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public IngredientResponse(string message) : this(false, message, null)
        { }
    }
}

