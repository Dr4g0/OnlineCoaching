namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Models;
    using System.Collections.Generic;

    public class CoachFactory : BaseFactory
    {
        public IQueryable<CoachProfileViewModel> GetTopCoaches(int first)
        {
            return this.db.Users
                .All()
                .OrderByDescending(u => u.GetCoachRating())
                .Take(first)
                .Select(CoachProfileViewModel.FromCoach);
        }

        public IQueryable<CoachProfileViewModel> GetAllCoaches()
        {
            return this.db.Users
                .All()
                .OrderByDescending(u => u.GetCoachRating())
                .Select(CoachProfileViewModel.FromCoach);
        }
    }
}