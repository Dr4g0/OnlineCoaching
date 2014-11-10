using OnlineCoaching.ViewModels.CoachingLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using AutoMapper.Mappers;
using OnlineCoaching.Models;

namespace OnlineCoaching.Factories
{
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


    }
}