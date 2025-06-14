using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Infrastructure.Repositories
{
    public class SucursalRepository : Repository<Sucursal>, ISucursalRepository
    {
        public SucursalRepository(DbContext context) : base(context) { }

        public async Task<Sucursal> AddAsync(Sucursal sucursal)
        {
            await _dbSet.AddAsync(sucursal);
            await _context.SaveChangesAsync();
            return sucursal;
        }

        public async Task<bool> UpdateAsync(Sucursal sucursal)
        {
            _dbSet.Update(sucursal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Sucursal sucursal)
        {
            _dbSet.Remove(sucursal);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Sucursal> GetByIdAsync(int sucursalId)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.SucursalId == sucursalId);
        }

        public async Task<IEnumerable<Sucursal>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Sucursal>> GetByNombreAsync(string nombre)
        {
            return await _dbSet.Where(s => s.Nombre.Contains(nombre)).ToListAsync();
        }

        public async Task<Sucursal> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Email == email);
        }
    }
} 