using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Absence;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("absence")]
    public class AbsenceController : ControllerBase
    {
        private readonly IAbsenceRepository _absenceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AbsenceController(IAbsenceRepository absenceRepository, IEmployeeRepository employeeRepository)
        {
            _absenceRepository = absenceRepository;
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAbsences()
        {
            var results = await _absenceRepository.GetAbsences();
            var absences = results.Select(absence => absence.ToAbsenceDto());
            return Ok(absences);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetAbsence([FromRoute] int id)
        {
            var absence = await _absenceRepository.GetAbsenceById(id);
            if (absence == null)
            {
                return NotFound();
            }
            return Ok(absence.ToAbsenceDto());
        }

        [HttpPost]
        [Route("{employeeId:int}")]
        public async Task<IActionResult> CreateAbsence([FromRoute] int employeeId, [FromBody] CreateAbsenceDto CreateAbsenceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _employeeRepository.EmployeeExists(employeeId))
            {
                return BadRequest("Employee does not exist");
            }

            var absence = CreateAbsenceDto.ToCreateAbsenceDto(employeeId);
            await _absenceRepository.CreateAbsenceAsync(absence);
            return CreatedAtAction(nameof(GetAbsence), new { id = absence.Id }, absence.ToAbsenceDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var absence = await _absenceRepository.DeleteAbsenceAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            return Ok(absence.ToAbsenceDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAbsence([FromRoute] int id, [FromBody] UpdateAbsenceDto updateAbsenceDto)
        {
            if (!await _employeeRepository.EmployeeExists(updateAbsenceDto.EmployeeId))
            {
                return BadRequest("Employee does not exist");
            }

            var absenceDto = updateAbsenceDto.ToUpdateAbsenceDto();
            var updatedAbsence = await _absenceRepository.UpdateAbsenceAsync(id, absenceDto);

            if (updatedAbsence == null)
            {
                return NotFound();
            }

            return Ok(updatedAbsence.ToAbsenceDto());

        }

    }
}