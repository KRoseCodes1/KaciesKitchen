using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.RecipeModels
{
    public class IngredientListDict
    {
        public KaciesKitchen.Data.Ingredient Ingredient { get; set; }
        public decimal AmountNeeded { get; set; }
    }
}
