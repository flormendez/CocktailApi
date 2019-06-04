using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailRealApi.Models;

namespace CocktailRealApi.Domain.Repositories
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredients>> ListAsync();
        Task AddAsync(Ingredients ingredients);
        Task<Ingredients> FindByIdAsync(int id);
        void Update(Ingredients ingredients);
        void Remove(Ingredients ingredients);
    }
}
