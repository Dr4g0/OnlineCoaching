namespace OnlineCoaching.ViewModels.Rating
{
    using OnlineCoaching.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OnlineCoaching.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class RatingViewModel : IMapFrom<Rating>
    {
        public int ID { get; set; }

        [Required]
        [Remote("IsNameAvailble", "Ratings", ErrorMessage = "Name Already Exist")]
        public string Name { get; set; }

        [Required]
        [Remote("IsValueAvailble", "Ratings", ErrorMessage = "Value Already Exist")]
        public int Value { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}