using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Infrastructure.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DbContext context) : base(context) { }

        public async Task<Categoria> AddAsync(Categoria categoria)
        {
            await _dbSet.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> UpdateAsync(Categoria categoria)
        {
            _dbSet.Update(categoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Categoria categoria)
        {
            _dbSet.Remove(categoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Categoria> GetByIdAsync(int categoriaId)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.CategoriaId == categoriaId);
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasActivasAsync()
        {
            return await _dbSet.Where(c => c.Activa).ToListAsync();
        }
    }
} 