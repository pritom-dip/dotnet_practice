using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this Employee employeeModel)
        {
            return new EmployeeDto
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Address = employeeModel.Address,
                Phone = employeeModel.Phone,
                Absences = employeeModel.Absences.Select(c => c.ToAbsenceDto()).ToList()
            };
        }

        public static Employee ToCreateEmployeeDto(this CreateEmployeeDto employeeDto)
        {
            return new Employee
            {
                Name = employeeDto.Name,
                Address = employeeDto.Address,
                Phone = employeeDto.Phone,
                CreatedOn = employeeDto.CreatedOn
            };
        }

    }
}