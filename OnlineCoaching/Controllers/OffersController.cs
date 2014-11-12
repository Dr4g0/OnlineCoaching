using OnlineCoaching.Factories;
using OnlineCoaching.Models;
using OnlineCoaching.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.Controllers
{
    public class OffersController : Controller
    {
        private string currentPort = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        private const string UploadLevelImagesDir = "~/Uploads/OfferImages";
        private OfferFactory factory;
        public OffersController()
        {
            this.factory = new OfferFactory();
        }

        // GET: Levels
        public ActionResult Index()
        {
            var allOffers = this.factory.GetAll();
            return View(allOffers);
        }

        //GET: Create level
        public ActionResult Create()
        {
            return View();
        }

        //POST: CreateLevel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfferViewModel offer)
        {
            if (ModelState.IsValid)
            {
                var newOffer = new Offer()
                {
                    Title = offer.Title,
                    Description = offer.Description
                };

                if (offer.ImageUpload != null && offer.ImageUpload.ContentLength > 0)
                {
                    if (!Directory.Exists(Server.MapPath(UploadLevelImagesDir)))
                    {
                        Directory.CreateDirectory(Server.MapPath(UploadLevelImagesDir));
                    }
                    var imagePath = Path.Combine(Server.MapPath(UploadLevelImagesDir), offer.ImageUpload.FileName);
                    var imageUrl = Path.Combine(this.currentPort, UploadLevelImagesDir.Substring(2), offer.ImageUpload.FileName);
                    offer.ImageUpload.SaveAs(imagePath);
                    newOffer.OfferPictureURL = imageUrl;
                }

                this.factory.Add(newOffer);
                TempData["Success"] = "A new offer '" + newOffer.Title + "' was created";
                return RedirectToAction("Index");
            }

            return View(offer);
        }

        //GET: Edit level
        public ActionResult Edit(int id)
        {
            var existingOffer = this.factory.GetByID(id);
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
                var existingOffer = this.factory.GetByID(offer.ID);

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

                this.factory.Update(existingOffer);
                TempData["Success"] = "The offer '" + offer.Title + "' was edited";
                return RedirectToAction("Index");
            }

            return View(offer);
        }

        //GET: Delete level
        public ActionResult Delete(int id)
        {
            var existingLevel = this.factory.GetByID(id);
            var levelModel = AutoMapper.Mapper.Map<OfferViewModel>(existingLevel);
            return View(levelModel);
        }

        //POST: Delete level
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OfferViewModel offer)
        {
            var existingOffer = this.factory.GetByID(offer.ID);
            var offerModel = AutoMapper.Mapper.Map<OfferViewModel>(existingOffer);
            this.factory.Delete(existingOffer);
            TempData["Success"] = "The offer '" + offerModel.Title + "' was deleted";
            return RedirectToAction("Index");
        }
    }
}