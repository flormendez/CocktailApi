using System.Collections.Generic;
using System.Threading.Tasks;
using CocktailRealApi.Models;
using CocktailRealApi.Domain.Services;
using CocktailRealApi.Domain.Repositories;
using CocktailRealApi.Domain.Services.Comunication;
using System;

namespace CocktailRealApi.Services
{
    public class IngredientService : IIngredientService
    {

        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ingredients>> ListAsync()
        {
            return await _ingredientRepository.ListAsync();
        }

        public async Task<IngredientResponse> SaveAsync(Ingredients ingredient)
        {
            try
            {
                await _ingredientRepository.AddAsync(ingredient);
                await _unitOfWork.CompleteAsync();

                return new IngredientResponse(ingredient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new IngredientResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        //public Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<IngredientResponse> UpdateAsync(int id, Ingredients ingredient)
        {
            var existingIngredient = await _ingredientRepository.FindByIdAsync(id);

            if (existingIngredient == null)
                return new IngredientResponse("Category not found.");

            existingIngredient.Name = ingredient.Name;

            try
            {
                _ingredientRepository.Update(existingIngredient);
                await _unitOfWork.CompleteAsync();

                return new IngredientResponse(existingIngredient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new IngredientResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }
        public async Task<IngredientResponse> DeleteAsync(int id)
        {
            var existingIngredient = await _ingredientRepository.FindByIdAsync(id);

            if (existingIngredient == null)
                return new IngredientResponse("Category not found.");

            try
            {
                _ingredientRepository.Remove(existingIngredient);
                await _unitOfWork.CompleteAsync();

                return new IngredientResponse(existingIngredient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new IngredientResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}

