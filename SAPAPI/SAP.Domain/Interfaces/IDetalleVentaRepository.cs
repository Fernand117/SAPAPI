using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IDetalleVentaRepository
    {
        Task<IEnumerable<DetalleVenta>> GetAllAsync();
        Task<DetalleVenta> GetByIdAsync(int id);
        Task<IEnumerable<DetalleVenta>> GetByVentaIdAsync(int ventaId);
        Task<IEnumerable<DetalleVenta>> GetByProductoIdAsync(int productoId);
        Task<DetalleVenta> AddAsync(DetalleVenta detalleVenta);
        Task UpdateAsync(DetalleVenta detalleVenta);
        Task DeleteAsync(int id);
    }
} 