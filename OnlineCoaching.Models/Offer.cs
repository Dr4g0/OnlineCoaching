namespace OnlineCoaching.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Offer
    {
        public Offer()
        {
            this.Feedbacks = new HashSet<Feedback>();
            this.Comments = new HashSet<Comment>();
            this.DateCreated = DateTime.Now;
            this.IsNewCategory = false;
        }

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string  Description { get; set; }

        public int CoachID { get; set; }

        [Required]
        public virtual AppUser Coach { get; set; }

        public int CoachingCategoryID { get; set; }

        [Required]
        public virtual Category CoachingCategory { get; set; }

        public bool IsNewCategory { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string OfferPictureURL { get; set; }

        public DateTime DateCreated { get; set; }

        public double GetOfferRating()
        {
            if (this.Feedbacks.Count()==0)
            {
                return 0;
            }

            var sumRatings = this.Feedbacks.Sum(f => Convert.ToDouble(f.Rating));
            var countFeedbacks = this.Feedbacks.Count();

            return sumRatings / countFeedbacks;
        }
    }
}
