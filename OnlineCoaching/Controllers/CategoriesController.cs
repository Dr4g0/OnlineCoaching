using OnlineCoaching.Factories;
using OnlineCoaching.Models;
using OnlineCoaching.ViewModels.CoachingCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class CategoriesController : BaseController
    {
        private CategoryFactory factory;

        public CategoriesController()
        {
            this.factory = new BaseFactory().CategoryFactory;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var allCategories = this.factory.GetAll();
            return View(allCategories);
        }

        //GET: Category create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create rating
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new CoachCategory()
                {
                    Name = category.Name,
                };

                this.factory.Add(newCategory);
                TempData["Success"] = "A new category '" + newCategory.Name + "' was created";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //GET: Edit rating
        public ActionResult Edit(int id)
        {
            var existingCategory = this.factory.GetByID(id);
            var categoryModel = AutoMapper.Mapper.Map<CategoryViewModel>(existingCategory);
            return View(categoryModel);
        }

        //POST: Edit rating
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = this.factory.GetByID(category.ID);

                existingCategory.Name = category.Name;

                this.factory.Update(existingCategory);
                TempData["Success"] = "A category '" + category.Name + "' was edited";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //GET: Delete rating
        public ActionResult Delete(int id)
        {
            var existingCategory = this.factory.GetByID(id);
            var categoryModel = AutoMapper.Mapper.Map<CategoryViewModel>(existingCategory);
            return View(categoryModel);
        }

        //POST: Delete rating
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel rating)
        {
            var existingCategory = this.factory.GetByID(rating.ID);
            this.factory.Delete(existingCategory);
            TempData["Success"] = "A category '" + existingCategory.Name + "' was deleted";
            return RedirectToAction("Index");
        }

        public ActionResult IsNameAvailble(string name)
        {
            try
            {
                var category = this.factory.GetAll().Single(c => c.Name == name);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}