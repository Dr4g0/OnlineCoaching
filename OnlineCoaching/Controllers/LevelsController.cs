namespace OnlineCoaching.Controllers
{
    using OnlineCoaching.Factories;
    using OnlineCoaching.Models;
    using OnlineCoaching.ViewModels.CoachingLevel;
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    public class LevelsController : Controller
    {
        private string currentPort = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        private const string UploadLevelImagesDir = "~/Uploads/LevelImages";
        private LevelFactory factory;
        public LevelsController()
        {
            this.factory = new LevelFactory();
        }

        // GET: Levels
        public ActionResult Index()
        {
            var allLevels = this.factory.GetAll();
            return View(allLevels);
        }

        //GET: Create level
        public ActionResult Create()
        {
            return View();
        }

        //POST: CreateLevel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoachingLevelViewModel level)
        {
            if (ModelState.IsValid)
            {
                var newLevel = new CoachingLevel()
                {
                    Name = level.Name,
                    Rank = level.Rank
                };

                if (level.ImageUpload != null && level.ImageUpload.ContentLength > 0)
                {
                    if (!Directory.Exists(Server.MapPath(UploadLevelImagesDir)))
                    {
                        Directory.CreateDirectory(Server.MapPath(UploadLevelImagesDir));
                    }
                    var imagePath = Path.Combine(Server.MapPath(UploadLevelImagesDir), level.ImageUpload.FileName);
                    var imageUrl = Path.Combine(this.currentPort, UploadLevelImagesDir.Substring(2), level.ImageUpload.FileName);
                    level.ImageUpload.SaveAs(imagePath);
                    newLevel.ImageURL = imageUrl;
                }

                this.factory.Add(newLevel);
                TempData["Success"] = "A new coaching level '" + newLevel.Name + "' was created";
                return RedirectToAction("Index");
            }

            return View(level);
        }

        //GET: Edit level
        public ActionResult Edit(int id)
        {
            var existingLevel = this.factory.GetByID(id);
            var levelModel = AutoMapper.Mapper.Map<CoachingLevelViewModel>(existingLevel);
            return View(levelModel);
        }

        //POST: Edit level
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CoachingLevelViewModel level)
        {
            if (ModelState.IsValid)
            {
                var existingLevel = this.factory.GetByID(level.ID);

                existingLevel.Name = level.Name;
                existingLevel.Rank = level.Rank;

                if (level.ImageUpload != null && level.ImageUpload.ContentLength > 0)
                {
                    if (!Directory.Exists(Server.MapPath(UploadLevelImagesDir)))
                    {
                        Directory.CreateDirectory(Server.MapPath(UploadLevelImagesDir));
                    }
                    var imagePath = Path.Combine(Server.MapPath(UploadLevelImagesDir), level.ImageUpload.FileName);
                    var imageUrl = Path.Combine(UploadLevelImagesDir.Substring(2), level.ImageUpload.FileName);
                    level.ImageUpload.SaveAs(imagePath);
                    existingLevel.ImageURL = imageUrl;
                }

                this.factory.Update(existingLevel);
                TempData["Success"] = "A level '" + level.Name + "' was edited";
                return RedirectToAction("Index");
            }

            return View(level);
        }

        //GET: Delete level
        public ActionResult Delete(int id)
        {
            var existingLevel = this.factory.GetByID(id);
            var levelModel = AutoMapper.Mapper.Map<CoachingLevelViewModel>(existingLevel);
            return View(levelModel);
        }

        //POST: Delete level
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CoachingLevelViewModel level)
        {
            var existingLevel = this.factory.GetByID(level.ID);
            var levelModel = AutoMapper.Mapper.Map<CoachingLevelViewModel>(existingLevel);
            this.factory.Delete(existingLevel);
            TempData["Success"] = "A level '" + levelModel.Name + "' was deleted";
            return RedirectToAction("Index");
        }

        public ActionResult IsNameAvailble(string name)
        {
            try
            {
                var level = this.factory.GetAll().Single(c => c.Name == name);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult IsRankAvailble(int rank)
        {
            try
            {
                var level = this.factory.GetAll().Single(c => c.Rank == rank);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}