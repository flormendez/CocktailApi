using AutoMapper;
using CocktailRealApi.Models;
using CocktailRealApi.Resources;


namespace CocktailRealApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<SaveCocktailResource, Cocktail>();

            CreateMap<SaveIngredientResource, Ingredients>();

        }
    }
}
