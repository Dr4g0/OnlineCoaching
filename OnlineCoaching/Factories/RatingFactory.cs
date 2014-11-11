using OnlineCoaching.ViewModels.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using OnlineCoaching.Models;

namespace OnlineCoaching.Factories
{
    public class RatingFactory : BaseFactory
    {
        public IQueryable<RatingViewModel> GetAll()
        {
            return this.db.Ratings
                .All().OrderBy(r => r.Value)
                .Project().To<RatingViewModel>();
        }

        public Rating GetByID(int id)
        {
            return this.db.Ratings.Find(id);
        }

        public void Update(Rating rating)
        {
            this.db.Ratings.Update(rating);
            this.db.SaveChanges();
        }

        public void Add(Rating rating)
        {
            this.db.Ratings.Add(rating);
            this.db.SaveChanges();
        }

        public void Delete(Rating rating)
        {
            this.db.Ratings.Delete(rating);
            this.db.SaveChanges();
        }
    }
}