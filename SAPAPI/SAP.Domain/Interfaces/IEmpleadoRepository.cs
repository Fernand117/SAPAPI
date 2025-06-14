using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        Task<Empleado> GetEmpleadoWithUsuarioAsync(int empleadoId);
        Task<IEnumerable<Empleado>> GetEmpleadosBySucursalAsync(int sucursalId);
        Task<IEnumerable<Asistencia>> GetAsistenciasByEmpleadoAsync(int empleadoId, DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<Incidencia>> GetIncidenciasByEmpleadoAsync(int empleadoId, DateTime fechaInicio, DateTime fechaFin);
        Task<bool> RegistrarAsistenciaAsync(Asistencia asistencia);
        Task<bool> RegistrarIncidenciaAsync(Incidencia incidencia);
        Task<bool> RegistrarPermisoSalidaAsync(PermisoSalida permiso);
        Task<bool> UpdateAsync(Empleado empleado);
        Task<bool> DeleteAsync(Empleado empleado);
        Task<IEnumerable<Empleado>> GetBySucursalAsync(int sucursalId);
        Task<Empleado> AddAsync(Empleado empleado);
    }
} 