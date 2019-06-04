using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailRealApi.Domain.Services.Comunication;
using CocktailRealApi.Models;

namespace CocktailRealApi.Domain.Repositories
{
    public interface ICocktailRepository
    {
        Task<IEnumerable<Cocktail>> ListAsync();
        Task<IEnumerable<Cocktail>> IdAsync(int id);
        Task AddAsync(Cocktail cocktail, List<Ingredients> ingredients);
        Task<Cocktail> FindByIdAsync(int id);
        void Update(Cocktail cocktail);
        void Remove(Cocktail cocktail);



       


    }
}
