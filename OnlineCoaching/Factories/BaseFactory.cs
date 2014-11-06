﻿namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Data;

    public class BaseFactory
    {
        protected IOnlineCoachingData db;

        public BaseFactory()
        {
            this.db = new OnlineCoachingData(new OnlineCoachingDbContext());
        }
    }
}