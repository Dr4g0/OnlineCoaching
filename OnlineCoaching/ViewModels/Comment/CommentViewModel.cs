using OnlineCoaching.Infrastructure.Mapping;
using OnlineCoaching.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineCoaching.ViewModels.Comment
{
    public class CommentViewModel : IMapFrom<OnlineCoaching.Models.Comment>
    {
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public int OfferID { get; set; }

        [Required]
        public virtual OnlineCoaching.Models.Offer Offer { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}