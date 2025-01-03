using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly ApplicationDbContext _context;

        public AbsenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Absence> CreateAbsenceAsync(Absence absence)
        {
            await _context.Absences.AddAsync(absence);
            await _context.SaveChangesAsync();
            return absence;
        }

        public async Task<Absence?> DeleteAbsenceAsync(int id)
        {
            var absence = await _context.Absences.FirstOrDefaultAsync(x => x.Id == id);
            if (absence == null)
            {
                return null;
            }
            _context.Absences.Remove(absence);
            await _context.SaveChangesAsync();
            return absence;
        }

        public async Task<Absence?> GetAbsenceById(int id)
        {
            var absence = await _context.Absences.FirstOrDefaultAsync(x => x.Id == id);
            if (absence == null)
            {
                return null;
            }
            return absence;
        }

        public async Task<List<Absence>> GetAbsences()
        {
            return await _context.Absences.ToListAsync();
        }

        public async Task<Absence?> UpdateAbsenceAsync(int id, Absence absence)
        {
            var existingAbsence = await _context.Absences.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAbsence == null)
            {
                return null;
            }
            existingAbsence.StartDate = absence.StartDate;
            existingAbsence.EndDate = absence.EndDate;
            existingAbsence.Reason = absence.Reason;
            existingAbsence.EmployeeId = absence.EmployeeId;

            await _context.SaveChangesAsync();

            return existingAbsence;
        }
    }
}