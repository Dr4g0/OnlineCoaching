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
using OnlineCoaching.Controllers;

namespace OnlineCoaching.Areas.Administration.Controllers
{
    [Authorize(Roles = "admin")]
    public class OffersController : BaseController
    {
        private string currentPort = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        private const string UploadLevelImagesDir = "~/Uploads/OfferImages";
        private const string DefaultPicture = "Content/images/Offer/default-offer.jpg";
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