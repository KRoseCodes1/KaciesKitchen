using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Data
{
    public class IngredientListDict
    {
        [Key]
        [Display(Name ="|  Ingredient Name |")]
        public string IngredientName { get; set; }
        [Display(Name ="| Amount Needed |")]
        public decimal AmountNeeded { get; set; }
    }
}
