using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Infrastructure.Repositories
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        public VentaRepository(DbContext context) : base(context)
        {
        }

        public async Task<Venta> GetVentaWithDetallesAsync(int ventaId)
        {
            return await _dbSet
                .Include(v => v.Cliente)
                .Include(v => v.Empleado)
                .Include(v => v.Sucursal)
                .Include(v => v.DetalleVentas)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.VentaId == ventaId);
        }

        public async Task<IEnumerable<Venta>> GetVentasByClienteAsync(int clienteId)
        {
            return await _dbSet
                .Include(v => v.DetalleVentas)
                .Where(v => v.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venta>> GetVentasBySucursalAsync(int sucursalId)
        {
            return await _dbSet
                .Include(v => v.DetalleVentas)
                .Where(v => v.SucursalId == sucursalId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venta>> GetVentasByVendedorAsync(int empleadoId)
        {
            return await _dbSet
                .Include(v => v.DetalleVentas)
                .Where(v => v.EmpleadoId == empleadoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Venta>> GetVentasByFechaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _dbSet
                .Include(v => v.DetalleVentas)
                .Where(v => v.Fecha >= fechaInicio && v.Fecha <= fechaFin)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalVentasByPeriodoAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _dbSet
                .Where(v => v.Fecha >= fechaInicio && v.Fecha <= fechaFin)
                .SumAsync(v => v.Total);
        }

        public async Task<bool> RegistrarVentaAsync(Venta venta, IEnumerable<DetalleVenta> detalles)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _dbSet.AddAsync(venta);
                await _context.SaveChangesAsync();

                foreach (var detalle in detalles)
                {
                    detalle.VentaId = venta.VentaId;
                    await _context.Set<DetalleVenta>().AddAsync(detalle);

                    // Actualizar inventario
                    var inventario = await _context.Set<Inventario>()
                        .FirstOrDefaultAsync(i => i.ProductoId == detalle.ProductoId && i.SucursalId == venta.SucursalId);

                    if (inventario != null)
                    {
                        inventario.Cantidad -= detalle.Cantidad;
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
} 