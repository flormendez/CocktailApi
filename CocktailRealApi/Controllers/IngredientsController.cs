using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CocktailRealApi.Domain.Services;
using CocktailRealApi.Models;
using CocktailRealApi.Resources;
using CocktailRealApi.Extensions;
namespace CocktailRealApi.Controllers
{
    [Route("api/[controller]")]
   
    public class IngredientsController : Controller
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientsController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientResource>> GetAllAsync()

        {
            var ingredients = await _ingredientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Ingredients>, IEnumerable<IngredientResource>>(ingredients);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveIngredientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ingredient = _mapper.Map<SaveIngredientResource, Ingredients>(resource);
            var result = await _ingredientService.SaveAsync(ingredient);

            if (!result.Success)
                return BadRequest(result.Message);

            var ingredientResource = _mapper.Map<Ingredients, IngredientResource>(result.Ingredients);
            return Ok(ingredientResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIngredientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ingredient = _mapper.Map<SaveIngredientResource, Ingredients>(resource);
            var result = await _ingredientService.UpdateAsync(id, ingredient);

            if (!result.Success)
                return BadRequest(result.Message);

            var ingredientResource = _mapper.Map<Ingredients, IngredientResource>(result.Ingredients);
            return Ok(ingredientResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ingredientService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var ingredientResource = _mapper.Map<Ingredients, IngredientResource>(result.Ingredients);
            return Ok(ingredientResource);
        }
    }
}
