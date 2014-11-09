namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Models;
    using System.Collections.Generic;
    using OnlineCoaching.Data;

    public class CoachFactory : BaseFactory
    {
        public CoachFactory(IOnlineCoachingData db)
            : base(db)
        {
        }
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