using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Absence;
using api.Models;

namespace api.Mappers
{
    public static class absenceMappers
    {
        public static AbsenceDto ToAbsenceDto(this Absence absence)
        {
            return new AbsenceDto
            {
                Id = absence.Id,
                StartDate = absence.StartDate,
                EndDate = absence.EndDate,
                Reason = absence.Reason,
                EmployeeId = absence.EmployeeId,
            };
        }

        public static Absence ToCreateAbsenceDto(this CreateAbsenceDto createAbsenceDto, int employeeId)
        {
            return new Absence
            {
                StartDate = createAbsenceDto.StartDate,
                EndDate = createAbsenceDto.EndDate,
                Reason = createAbsenceDto.Reason,
                EmployeeId = employeeId
            };
        }

        public static Absence ToUpdateAbsenceDto(this UpdateAbsenceDto updateAbsenceDto)
        {
            return new Absence
            {
                StartDate = updateAbsenceDto.StartDate,
                EndDate = updateAbsenceDto.EndDate,
                Reason = updateAbsenceDto.Reason,
                EmployeeId = updateAbsenceDto.EmployeeId
            };
        }
    }
}