using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CocktailRealApi.Domain.Repositories;
using CocktailRealApi.Models;
using CocktailRealApi.Persistence.Contexts;

namespace CocktailRealApi.Persistance.Repositories
{
    public class IngredientRepository : BaseRepository, IIngredientRepository

    {
        public IngredientRepository(AppDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Ingredients>> ListAsync()
        {
            return await _context.Ingredients.Include(p => p.CocktailWith).ToListAsync();
        }

        public async Task AddAsync(Ingredients ingredients)
        {
            await _context.Ingredients.AddAsync(ingredients);
        }
        public async Task<Ingredients> FindByIdAsync(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }

        public void Update(Ingredients ingredients)
        {
            _context.Ingredients.Update(ingredients);
        }

        public void Remove(Ingredients ingredients)
        {
            _context.Ingredients.Remove(ingredients);
        }
    }
}
