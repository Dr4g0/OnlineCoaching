using OnlineCoaching.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCoaching.ViewModels.CoachingCategory
{
    public class CategorySimpleViewModel : IMapFrom<CategoryViewModel>
    {
        public int ID { get; set; }

        [Required]
        [Remote("IsNameAvailble", "Categories", ErrorMessage = "Name Already Exist")]
        public string Name { get; set; }
    }
}