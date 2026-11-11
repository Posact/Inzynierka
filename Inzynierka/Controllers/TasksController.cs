using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Inzynierka.Data;
using Inzynierka.Models;

namespace Inzynierka.Controllers
{
    public class TasksController : Controller
    {
        private readonly RentalDbContext _context;

        public TasksController(RentalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks
                .Include(t => t.Property)
                .ToListAsync();

            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string newStatus)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.Status = newStatus;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}