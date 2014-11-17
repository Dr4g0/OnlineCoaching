namespace OnlineCoaching.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OnlineCoaching.Data;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineCoaching.Data.OnlineCoachingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineCoachingDbContext context)
        {
            this.SeedRoles(context);
        }

        private void SeedRoles(OnlineCoachingDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("admin"));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("coach"));
            context.SaveChanges();
        }
    }
}
