using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100), EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(150)]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
