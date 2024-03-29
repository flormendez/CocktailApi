﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailRealApi.Resources
{
    public class CocktailResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public string Instructions { get; set; }
        public CategoryResource Category { get; set; }

        public List<IngredientResource> IngredientsTo { get; set; }
    }
}
