using OnlineCoaching.Infrastructure.Mapping;
using OnlineCoaching.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCoaching.ViewModels.CoachingCategory
{
    public class CategoryViewModel : IMapFrom<CoachCategory>
    {
        public int ID { get; set; }

        [Required]
        [Remote("IsNameAvailble", "Categories", ErrorMessage = "Name Already Exist")]
        public string Name { get; set; }

        public virtual ICollection<OnlineCoaching.Models.Offer> Offers { get; set; }

    }
}