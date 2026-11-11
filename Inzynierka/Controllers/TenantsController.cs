using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Inzynierka.Data;
using Inzynierka.Models;

namespace Inzynierka.Controllers
{
    public class TenantsController : Controller
    {
        private readonly RentalDbContext _context;

        public TenantsController(RentalDbContext context)
        {
            _context = context;
        }

        // Lista najemców
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenants.ToListAsync());
        }

        // Wyświetlenie formularza dodawania
        public IActionResult Create()
        {
            return View();
        }

        // Zapisanie formularza do bazy
        [HttpPost]
        public async Task<IActionResult> Create(Tenant tenant)
        {
            // Logika walidacji w C#
            if (!tenant.IsForeigner)
            {
                if (string.IsNullOrWhiteSpace(tenant.Pesel) || tenant.Pesel.Length != 11)
                {
                    ModelState.AddModelError("Pesel", "Dla obywatela RP wymagany jest poprawny, 11-cyfrowy PESEL.");
                }
            }
            else
            {
                // Jeśli jest obcokrajowcem, zdejmujemy ewentualne błędy walidacji z PESEL-u
                ModelState.Remove("Pesel");
            }

            if (ModelState.IsValid)
            {
                _context.Add(tenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tenant);
        }
    }
}