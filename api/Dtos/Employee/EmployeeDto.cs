using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Absence;
using api.Models;

namespace api.Dtos.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public List<AbsenceDto> Absences { get; set; } = new List<AbsenceDto>();

    }
}