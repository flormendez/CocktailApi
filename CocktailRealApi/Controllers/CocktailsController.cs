using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CocktailRealApi.Models;
using CocktailRealApi.Resources;
using CocktailsRealApi.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CocktailRealApi.Extensions;



namespace CocktailRealApi.Controllers
{
    [Route("api/[controller]")]
   
    public class CocktailsController : Controller
    {
        private readonly ICocktailService _cocktailService;
        private readonly IMapper _mapper;

        public CocktailsController(ICocktailService cocktailService, IMapper mapper)
        {
            _cocktailService = cocktailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CocktailResource>> GetAllAsync()
        {
            var cocktails = await _cocktailService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Cocktail>, IEnumerable<CocktailResource>>(cocktails);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCocktailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cocktail = _mapper.Map<SaveCocktailResource, Cocktail>(resource);
            var result = await _cocktailService.AddAsync(cocktail, resource.Ingredients);

            if (!result.Success)
                return BadRequest(result.Message);

            var cocktailResource = _mapper.Map<Cocktail, CocktailResource>(result.Cocktail);
            return Ok(cocktailResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCocktailResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cocktail = _mapper.Map<SaveCocktailResource, Cocktail>(resource);
            var result = await _cocktailService.UpdateAsync(id, cocktail);

            if (!result.Success)
                return BadRequest(result.Message);

            var cocktailResource = _mapper.Map<Cocktail, CocktailResource>(result.Cocktail);
            return Ok(cocktailResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _cocktailService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var cocktailResource = _mapper.Map<Cocktail, CocktailResource>(result.Cocktail);
            return Ok(cocktailResource);
        }
    }
}
