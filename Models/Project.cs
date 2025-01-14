using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Technologies { get; set; }

        public string ProjectUrl { get; set; }

        public string RepositoryUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
