using OnlineCoaching.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class CoachesController : Controller
    {
        private CoachFactory factory;

        public CoachesController()
        {
            this.factory = new CoachFactory();
        }

        // GET: Coaches
        public ActionResult Index()
        {
            var allCoaches = this.factory.GetAll();
            return View(allCoaches);
        }
    }
}