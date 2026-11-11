using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Inzynierka.Data;
using Inzynierka.Models;

namespace Inzynierka.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly RentalDbContext _context;

        public PropertiesController(RentalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Properties.ToListAsync());
        }

        // GET: Wyświetla formularz
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zapisuje do bazy i wysyła pop-up
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Property property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property);
                await _context.SaveChangesAsync();

                // Przekazujemy komunikat o sukcesie
                TempData["SuccessMessage"] = $"Nieruchomość \"{property.Name}\" została dodana do bazy!";

                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }
    }
}