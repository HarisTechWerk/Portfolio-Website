using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; } // Optional
        public DbSet<Tag> Tags { get; set; } // Optional
        public DbSet<ContactMessage> ContactMessages { get; set; } // Optional

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<BlogPost>()
                .HasIndex(b => b.Slug)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Slug)
                .IsUnique();

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Slug)
                .IsUnique();

            // Configure many-to-many relationship for BlogPost and Tag
            modelBuilder.Entity<BlogPostTag>()
                .HasKey(bt => new { bt.BlogPostId, bt.TagId });

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bt => bt.BlogPost)
                .WithMany(b => b.BlogPostTags)
                .HasForeignKey(bt => bt.BlogPostId);

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BlogPostTags)
                .HasForeignKey(bt => bt.TagId);
        }
    }
}
