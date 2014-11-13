using OnlineCoaching.Data;
using OnlineCoaching.Factories;
using OnlineCoaching.ViewModels.CompositeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var coachesFactory = new BaseFactory().CoachFactory;
            var offerFactory = new BaseFactory().OfferFactory;
            var topFiveCoaches = coachesFactory.GetTopCoaches(5).ToList();
            var topFiveOffers = offerFactory.GetTopFiveOffers();
            var latestOffers = offerFactory.GetLatestFiveOffers();
            var model = new CoachesOffersViewModel()
            {
                Coaches = topFiveCoaches,
                TopOffers = topFiveOffers.ToList(),
                LatestOffers = latestOffers.ToList()
            };

            return View(model);
        }
    }
}