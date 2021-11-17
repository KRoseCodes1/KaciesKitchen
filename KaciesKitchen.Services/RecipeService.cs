using KaciesKitchen.Data;
using KaciesKitchen.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;
        public RecipeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRecipe(RecipeCreate model, IngredientDictionary list)
        {
            decimal totalCost = 0;
            model.IngredientDictionary = list.IngredientsList;
            foreach (var kvp in model.IngredientDictionary)
            {
                decimal cost = kvp.Key.PricePerUnit * kvp.Value; // Calculate Cost based on Price per Unit and Amount of each Unit needed for recipe.
                totalCost = totalCost + cost;
            }
            var entity =
                new Recipe()
                {
                    Name = model.Name,
                    Directions = model.Directions,
                    IngredientsUsed = model.IngredientDictionary,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now,  // When first created, these times should be the same.
                    Cost = totalCost  // Calculated above.
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Recipes
                    .Select(
                       e =>
                       new RecipeListItem
                       {
                           RecipeId = e.RecipeId,
                           Name = e.Name,
                           Directions = e.Directions,
                           Cost = e.Cost,
                           IngredientsUsed = e.IngredientsUsed,
                           DateCreated = e.DateCreated,
                           LastUpdated = e.LastUpdated
                       }
                );
                return query.ToArray();
            }
        }
    }
}
