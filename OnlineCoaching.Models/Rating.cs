namespace OnlineCoaching.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Rating
    {
        public Rating()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
