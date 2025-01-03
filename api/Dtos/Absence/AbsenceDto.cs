using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Absence
{
    public class AbsenceDto
    {
        public int Id { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required string Reason { get; set; }

        public int? EmployeeId { get; set; }


    }
}