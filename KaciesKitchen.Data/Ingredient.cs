using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string IngredientName { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        [Display(Name ="Price Per Unit")]
        public double PricePerUnit { get; set; }
    }
}
