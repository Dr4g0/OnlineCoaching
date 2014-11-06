using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCoaching.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Certificates = new HashSet<Certificate>();
            this.Offers = new HashSet<Offer>();
            this.IsCoach = false;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public bool IsCoach { get; set; }

        public int Age { get; set; }

        public string AboutMe { get; set; }

        public string PictureURL { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public int LevelID { get; set; }

        public virtual Level Level { get; set; }

        public double GetCoachRating()
        {
            if (!this.IsCoach)
            {
                return 0;
            }
            var feedbacks = this.Offers.SelectMany(o => o.Feedbacks);
            var sumRatings = feedbacks.Sum(f => Convert.ToDouble(f.Rating));
            var countFeedbacks = feedbacks.Count();

            return sumRatings / countFeedbacks;
        }
    }
}
