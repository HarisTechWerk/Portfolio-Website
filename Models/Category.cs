using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsite.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
