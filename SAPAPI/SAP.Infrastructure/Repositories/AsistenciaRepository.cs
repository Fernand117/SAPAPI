using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Infrastructure.Persistence;

namespace SAP.Infrastructure.Repositories
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asistencia>> GetAllAsync()
        {
            return await _context.Asistencias
                .Include(a => a.Empleado)
                .ToListAsync();
        }

        public async Task<Asistencia> GetByIdAsync(int id)
        {
            return await _context.Asistencias
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(a => a.AsistenciaId == id);
        }

        public async Task<IEnumerable<Asistencia>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.Asistencias
                .Include(a => a.Empleado)
                .Where(a => a.EmpleadoId == empleadoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asistencia>> GetByFechaAsync(DateTime fecha)
        {
            return await _context.Asistencias
                .Include(a => a.Empleado)
                .Where(a => a.Fecha.Date == fecha.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asistencia>> GetByEmpleadoAndFechaRangeAsync(int empleadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Asistencias
                .Include(a => a.Empleado)
                .Where(a => a.EmpleadoId == empleadoId && 
                           a.Fecha.Date >= fechaInicio.Date && 
                           a.Fecha.Date <= fechaFin.Date)
                .ToListAsync();
        }

        public async Task<Asistencia> AddAsync(Asistencia asistencia)
        {
            await _context.Asistencias.AddAsync(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

        public async Task UpdateAsync(Asistencia asistencia)
        {
            _context.Entry(asistencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia != null)
            {
                _context.Asistencias.Remove(asistencia);
                await _context.SaveChangesAsync();
            }
        }
    }
} 