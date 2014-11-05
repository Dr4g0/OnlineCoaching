namespace OnlineCoaching.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public int OfferID { get; set; }

        [Required]
        public virtual Offer Offer { get; set; }
    }
}
