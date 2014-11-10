namespace OnlineCoaching.Controllers
{
    using Microsoft.AspNet.Identity;
    using OnlineCoaching.Factories;
    using OnlineCoaching.Models;
    using OnlineCoaching.ViewModels.CoachingLevel;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;

    public class LevelsController : BaseController
    {
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
                    var imageUrl = Path.Combine(UploadLevelImagesDir.Substring(2), level.ImageUpload.FileName);
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
    }
}