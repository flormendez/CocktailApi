﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace CocktailRealApi.Resources
{
    public class SaveIngredientResource
    {
         
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }


    
}
}
