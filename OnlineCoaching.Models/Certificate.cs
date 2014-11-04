namespace OnlineCoaching.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Certificate
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CertificateURL { get; set; }
    }
}
