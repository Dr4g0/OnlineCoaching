namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Data;

    public class BaseFactory
    {
        protected IOnlineCoachingData db;

        public BaseFactory(IOnlineCoachingData db)
        {
            this.db = db;
        }

        public BaseFactory()
            : this(new OnlineCoachingData())
        {
        }
    }
}