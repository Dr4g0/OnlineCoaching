using OnlineCoaching.Infrastructure.Mapping;
using OnlineCoaching.Models;
using OnlineCoaching.ViewModels.Coach;
using OnlineCoaching.ViewModels.CoachingCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCoaching.ViewModels.Offer
{
    public class OfferViewModel : IMapFrom<OnlineCoaching.Models.Offer>
    {
        public OfferViewModel()
        {
            this.Rating = 0;
        }

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string CoachID { get; set; }

        [Required]
        public virtual CoachProfileViewModel Coach { get; set; }

        public int CoachingCategoryID { get; set; }

        [Required]
        public virtual CategoryViewModel CoachingCategory { get; set; }

        public bool IsNewCategory { get; set; }

        public ICollection<AppUser> Joiners { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<OnlineCoaching.Models.Comment> Comments { get; set; }

        public string OfferPictureURL { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Level Image")]
        public HttpPostedFileBase ImageUpload { get; set; }

        public DateTime DateCreated { get; set; }

        public IQueryable<CategorySimpleViewModel> Categories { get; set; }

        public double Rating { get; set; }
    }
}