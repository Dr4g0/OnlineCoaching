namespace OnlineCoaching.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CoachProfileViewModel
    {
        public static Expression<Func<AppUser, CoachProfileViewModel>> FromCoach
        {
            get
            {
                return c => new CoachProfileViewModel
                {
                    ID = c.Id,
                    Age = c.Age,
                    AboutMe = c.AboutMe,
                    PictureURL = c.PictureURL,
                    Certificates = c.Certificates,
                    Offers=c.Offers,
                    CoachingLevel = c.CoachingLevel
                };
            }
        }

        public string ID { get; set; }

        public int? Age { get; set; }

        public string AboutMe { get; set; }

        public string PictureURL { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual CoachingLevel CoachingLevel { get; set; }
    }
}