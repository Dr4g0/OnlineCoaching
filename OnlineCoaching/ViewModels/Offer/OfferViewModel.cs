using OnlineCoaching.Infrastructure.Mapping;
using OnlineCoaching.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCoaching.ViewModels.Offer
{
    public class OfferViewModel : IMapFrom<OnlineCoaching.Models.Offer>
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int CoachID { get; set; }

        [Required]
        public virtual AppUser Coach { get; set; }

        public int CoachingCategoryID { get; set; }

        [Required]
        public virtual CoachCategory CoachingCategory { get; set; }

        public bool IsNewCategory { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<OnlineCoaching.Models.Comment> Comments { get; set; }

        public string OfferPictureURL { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Level Image")]
        public HttpPostedFileBase ImageUpload { get; set; }

        public DateTime DateCreated { get; set; }
    }
}