﻿namespace OnlineCoaching.Factories
{
    using OnlineCoaching.Data;
    using OnlineCoaching.Models;
    using OnlineCoaching.ViewModels.Offer;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class OfferFactory
    {
         private IOnlineCoachingData db;

        public OfferFactory(IOnlineCoachingData db)
        {
            this.db = db;
        }

        public IQueryable<OfferViewModel> GetTopFiveOffers()
        {
            return this.db.Offers
                .All()
                .OrderByDescending(o => o.Rating)
                .Take(5).Project().To<OfferViewModel>();
        }

        public IQueryable<OfferViewModel> GetLatestFiveOffers()
        {
            return this.db.Offers
                .All()
                .OrderByDescending(u => u.DateCreated)
                .Take(5).Project().To<OfferViewModel>();
        }
        public IQueryable<OfferViewModel> GetAll()
        {
            return this.db.Offers
                .All().OrderByDescending(o => o.DateCreated)
                .Project().To<OfferViewModel>();
        }

        public Offer GetByID(int id)
        {
            return this.db.Offers.Find(id);
        }

        public void Update(Offer offer)
        {
            offer.Rating = offer.GetOfferRating();
            this.db.Offers.Update(offer);
            this.db.SaveChanges();
        }

        public void Add(Offer offer)
        {
            this.db.Offers.Add(offer);
            this.db.SaveChanges();
        }

        public void Delete(Offer offer)
        {
            this.db.Offers.Delete(offer);
            this.db.SaveChanges();
        }
    }
}