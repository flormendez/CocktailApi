using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailRealApi.Models;
using CocktailRealApi.Domain.Services.Comunication;

namespace CocktailRealApi.Domain.Services
{
    public interface ICategoryServices
    {   //  The implementations of the ListAsync method must asynchronously return an enumeration of categories.
        
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}
