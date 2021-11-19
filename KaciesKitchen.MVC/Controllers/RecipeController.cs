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
            return View();
        }
        // GET
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model, IngredientDictionary list)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateRecipeService();

            if (service.CreateRecipe(model, list))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var service = CreateRecipeService();
            var model = service.GetRecipeById(id);

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