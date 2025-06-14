using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Infrastructure.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(DbContext context) : base(context)
        {
        }

        public async Task<Empleado> GetEmpleadoWithUsuarioAsync(int empleadoId)
        {
            return await _dbSet
                .Include(e => e.Usuario)
                .Include(e => e.Sucursal)
                .FirstOrDefaultAsync(e => e.EmpleadoId == empleadoId);
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosBySucursalAsync(int sucursalId)
        {
            return await _dbSet
                .Include(e => e.Usuario)
                .Where(e => e.SucursalId == sucursalId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asistencia>> GetAsistenciasByEmpleadoAsync(int empleadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Set<Asistencia>()
                .Where(a => a.EmpleadoId == empleadoId && a.Fecha >= fechaInicio && a.Fecha <= fechaFin)
                .ToListAsync();
        }

        public async Task<IEnumerable<Incidencia>> GetIncidenciasByEmpleadoAsync(int empleadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Set<Incidencia>()
                .Where(i => i.EmpleadoId == empleadoId && i.Fecha >= fechaInicio && i.Fecha <= fechaFin)
                .ToListAsync();
        }

        public async Task<bool> RegistrarAsistenciaAsync(Asistencia asistencia)
        {
            await _context.Set<Asistencia>().AddAsync(asistencia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RegistrarIncidenciaAsync(Incidencia incidencia)
        {
            await _context.Set<Incidencia>().AddAsync(incidencia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RegistrarPermisoSalidaAsync(PermisoSalida permiso)
        {
            await _context.Set<PermisoSalida>().AddAsync(permiso);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Empleado empleado)
        {
            _dbSet.Update(empleado);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Empleado empleado)
        {
            _dbSet.Remove(empleado);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Empleado>> GetBySucursalAsync(int sucursalId)
        {
            return await _dbSet
                .Where(e => e.SucursalId == sucursalId)
                .ToListAsync();
        }

        public override async Task<Empleado> AddAsync(Empleado entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
} 