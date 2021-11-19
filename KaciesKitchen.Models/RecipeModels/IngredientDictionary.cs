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
            IngredientsList = new Dictionary<int, int>();
        }
        public Dictionary<int, int> IngredientsList { get; set; }
        public IngredientDictionary Add (int ingredientId, int amt)
        {
            IngredientsList.Add(ingredientId, amt);
            return this;
        }
    }
}
