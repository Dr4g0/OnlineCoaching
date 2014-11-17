using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administration/AdminHome
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}