using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Infrastructure.Persistence;

namespace SAP.Infrastructure.Repositories
{
    public class SucursalRepository : Repository<Sucursal>, ISucursalRepository
    {
        public SucursalRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<Sucursal> AddAsync(Sucursal entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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

        public override async Task<Sucursal> GetByIdAsync(int id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.SucursalId == id);
        }

        public override async Task<IEnumerable<Sucursal>> GetAllAsync()
        {
            return await _dbSet
                .ToListAsync();
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