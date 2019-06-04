using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CocktailRealApi.Domain.Models;
using CocktailRealApi.Models;
using CocktailRealApi.Resources;

namespace CocktailRealApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Cocktail, CocktailResource>();

            CreateMap<Ingredients, IngredientResource>();

            var ciMap = CreateMap<IngredientsAndCocktailsRelation, IngredientResource>();
            ciMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ingredients.Id));
            ciMap.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredients.Name));

        }
    }
}
