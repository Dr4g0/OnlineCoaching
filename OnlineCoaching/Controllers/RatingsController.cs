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
    }
}