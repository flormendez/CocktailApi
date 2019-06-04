using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailRealApi.Models;
using CocktailRealApi.Domain.Services.Comunication;


namespace CocktailsRealApi.Domain.Services
{
    public interface ICocktailService
    {
        Task<IEnumerable<Cocktail>> ListAsync();
        Task<IEnumerable<Cocktail>> IdAsync(int id);
        Task<CocktailResponse> AddAsync(Cocktail cocktail, List<Ingredients> ingredients);
        Task<CocktailResponse> UpdateAsync(int id, Cocktail cocktail);
        Task<CocktailResponse> DeleteAsync(int id);
    }
}