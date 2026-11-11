using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Inzynierka.Data;
using Inzynierka.Models;

namespace Inzynierka.Controllers
{
    public class LeasesController : Controller
    {
        private readonly RentalDbContext _context;

        public LeasesController(RentalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var leases = await _context.Leases
                .Include(l => l.Property)
                .Include(l => l.Tenant)
                .ToListAsync();
            return View(leases);
        }

        // GET: Wyświetla formularz
        public IActionResult Create()
        {
            // Przekazanie list do widoku (Id to wartość wysyłana do bazy, Name/FullName to tekst widoczny dla użytkownika)
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name");
            ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "FullName");
            return View();
        }

        // POST: Zapisuje do bazy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lease lease)
        {
            // Ignorujemy właściwości nawigacyjne podczas walidacji formularza
            ModelState.Remove("Property");
            ModelState.Remove("Tenant");

            if (ModelState.IsValid)
            {
                _context.Add(lease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Jeśli walidacja się nie powiedzie, musimy ponownie załadować listy
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name", lease.PropertyId);
            ViewData["TenantId"] = new SelectList(_context.Tenants, "Id", "FullName", lease.TenantId);
            return View(lease);
        }
    }
}