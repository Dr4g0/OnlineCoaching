using OnlineCoaching.Data;
using OnlineCoaching.Factories;
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
            var topFiveCoaches = coachesFactory.GetTopCoaches(5);
            return View(topFiveCoaches);
        }
    }
}