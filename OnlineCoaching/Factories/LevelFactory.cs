namespace OnlineCoaching.Factories
{
    using OnlineCoaching.ViewModels.CoachingLevel;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using OnlineCoaching.Models;

    public class LevelFactory : BaseFactory
    {
    
        public IQueryable<CoachingLevelViewModel> GetAll()
        {
            return this.db.Levels
                .All().OrderBy(l => l.Rank)
                .Project().To<CoachingLevelViewModel>();
        }

        public CoachingLevel GetByID(int id)
        {
            return this.db.Levels.Find(id);
        }

        public void Update(CoachingLevel level)
        {
            this.db.Levels.Update(level);
            this.db.SaveChanges();
        }

        public void Add(CoachingLevel level)
        {
            this.db.Levels.Add(level);
            this.db.SaveChanges();
        }

        public void Delete(CoachingLevel level)
        {
            this.db.Levels.Delete(level);
            this.db.SaveChanges();
        }

        public CoachingLevel GetLowestLevel()
        {
            return this.db.Levels
                .All()
                .OrderBy(l => l.Rank)
                .FirstOrDefault();
        }
    }
}