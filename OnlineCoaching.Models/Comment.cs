namespace OnlineCoaching.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Comment
    {
        public Comment()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public int OfferID { get; set; }

        [Required]
        public virtual Offer Offer { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
