using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var results = await _employeeRepo.GetAllEmployeesAsync();
            var employees = results.Select(employee => employee.ToEmployeeDto());

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _employeeRepo.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee.ToEmployeeDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var employee = createEmployeeDto.ToCreateEmployeeDto();
            await _employeeRepo.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee.ToEmployeeDto());
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await _employeeRepo.DeleteEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee.ToEmployeeDto());
        }
    }
}