namespace OnlineCoaching.Factories
{
    using System;
    using System.Linq;
    using OnlineCoaching.Data;

    public class BaseFactory
    {
        protected static IOnlineCoachingData db = new OnlineCoachingData(new OnlineCoachingDbContext());

        public CategoryFactory CategoryFactory { get { return new CategoryFactory(db); } }

        public CertificateFactory CertificateFactory { get { return new CertificateFactory(db); } }

        public CoachFactory CoachFactory { get { return new CoachFactory(db); } }

        public CommentFactory CommentFactory { get { return new CommentFactory(db); } }

        public LevelFactory LevelFactory { get { return new LevelFactory(db); } }

        public OfferFactory OfferFactory { get { return new OfferFactory(db); } }

        public RatingFactory RatingFactory { get { return new RatingFactory(db); } }


    }
}