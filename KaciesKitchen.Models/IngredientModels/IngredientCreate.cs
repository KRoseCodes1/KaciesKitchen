using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.Ingredient
{
    public class IngredientCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(150, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Unit of Measurement")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Unit { get; set; }
        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage="Does not match specified format.")]
        [Display(Name="Price Per Unit")]
        public decimal PricePerUnit { get; set; }
    }
}
