using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(Recipe))]
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
