﻿using OnlineCoaching.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OnlineCoaching.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : IValidatableObject
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        //[Display(Name = "Username")]
        //public string Username { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        [Display(Name = "Are You a Coach?")]
        public bool IsCoach { get; set; }

        [Display(Name = "Your Skills")]
        [DataType(DataType.MultilineText)]
        public string AboutMe { get; set; }

        [Display(Name = "Your Age")]
        public int? Age { get; set; }

        public string PictureURL { get; set; }

        public int? CoachingLevelID { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Picture")]
        public HttpPostedFileBase PictureUpload { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validImageTypes = new List<string>()
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (this.IsCoach && this.AboutMe == null)
            {
                yield return new ValidationResult("Skills are required for coaches.", new[] { "AboutMe" });
            }

            if (this.IsCoach && this.Age == null)
            {
                yield return new ValidationResult("Age is required for coaches.", new[] { "Age" });
            }

            if (this.IsCoach)
            {
                if (this.PictureUpload == null || this.PictureUpload.ContentLength == 0)
                {
                    yield return new ValidationResult("The picture is required for coaches.", new[] { "PictureUpload" });
                }
                else if (!validImageTypes.Contains(this.PictureUpload.ContentType))
                {
                    yield return new ValidationResult("Please choose either a GIF, JPG or PNG file for picture.", new[] { "PictureUpload" });
                }
            }
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
