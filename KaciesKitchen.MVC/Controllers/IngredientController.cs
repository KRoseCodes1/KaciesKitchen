using KaciesKitchen.Models.Ingredient;
using KaciesKitchen.Models.IngredientModels;
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
            var service = CreateIngredientService();
            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var service = CreateIngredientService();
            var model = service.GetIngredientById(id);

            return View(model);
        }
        // UPDATE
        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model =
                new IngredientUpdate
                {
                    IngredientId = detail.IngredientId,
                    Name = detail.Name,
                    Unit = detail.Unit,
                    PricePerUnit = detail.PricePerUnit
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if(model.IngredientId != id)
            {
                ModelState.AddModelError("", "Id does not match. ");
                return View(model);
            }
            var service = CreateIngredientService();
            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "The ingredient was updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The ingredient could not be updated.");
            return View();
        }
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }
    }
}