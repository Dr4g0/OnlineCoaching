using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class CoachesController : Controller
    {
        // GET: Coaches
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Coaches/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}