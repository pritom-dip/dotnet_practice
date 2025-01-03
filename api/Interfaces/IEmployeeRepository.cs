using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();

        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task<Employee> CreateEmployeeAsync(Employee employee);

        Task<Employee?> DeleteEmployeeAsync(int id);

        Task<bool> EmployeeExists(int id);
    }
}