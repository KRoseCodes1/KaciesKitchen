using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Date Created")]
        [Required]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Last Updated")]
        public DateTimeOffset? LastUpdated { get; set; }
        [Required]
        [Display(Name="List of Ingredients & Amounts")]
        public List<KeyValuePair<Ingredient, int>> IngredientsUsed { get; set; }
    }
}
