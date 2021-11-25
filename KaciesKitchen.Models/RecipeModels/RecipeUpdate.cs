using KaciesKitchen.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.RecipeModels
{
    public class RecipeUpdate
    {
        public int RecipeId { get; set; }
        [MinLength(2, ErrorMessage = "Name is too short.")]
        [MaxLength(30, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        [MinLength(5, ErrorMessage = "Cannot leave empty: please enter valid directions.")]
        public string Directions { get; set; }
        public List<IngredientListDict> IngredientList { get; set; }
    }
}
