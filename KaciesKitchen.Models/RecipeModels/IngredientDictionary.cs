using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.RecipeModels
{
    public class IngredientDictionary
    {
        public IngredientDictionary()
        {
            IngredientsList = new Dictionary<KaciesKitchen.Data.Ingredient, int>();
        }
        public Dictionary<KaciesKitchen.Data.Ingredient, int> IngredientsList { get; set; }
        public IngredientDictionary Add (KaciesKitchen.Data.Ingredient ing, int amt)
        {
            IngredientsList.Add(ing, amt);
            return this;
        }
    }
}
