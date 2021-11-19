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
                var ctx = new ApplicationDbContext();
                Ingredient ing = ctx.Ingredients.Single(e => e.IngredientId == kvp.Key);
                decimal cost = ing.PricePerUnit * kvp.Value; // Calculate Cost based on Price per Unit and Amount of each Unit needed for recipe.
                totalCost = totalCost + cost;
            }
            var entity =
                new Recipe()
                {
                    Name = model.Name,
                    Directions = model.Directions,
                   // IngredientsUsed = model.IngredientDictionary,
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
                           LastUpdated = e.LastUpdated
                       }
                );
                return query.ToArray();
            }
        }
        public RecipeListItem GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Recipes
                    .Single(e => e.RecipeId == id);
                return new RecipeListItem
                {
                    RecipeId = entity.RecipeId,
                    Name = entity.Name,
                    LastUpdated = entity.LastUpdated
                };
            }
        }
        public bool UpdateRecipe(RecipeUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Recipes.Single(e => e.RecipeId == model.RecipeId);
                entity.Name = model.Name;
                entity.Directions = model.Directions;
                entity.IngredientsUsed = model.IngredientDictionary;
                entity.LastUpdated = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
