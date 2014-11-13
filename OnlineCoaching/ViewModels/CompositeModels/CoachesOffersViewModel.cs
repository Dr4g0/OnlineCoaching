using System;
using System.Collections.Generic;
using System.Linq;
using OnlineCoaching.ViewModels.Coach;
using OnlineCoaching.ViewModels.Offer;

namespace OnlineCoaching.ViewModels.CompositeModels
{
    public class CoachesOffersViewModel
    {
        public ICollection<CoachProfileViewModel> Coaches { get; set; }

        public ICollection<OfferViewModel> TopOffers { get; set; }

        public ICollection<OfferViewModel> LatestOffers { get; set; }

    }
}