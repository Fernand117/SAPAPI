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
    public class InventarioRepository : GenericRepository<Inventario>, IInventarioRepository
    {
        private new readonly ApplicationDbContext _context;

        public InventarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventario>> GetInventarioBySucursalAsync(int sucursalId)
        {
            return await _context.Inventarios
                .Include(i => i.Producto)
                .Where(i => i.SucursalId == sucursalId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Inventario>> GetInventarioByProductoAsync(int productoId)
        {
            return await _dbSet
                .Include(i => i.Producto)
                .Include(i => i.Sucursal)
                .Where(i => i.ProductoId == productoId)
                .ToListAsync();
        }

        public async Task<Inventario> GetInventarioByProductoAndSucursalAsync(int productoId, int sucursalId)
        {
            return await _context.Inventarios
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(i => i.ProductoId == productoId && i.SucursalId == sucursalId);
        }

        public async Task<IEnumerable<Inventario>> GetInventarioBajoStockAsync(int cantidadMinima)
        {
            return await _context.Inventarios
                .Include(i => i.Producto)
                .Where(i => i.Cantidad <= cantidadMinima)
                .ToListAsync();
        }

        public async Task<IEnumerable<Inventario>> GetInventarioConDetallesAsync()
        {
            return await _dbSet
                .Include(i => i.Producto)
                .Include(i => i.Sucursal)
                .ToListAsync();
        }
    }
} 