using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Absence
{
    public class CreateAbsenceDto
    {
        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public required string Reason { get; set; }

    }
}