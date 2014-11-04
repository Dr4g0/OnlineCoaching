namespace OnlineCoaching.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int RatingValue { get; set; }

        public int UserID { get; set; }

        [Required]
        public virtual AppUser User { get; set; }
    }
}