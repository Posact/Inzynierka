using System;
using System.ComponentModel.DataAnnotations;

namespace Inzynierka.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public string Status { get; set; } = "Do zrobienia";

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}