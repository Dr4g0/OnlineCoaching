﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCoaching.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Certificates = new HashSet<Certificate>();
            this.Offers = new HashSet<Offer>();
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
    }
}
