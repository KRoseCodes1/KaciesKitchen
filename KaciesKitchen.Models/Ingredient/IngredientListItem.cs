using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.Ingredient
{
    public class IngredientListItem
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        [Display(Name="Unit of Measurement")]
        public string Unit { get; set; }
        [Display(Name="Price Per Unit")]
        public double Cost { get; set; }
    }
}
