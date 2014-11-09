namespace OnlineCoaching.Data
{
    using System;
    using System.Linq;
    using OnlineCoaching.Data.Repositories;
    using OnlineCoaching.Models;

    public interface IOnlineCoachingData
    {
        IRepository<AppUser> Users { get; }

        IRepository<CoachCategory> Categories { get; }

        IRepository<Certificate> Certificates { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Feedback> Feedbacks { get; }

        IRepository<CoachingLevel> Levels { get; }

        IRepository<Offer> Offers { get; }

        IRepository<Rating> Ratings { get; }

        int SaveChanges();
    }
}
