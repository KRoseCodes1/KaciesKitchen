using KaciesKitchen.Data;
using KaciesKitchen.Models.Ingredient;
using KaciesKitchen.Models.RecipeModels;
using KaciesKitchen.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaciesKitchen.MVC.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var service = CreateRecipeService();
            var model = service.GetRecipes();
            return View(model);
        }
        // GET
        public ActionResult Create()
        {
            var initialData = new IngredientListDict[]
            {
                new IngredientListDict {IngredientName = "Example Ingredient", AmountNeeded = 1.0M}
            };
            var model = new RecipeCreate { IngredientsList = initialData.ToList() };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your Recipe was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Recipe could not be created.");
            return View(model);
        }
        [HttpPost]
        public ActionResult AddIngredients(List<IngredientListDict> ingredients)
        {
            return View(ingredients);
        }

        public ActionResult IngredientRow()
        {
            return PartialView("CreatePartial");
        }
        public ActionResult Details(int id)
        {
            var service = CreateRecipeService();
            var model = service.GetRecipeById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model = new RecipeUpdate { RecipeId = detail.RecipeId, Directions = detail.Directions, Name = detail.Name, IngredientList = detail.IngredientsUsed };
            return View(model);
        }

        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }
    }
}