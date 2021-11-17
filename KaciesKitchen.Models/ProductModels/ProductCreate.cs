using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Models.ProductModels
{
    public class ProductCreate
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public int RecipeID { get; set; }
    }
}
