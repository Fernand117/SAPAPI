using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IAsistenciaRepository
    {
        Task<IEnumerable<Asistencia>> GetAllAsync();
        Task<Asistencia> GetByIdAsync(int id);
        Task<IEnumerable<Asistencia>> GetByEmpleadoIdAsync(int empleadoId);
        Task<IEnumerable<Asistencia>> GetByFechaAsync(DateTime fecha);
        Task<IEnumerable<Asistencia>> GetByEmpleadoAndFechaRangeAsync(int empleadoId, DateTime fechaInicio, DateTime fechaFin);
        Task<Asistencia> AddAsync(Asistencia asistencia);
        Task UpdateAsync(Asistencia asistencia);
        Task DeleteAsync(int id);
    }
} 