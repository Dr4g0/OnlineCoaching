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

        public string OfferPictureURL { get; set; }
    }
}
