using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.ProductModels
{
    public class ProductListItem
    {
        public double Price { get; set; }
        public string Description { get; set; }
        [Display(Name ="Recipe")]
        public string RecipeUrl { get; set; }
    }
}
