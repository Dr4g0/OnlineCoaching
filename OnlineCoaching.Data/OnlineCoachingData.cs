namespace OnlineCoaching.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OnlineCoaching.Models;
    using OnlineCoaching.Data.Repositories;
    using System.Data.Entity;

    public class OnlineCoachingData : IOnlineCoachingData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public OnlineCoachingData(DbContext context)
        {
            this.context = context;
        }

        public OnlineCoachingData()
            : this(new OnlineCoachingDbContext())
        {
        }

        public IRepository<AppUser> Users
        {
            get
            {
                return this.GetRepository<AppUser>();
            }
        }

        public IRepository<CoachCategory> Categories
        {
            get
            {
                return this.GetRepository<CoachCategory>();
            }
        }

        public IRepository<Certificate> Certificates
        {
            get
            {
                return this.GetRepository<Certificate>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                return this.GetRepository<Feedback>();

            }
        }

        public IRepository<Level> Levels
        {
            get
            {
                return this.GetRepository<Level>();

            }
        }

        public IRepository<Offer> Offers
        {
            get
            {
                return this.GetRepository<Offer>();

            }
        }

        public IRepository<Rating> Ratings
        {
            get
            {
                return this.GetRepository<Rating>();

            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
