using OnlineCoaching.Factories;
using OnlineCoaching.Models;
using OnlineCoaching.ViewModels.CompositeModels;
using OnlineCoaching.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineCoaching.ViewModels.Coach;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;
using OnlineCoaching.ViewModels.CoachingCategory;
using AutoMapper.QueryableExtensions;

namespace OnlineCoaching.Controllers
{
    public class OffersController : BaseController
    {
        private string currentPort = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        private const string UploadLevelImagesDir = "~/Uploads/OfferImages";
        private OfferFactory offerFactory;
        private CategoryFactory categoryFactory;
        private CoachFactory coachFactory;
        public OffersController()
        {
            this.offerFactory = new BaseFactory().OfferFactory;
            this.categoryFactory = new BaseFactory().CategoryFactory;
            this.coachFactory = new BaseFactory().CoachFactory;
        }

        // GET: Levels
        public ActionResult Index()
        {
            var allOffers = this.offerFactory.GetAll();
            return View(allOffers);
        }

        //GET: Create level
        public ActionResult Create([DataSourceRequest] DataSourceRequest request)
        {
            var newModel = new OfferViewModel();
            var allCategories = this.categoryFactory.GetAll().Project().To<CategorySimpleViewModel>();
            //newModel.Coach = AutoMapper.Mapper.Map<CoachProfileViewModel>(this.coachFactory.GetById(this.User.Identity.GetUserId()));
            //this.SessionState.currentUserId = this.User.Identity.GetUserId();
            newModel.Categories = allCategories;
            return View(newModel);
        }

        //POST: CreateLevel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferViewModel model)
        {
            if (ModelState["Coach"].Errors.Count == 1)
            {
                ModelState["Coach"].Errors.Clear();
            }

            if (ModelState["CoachingCategory"].Errors.Count == 1)
            {
                ModelState["CoachingCategory"].Errors.Clear();
            }

            if (ModelState.IsValid)
            {
                var coach = this.coachFactory.GetById(this.User.Identity.GetUserId());
                var category = this.categoryFactory.GetByID(model.CoachingCategoryID);
                var newOffer = new Offer()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Coach = coach,
                    CoachingCategoryID = model.CoachingCategoryID,
                    CoachingCategory = category
                };

                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    if (!Directory.Exists(Server.MapPath(UploadLevelImagesDir)))
                    {
                        Directory.CreateDirectory(Server.MapPath(UploadLevelImagesDir));
                    }
                    var imagePath = Path.Combine(Server.MapPath(UploadLevelImagesDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(this.currentPort, UploadLevelImagesDir.Substring(2), model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    newOffer.OfferPictureURL = imageUrl;
                }

                this.offerFactory.Add(newOffer);
                TempData["Success"] = "A new offer '" + newOffer.Title + "' was created";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //GET: Edit level
        public ActionResult Edit(int id)
        {
            var existingOffer = this.offerFactory.GetByID(id);
            var offerModel = AutoMapper.Mapper.Map<OfferViewModel>(existingOffer);
            return View(offerModel);
        }

        //POST: Edit level
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfferViewModel offer)
        {
            if (ModelState.IsValid)
            {
                var existingOffer = this.offerFactory.GetByID(offer.ID);

                existingOffer.Title = offer.Title;
                existingOffer.Description = offer.Description;

                if (offer.ImageUpload != null && offer.ImageUpload.ContentLength > 0)
                {
                    if (!Directory.Exists(Server.MapPath(UploadLevelImagesDir)))
                    {
                        Directory.CreateDirectory(Server.MapPath(UploadLevelImagesDir));
                    }
                    var imagePath = Path.Combine(Server.MapPath(UploadLevelImagesDir), offer.ImageUpload.FileName);
                    var imageUrl = Path.Combine(UploadLevelImagesDir.Substring(2), offer.ImageUpload.FileName);
                    offer.ImageUpload.SaveAs(imagePath);
                    existingOffer.OfferPictureURL = imageUrl;
                }

                this.offerFactory.Update(existingOffer);
                TempData["Success"] = "The offer '" + offer.Title + "' was edited";
                return RedirectToAction("Index");
            }

            return View(offer);
        }

        //GET: Delete level
        public ActionResult Delete(int id)
        {
            var existingLevel = this.offerFactory.GetByID(id);
            var levelModel = AutoMapper.Mapper.Map<OfferViewModel>(existingLevel);
            return View(levelModel);
        }

        //POST: Delete level
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OfferViewModel offer)
        {
            var existingOffer = this.offerFactory.GetByID(offer.ID);
            var offerModel = AutoMapper.Mapper.Map<OfferViewModel>(existingOffer);
            this.offerFactory.Delete(existingOffer);
            TempData["Success"] = "The offer '" + offerModel.Title + "' was deleted";
            return RedirectToAction("Index");
        }
    }
}