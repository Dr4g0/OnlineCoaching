namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Data;
    using AutoMapper.QueryableExtensions;
    using OnlineCoaching.ViewModels.Coaches;
using OnlineCoaching.Models;

    public class CoachFactory : BaseFactory
    {
        public IQueryable<CoachProfileViewModel> GetAll()
        {
            return this.db.Users
                .All().Where(u=>u.IsCoach)
                .Project().To<CoachProfileViewModel>();
        }

        public IQueryable<CoachProfileViewModel> GetTopCoaches(int first)
        {

            return this.GetAll()
                .OrderByDescending(c => c.CoachRating)
                .Take(first);


            //var allCoaches = this.GetAll();
            //foreach (var coach in allCoaches)
            //{
            //    coach.CoachRating = this.CalculateCoachRating(coach);
            //}

            //return allCoaches
            //    .OrderByDescending(c => c.CoachRating)
            //    .Take(first);
        }

        public double CalculateCoachRating(CoachProfileViewModel coach)
        {
            var feedbacks = coach.Offers.SelectMany(o => o.Feedbacks);
            var sumRatings = feedbacks.Sum(f => Convert.ToDouble(f.Rating));
            var countFeedbacks = feedbacks.Count();

            return sumRatings / countFeedbacks;
        }
    }
}