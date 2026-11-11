using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inzynierka.Models
{
    public class Tenant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsForeigner { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "PESEL musi mieć 11 znaków")]
        public string? Pesel { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }

        // Relacja: jeden najemca może mieć wiele umów
        public ICollection<Lease> Leases { get; set; }

        // Właściwość pomocnicza do wyświetlania w widokach
        public string FullName => $"{FirstName} {LastName}";
    }
}