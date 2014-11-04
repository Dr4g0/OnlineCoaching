﻿namespace OnlineCoaching.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineCoaching.Data.Migrations;
    using OnlineCoaching.Models;

    public class OnlineCoachingDbContext : IdentityDbContext<AppUser>
    {
        public OnlineCoachingDbContext()
            : base("OnlineCoachingConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineCoachingDbContext, Configuration>());
        }

        public static OnlineCoachingDbContext Create()
        {
            return new OnlineCoachingDbContext();
        }

        public IDbSet<Offer> Offers { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Certificate> Certificates { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }
    }
}
