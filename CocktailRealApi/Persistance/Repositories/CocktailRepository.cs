using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CocktailRealApi.Models;
using CocktailRealApi.Domain.Repositories;
using CocktailRealApi.Persistence.Contexts;
using CocktailRealApi.Domain.Models;

namespace CocktailRealApi.Persistance.Repositories
{
    public class CocktailRepository : BaseRepository, ICocktailRepository
    {
        public CocktailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cocktail>> ListAsync()
        {
           var response = await _context.Cocktails.Include(p => p.Category).Include(p => p.IngredientsTo).ThenInclude(p => p.Ingredients).ToListAsync();
            return response;
                                      
        }


        public async Task<IEnumerable<Cocktail>> IdAsync(int id)
        {
            //ver como implementar obtener entidad con ID con EF y no con QUERYS de SQL
            //return await _context.Cocktails.Include(p => p.Category).Single(el => el.Id==id);
            var query = await _context.Cocktails.FromSql("SELECT * from dbo.Cocktails WHERE Id={0}", id).ToListAsync();
            return query;
        }

        public async Task<Cocktail> FindByIdAsync(int id)
        {
            return await _context.Cocktails.FindAsync(id);
        }

            public async Task AddAsync(Cocktail cocktail, List<Ingredients> ingredients)
        {
           var result = await _context.Cocktails.AddAsync(cocktail);


            foreach (Ingredients ing in ingredients)
            {
                var ingRelation = new IngredientsAndCocktailsRelation();

                ingRelation.CocktailId = result.Entity.Id;

                ingRelation.IngredientId = ing.Id;

                await _context.Set<IngredientsAndCocktailsRelation>().AddAsync(ingRelation);

            }
        }

        public void Update(Cocktail cocktail)
        {
            _context.Cocktails.Update(cocktail);
        }

        public void Remove(Cocktail cocktail)
        {
            _context.Cocktails.Remove(cocktail);
        }

    }
}
