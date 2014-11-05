namespace OnlineCoaching.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public int RatingID { get; set; }

        [Required]
        public virtual Rating Rating { get; set; }

        public int UserID { get; set; }

        [Required]
        public virtual AppUser User { get; set; }
    }
}