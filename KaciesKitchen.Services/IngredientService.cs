using KaciesKitchen.Data;
using KaciesKitchen.Models.Ingredient;
using KaciesKitchen.Models.IngredientModels;
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
        public IEnumerable<IngredientListItem> GetIngredients()
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
        public IngredientListItem GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Ingredients
                    .Single(e => e.IngredientId == id);
                return new IngredientListItem
                {
                    IngredientId = entity.IngredientId,
                    Name = entity.IngredientName,
                    Unit = entity.Unit,
                    PricePerUnit = entity.PricePerUnit
                };
            }
        }
        public bool UpdateIngredient(IngredientUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Ingredients.Single(e => e.IngredientId == model.IngredientId);
                entity.IngredientName = model.Name;
                entity.Unit = model.Unit;
                entity.PricePerUnit = model.PricePerUnit;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
