namespace OnlineCoaching.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Level
    {
        public Level()
        {
            this.Coaches = new HashSet<AppUser>();
        }

        public int ID { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public virtual ICollection<AppUser> Coaches { get; set; }
    }
}
