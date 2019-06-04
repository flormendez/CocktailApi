using System.Collections.Generic;
using System.Threading.Tasks;
using CocktailRealApi.Models;
using CocktailRealApi.Domain.Services;
using CocktailRealApi.Domain.Repositories;
using CocktailRealApi.Domain.Services.Comunication;
using System;
using CocktailsRealApi.Domain.Services;

namespace CocktailRealApi.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly ICocktailRepository _cocktailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CocktailService(ICocktailRepository cocktailRepository, IUnitOfWork unitOfWork)
        {
            _cocktailRepository = cocktailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cocktail>> ListAsync()
        {
            return await _cocktailRepository.ListAsync();
        }


        public async Task<IEnumerable<Cocktail>> IdAsync(int id)
        {
            return await _cocktailRepository.IdAsync(id);
        }


        public async Task<CocktailResponse> AddAsync(Cocktail cocktail, List<Ingredients> ingredients)
        {
            try
            {
                await _cocktailRepository.AddAsync(cocktail, ingredients);
                await _unitOfWork.CompleteAsync();

                return new CocktailResponse(cocktail);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CocktailResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
        public async Task<CocktailResponse> UpdateAsync(int id, Cocktail cocktail)
        {
            var existingCocktail = await _cocktailRepository.FindByIdAsync(id);

            if (existingCocktail == null)
                return new CocktailResponse("Category not found.");

            existingCocktail.Name = cocktail.Name;

            try
            {
                _cocktailRepository.Update(existingCocktail);
                await _unitOfWork.CompleteAsync();

                return new CocktailResponse(existingCocktail);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CocktailResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }
        public async Task<CocktailResponse> DeleteAsync(int id)
        {
            var existingCocktail = await _cocktailRepository.FindByIdAsync(id);

            if (existingCocktail == null)
                return new CocktailResponse("Cocktail not found.");

            try
            {
                _cocktailRepository.Remove(existingCocktail);
                await _unitOfWork.CompleteAsync();

                return new CocktailResponse(existingCocktail);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CocktailResponse($"An error occurred when deleting the category: {ex.Message}");
            }


        }
    }
}
