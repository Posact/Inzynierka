using Microsoft.EntityFrameworkCore;
using Inzynierka.Models;

namespace Inzynierka.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
}