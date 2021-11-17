using KaciesKitchen.Data;
using KaciesKitchen.Models.Ingredient;
using KaciesKitchen.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;
        public IngredientService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    IngredientName = model.Name,
                    Unit = model.Unit,
                    PricePerUnit = model.PricePerUnit
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
    public IEnumerable<IngredientListItem> GetIngredient()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx.Ingredients
                .Select(
                   e =>
                   new IngredientListItem
                   {
                       IngredientId = e.IngredientId,
                       Name = e.IngredientName,
                       Unit = e.Unit,
                       PricePerUnit = e.PricePerUnit
                   }
                );
            return query.ToArray();
        }
    }
}
