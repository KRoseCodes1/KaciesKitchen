using KaciesKitchen.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.RecipeModels
{
    public class RecipeCreate
    {
        [MinLength(2, ErrorMessage="Name is too short.")]
        [MaxLength(30, ErrorMessage ="Name is too long.")]
        public string Name { get; set; }
        [MinLength(5, ErrorMessage ="Cannot leave empty: please enter valid directions.")]
        public string Directions { get; set; }
        public Dictionary<KaciesKitchen.Data.Ingredient,int> IngredientDictionary { get; set; }
    }
}
