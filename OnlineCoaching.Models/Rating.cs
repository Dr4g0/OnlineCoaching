namespace OnlineCoaching.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Rating
    {
        public Rating()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }

        public int ID { get; set; }

        public int Value { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
