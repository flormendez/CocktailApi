using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailRealApi.Models;
using CocktailRealApi.Domain.Services.Comunication;

namespace CocktailRealApi.Domain.Services
{
    public interface IIngredientService
    {

        Task<IEnumerable<Ingredients>> ListAsync();
        Task<IngredientResponse> SaveAsync(Ingredients ingredients);
        Task<IngredientResponse> UpdateAsync(int id, Ingredients ingredients);
        Task<IngredientResponse> DeleteAsync(int id);
    }
}
