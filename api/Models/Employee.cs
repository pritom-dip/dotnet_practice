using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<Absence> Absences { get; set; } = new List<Absence>();
    }
}