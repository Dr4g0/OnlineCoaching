using System;
using System.Linq;
using OnlineCoaching.ViewModels.CoachingCategory;
using OnlineCoaching.ViewModels.Offer;
using OnlineCoaching.ViewModels.Coach;
using System.Collections.Generic;
using OnlineCoaching.Factories;

namespace OnlineCoaching.ViewModels.CompositeModels
{
    public class AppUserOfferViewModel
    {
        private CategoryFactory factory;

        public AppUserOfferViewModel()
        {
            this.factory = new BaseFactory().CategoryFactory;
            this.Categories = this.factory.GetAll();
        }

        public int CategoryID { get; set; }

        public CoachProfileViewModel Coach { get; set; }

        public OfferViewModel Offer { get; set; }

        public IQueryable<CategoryViewModel> Categories { get; set; }
    }
}