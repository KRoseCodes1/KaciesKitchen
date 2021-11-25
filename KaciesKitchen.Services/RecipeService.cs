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
        public bool CreateRecipe(RecipeCreate model)
        {
            decimal totalCost = 0;
            foreach (var item in model.IngredientsList)
            {
                var ctx = new ApplicationDbContext();
                var ingredient = ctx.Ingredients.FirstOrDefault(c => c.IngredientName == item.IngredientName);
                decimal cost = ingredient.PricePerUnit * item.AmountNeeded; // Calculate Cost based on Price per Unit and Amount of each Unit needed for recipe.
                totalCost = totalCost + cost;
            }
            var entity =
                new Recipe()
                {
                    Name = model.Name,
                    Directions = model.Directions,
                    IngredientsUsed = model.IngredientsList,
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
        public Recipe GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Recipes
                    .Single(e => e.RecipeId == id);
                return entity;
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
                entity.IngredientsUsed = model.IngredientList;
                entity.LastUpdated = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
