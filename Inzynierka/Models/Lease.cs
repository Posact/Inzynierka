using System;

namespace Inzynierka.Models
{
    public class Lease
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

        // Zmieniliśmy to: teraz umowa jest połączona z konkretnym najemcą z bazy
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public decimal MonthlyRent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}