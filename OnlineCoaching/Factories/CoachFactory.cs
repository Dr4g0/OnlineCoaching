﻿namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Data;
    using AutoMapper.QueryableExtensions;
    using OnlineCoaching.ViewModels.Coach;
    using OnlineCoaching.Models;

    public class CoachFactory : BaseFactory
    {
        public IQueryable<CoachProfileViewModel> GetAll()
        {
            return this.db.Users
                .All().Where(u => u.IsCoach)
                .Project().To<CoachProfileViewModel>();
        }

        public IQueryable<CoachProfileViewModel> GetTopCoaches(int first)
        {

            return this.GetAll()
                .OrderByDescending(c => c.CoachRating)
                .Take(first);
        }
    }
}