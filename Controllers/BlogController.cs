using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Data;
using PortfolioWebsite.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PortfolioWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly PortfolioContext _context;

        public BlogController(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var blogPosts = await _context.BlogPosts
                .Where(b => b.Published)
                .OrderByDescending(b => b.PublishedAt)
                .ToListAsync();
            return View(blogPosts);
        }

        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Slug == slug && m.Published);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }
    }
}
