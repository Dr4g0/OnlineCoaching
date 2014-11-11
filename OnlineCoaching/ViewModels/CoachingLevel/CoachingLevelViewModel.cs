namespace OnlineCoaching.ViewModels.CoachingLevel
{
    using System.Collections.Generic;
    using OnlineCoaching.Infrastructure.Mapping;
    using OnlineCoaching.Models;
    using System;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CoachingLevelViewModel : IMapFrom<CoachingLevel>, IValidatableObject
    {
        public int ID { get; set; }

        [Required]
        [Remote("IsNameAvailble", "Levels", ErrorMessage = "Name Already Exist")]
        public string Name { get; set; }

        [Required]
        [Remote("IsRankAvailble", "Levels", ErrorMessage = "Rank Already Exist")]
        public double Rank { get; set; }

        [Display(Name="Current Image")]
        public string ImageURL { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Level Image")]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual ICollection<AppUser> Coaches { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validImageTypes = new List<string>()
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (this.ImageURL == null)
            {
                if (this.ImageUpload == null || this.ImageUpload.ContentLength == 0)
                {
                    yield return new ValidationResult("The image is required.", new[] { "ImageUpload" });
                }
                else if (!validImageTypes.Contains(this.ImageUpload.ContentType))
                {
                    yield return new ValidationResult("Please choose either a GIF, JPG or PNG file for image.", new[] { "ImageUpload" });
                }
            }
        }
    }
}