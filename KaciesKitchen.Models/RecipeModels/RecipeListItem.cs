using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaciesKitchen.Models.RecipeModels
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Ingredients List")]
        public Dictionary<KaciesKitchen.Data.Ingredient, int> IngredientsUsed { get; set; }
        public string Directions { get; set; }
        public decimal Cost { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Last Updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
