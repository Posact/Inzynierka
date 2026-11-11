using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inzynierka.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa obiektu jest wymagana")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Metraż jest wymagany")]
        public double Area { get; set; } // Metraż w metrach kwadratowych

        [Required(ErrorMessage = "Liczba pokoi jest wymagana")]
        public int RoomCount { get; set; }

        public int? Floor { get; set; } // Opcjonalne - piętro (int? oznacza, że może być puste)

        public bool HasBalcony { get; set; } // True/False - czy ma balkon
        // -----------------

        public ICollection<Lease> Leases { get; set; }
    }
}