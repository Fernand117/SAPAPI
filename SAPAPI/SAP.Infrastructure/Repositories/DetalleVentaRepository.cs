using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Infrastructure.Data;

namespace SAP.Infrastructure.Repositories
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public DetalleVentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleVenta>> GetAllAsync()
        {
            return await _context.DetalleVentas
                .Include(dv => dv.Producto)
                .Include(dv => dv.Venta)
                .ToListAsync();
        }

        public async Task<DetalleVenta> GetByIdAsync(int id)
        {
            return await _context.DetalleVentas
                .Include(dv => dv.Producto)
                .Include(dv => dv.Venta)
                .FirstOrDefaultAsync(dv => dv.DetalleVentaId == id);
        }

        public async Task<IEnumerable<DetalleVenta>> GetByVentaIdAsync(int ventaId)
        {
            return await _context.DetalleVentas
                .Include(dv => dv.Producto)
                .Include(dv => dv.Venta)
                .Where(dv => dv.VentaId == ventaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DetalleVenta>> GetByProductoIdAsync(int productoId)
        {
            return await _context.DetalleVentas
                .Include(dv => dv.Producto)
                .Include(dv => dv.Venta)
                .Where(dv => dv.ProductoId == productoId)
                .ToListAsync();
        }

        public async Task<DetalleVenta> AddAsync(DetalleVenta detalleVenta)
        {
            await _context.DetalleVentas.AddAsync(detalleVenta);
            await _context.SaveChangesAsync();
            return detalleVenta;
        }

        public async Task UpdateAsync(DetalleVenta detalleVenta)
        {
            _context.Entry(detalleVenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var detalleVenta = await _context.DetalleVentas.FindAsync(id);
            if (detalleVenta != null)
            {
                _context.DetalleVentas.Remove(detalleVenta);
                await _context.SaveChangesAsync();
            }
        }
    }
} 