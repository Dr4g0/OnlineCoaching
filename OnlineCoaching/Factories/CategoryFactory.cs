namespace OnlineCoaching.Factories
{
    using OnlineCoaching.Data;
    using OnlineCoaching.ViewModels.CoachingCategory;
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using OnlineCoaching.Models;

    public class CategoryFactory 
    {

        private IOnlineCoachingData db;

        public CategoryFactory(IOnlineCoachingData db)
        {
            this.db = db;
        }

        public IQueryable<CategoryViewModel> GetAll()
        {
            return this.db.Categories
                .All().OrderBy(c => c.ID)
                .Project().To<CategoryViewModel>();
        }

        public CoachCategory GetByID(int id)
        {
            return this.db.Categories.Find(id);
        }

        public void Update(CoachCategory category)
        {
            this.db.Categories.Update(category);
            this.db.SaveChanges();
        }

        public void Add(CoachCategory category)
        {
            this.db.Categories.Add(category);
            this.db.SaveChanges();
        }

        public void Delete(CoachCategory category)
        {
            this.db.Categories.Delete(category);
            this.db.SaveChanges();
        }
    }
}