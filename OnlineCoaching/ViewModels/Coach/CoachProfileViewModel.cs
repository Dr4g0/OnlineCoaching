namespace OnlineCoaching.ViewModels.Coach
{
    using OnlineCoaching.Infrastructure.Mapping;
    using OnlineCoaching.Models;
    using OnlineCoaching.ViewModels.CoachingLevel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;


    public class CoachProfileViewModel : IMapFrom<AppUser>
    {
        public string ID { get; set; }

        [Required]
        public string Username { get; set; }

        public int? Age { get; set; }

        public string AboutMe { get; set; }

        public string PictureURL { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual CoachingLevel CoachingLevel { get; set; }

        public double CoachRating { get; set; }

        //public double CalculateCoachRating(AppUser coach)
        //{
        //    var feedbacks = coach.Offers.SelectMany(o => o.Feedbacks);
        //    var sumRatings = feedbacks.Sum(f => Convert.ToDouble(f.Rating));
        //    var countFeedbacks = feedbacks.Count();

        //    if (countFeedbacks == 0)
        //    {
        //        return 0;
        //    }

        //    return sumRatings / countFeedbacks;
        //}
    }
}