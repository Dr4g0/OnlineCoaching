namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Models;

    public class CoachFactory : BaseFactory
    {
        public IQueryable<AppUser> GetTopFiveCoaches()
        {
            return this.db.Users
                .All()
                .OrderByDescending(u => u.GetCoachRating())
                .Take(5);
        }
    }
}