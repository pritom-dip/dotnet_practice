using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAbsenceRepository
    {
        Task<List<Absence>> GetAbsences();

        Task<Absence?> GetAbsenceById(int id);

        Task<Absence> CreateAbsenceAsync(Absence absence);

        Task<Absence?> DeleteAbsenceAsync(int id);

        Task<Absence?> UpdateAbsenceAsync(int id, Absence absence);
    }
}