namespace OnlineCoaching.Factories
{
    using OnlineCoaching.Models;
    using System;
    using System.Linq;

    public class OfferFactory : BaseFactory
    {
        public OfferFactory():base(db)
        {
        }
        public IQueryable<Offer> GetTopFiveOffers()
        {
            return this.db.Offers
                .All()
                .OrderByDescending(u => u.GetOfferRating())
                .Take(5);
        }

        public IQueryable<Offer> GetLatestFiveOffers()
        {
            return this.db.Offers
                .All()
                .OrderByDescending(u => u.DateCreated)
                .Take(5);
        }
    }
}