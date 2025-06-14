using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<Venta> GetVentaWithDetallesAsync(int ventaId);
        Task<IEnumerable<Venta>> GetVentasByClienteAsync(int clienteId);
        Task<IEnumerable<Venta>> GetVentasBySucursalAsync(int sucursalId);
        Task<IEnumerable<Venta>> GetVentasByVendedorAsync(int usuarioId);
        Task<IEnumerable<Venta>> GetVentasByFechaAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<decimal> GetTotalVentasByPeriodoAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<bool> RegistrarVentaAsync(Venta venta, IEnumerable<DetalleVenta> detalles);
    }
} 