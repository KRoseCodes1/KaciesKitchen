using KaciesKitchen.Models.Ingredient;
using KaciesKitchen.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaciesKitchen.MVC.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            var service = CreateIngredientService();
            var model = service.GetIngredients();
            return View();
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }
    }
}