namespace OnlineCoaching.ViewModels.Rating
{
    using OnlineCoaching.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OnlineCoaching.Models;
    using System.ComponentModel.DataAnnotations;

    public class RatingViewModel : IMapFrom<Rating>
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}