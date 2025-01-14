using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Data;
using PortfolioWebsite.Models;
using System.Threading.Tasks;

namespace PortfolioWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();
                // Optionally, send an email notification here
                return RedirectToAction("ThankYou");
            }
            return View(message);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
