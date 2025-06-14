using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Infrastructure.Persistence;

namespace SAP.Infrastructure.Repositories
{
    public class InventarioVendedorRepository : IInventarioVendedorRepository
    {
        private readonly ApplicationDbContext _context;

        public InventarioVendedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventarioVendedor>> GetAllAsync()
        {
            return await _context.InventarioVendedores
                .Include(iv => iv.Producto)
                .Include(iv => iv.Empleado)
                .ToListAsync();
        }

        public async Task<InventarioVendedor> GetByIdAsync(int id)
        {
            return await _context.InventarioVendedores
                .Include(iv => iv.Producto)
                .Include(iv => iv.Empleado)
                .FirstOrDefaultAsync(iv => iv.InventarioVendedorId == id);
        }

        public async Task<IEnumerable<InventarioVendedor>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.InventarioVendedores
                .Include(iv => iv.Producto)
                .Include(iv => iv.Empleado)
                .Where(iv => iv.EmpleadoId == empleadoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventarioVendedor>> GetByProductoIdAsync(int productoId)
        {
            return await _context.InventarioVendedores
                .Include(iv => iv.Producto)
                .Include(iv => iv.Empleado)
                .Where(iv => iv.ProductoId == productoId)
                .ToListAsync();
        }

        public async Task<InventarioVendedor> AddAsync(InventarioVendedor inventarioVendedor)
        {
            await _context.InventarioVendedores.AddAsync(inventarioVendedor);
            await _context.SaveChangesAsync();
            return inventarioVendedor;
        }

        public async Task UpdateAsync(InventarioVendedor inventarioVendedor)
        {
            _context.Entry(inventarioVendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inventarioVendedor = await _context.InventarioVendedores.FindAsync(id);
            if (inventarioVendedor != null)
            {
                _context.InventarioVendedores.Remove(inventarioVendedor);
                await _context.SaveChangesAsync();
            }
        }
    }
} 