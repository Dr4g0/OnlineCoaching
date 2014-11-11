using OnlineCoaching.Factories;
using OnlineCoaching.Models;
using OnlineCoaching.ViewModels.Rating;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class RatingsController : Controller
    {
        private RatingFactory factory;

        public RatingsController()
        {
            this.factory = new RatingFactory();
        }

        // GET: Ratings
        public ActionResult Index()
        {
            var allRatings = this.factory.GetAll();
            return View(allRatings);
        }

        //GET: Create rating
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create rating
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingViewModel rating)
        {
            if (ModelState.IsValid)
            {
                var newRating = new Rating()
                {
                    Name = rating.Name,
                    Value = rating.Value
                };

                this.factory.Add(newRating);
                TempData["Success"] = "A new rating '" + newRating.Name + "' was created";
                return RedirectToAction("Index");
            }

            return View(rating);
        }

        //GET: Edit rating
        public ActionResult Edit(int id)
        {
            var existingRating = this.factory.GetByID(id);
            var ratingModel = AutoMapper.Mapper.Map<RatingViewModel>(existingRating);
            return View(ratingModel);
        }

        //POST: Edit rating
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RatingViewModel rating)
        {
            if (ModelState.IsValid)
            {
                var existingRating = this.factory.GetByID(rating.ID);

                existingRating.Name = rating.Name;
                existingRating.Value = rating.Value;

                this.factory.Update(existingRating);
                TempData["Success"] = "A rating '" + rating.Name + "' was edited";
                return RedirectToAction("Index");
            }

            return View(rating);
        }

        //GET: Delete rating
        public ActionResult Delete(int id)
        {
            var existingRating = this.factory.GetByID(id);
            var ratingModel = AutoMapper.Mapper.Map<RatingViewModel>(existingRating);
            return View(ratingModel);
        }

        //POST: Delete rating
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RatingViewModel rating)
        {
            var existingRating = this.factory.GetByID(rating.ID);
            this.factory.Delete(existingRating);
            TempData["Success"] = "A rating '" + existingRating.Name + "' was deleted";
            return RedirectToAction("Index");
        }

        public ActionResult IsNameAvailble(string name)
        {
            try
            {
                var rating = this.factory.GetAll().Single(c => c.Name == name);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult IsValueAvailble(int value)
        {
            try
            {
                var rating = this.factory.GetAll().Single(c => c.Value == value);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}