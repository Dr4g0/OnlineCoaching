using OnlineCoaching.Data;
using OnlineCoaching.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var coachesFactory = new CoachFactory();
            var topFiveCoaches = coachesFactory.GetAll();
            return View(topFiveCoaches);
        }
    }
}