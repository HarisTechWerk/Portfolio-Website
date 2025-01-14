using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [Required, StringLength(200)]
        public string Slug { get; set; }

        [Required]
        public string Content { get; set; }

        public string Summary { get; set; }

        public bool Published { get; set; } = false;

        public DateTime? PublishedAt { get; set; } = null;

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        // Many-to-Many relationship with Tag
        public ICollection<BlogPostTag> BlogPostTags { get; set; }
    }
}
