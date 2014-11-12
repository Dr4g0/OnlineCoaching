using OnlineCoaching.Factories;
using OnlineCoaching.ViewModels.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class CoachesController : BaseController
    {
        private CoachFactory factory;

        public CoachesController()
        {
            this.factory = new BaseFactory().CoachFactory;
        }

        // GET: Coaches
        public ActionResult Index()
        {
            var allCoaches = this.factory.GetAll();
            return View(allCoaches);
        }

        public ActionResult View(string id)
        {
            var coach = AutoMapper.Mapper.Map<CoachProfileViewModel>(this.factory.GetById(id));
            return View(coach);
        }
    }
}