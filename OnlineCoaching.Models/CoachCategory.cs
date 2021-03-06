namespace OnlineCoaching.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CoachCategory
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

    }
}