using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        public required string Name { get; set; }

        public string? Address { get; set; } = String.Empty;
        public string? Phone { get; set; } = String.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}