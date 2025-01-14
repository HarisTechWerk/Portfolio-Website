using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<BlogPostTag> BlogPostTags { get; set; }
    }

    public class BlogPostTag
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
