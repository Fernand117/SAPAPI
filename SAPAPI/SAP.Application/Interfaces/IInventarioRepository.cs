using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Application.Interfaces
{
    public interface IInventarioRepository : IGenericRepository<Inventario>
    {
        Task<IEnumerable<Inventario>> GetInventarioBySucursalAsync(int sucursalId);
        Task<IEnumerable<Inventario>> GetInventarioByProductoAsync(int productoId);
        Task<Inventario> GetInventarioByProductoAndSucursalAsync(int productoId, int sucursalId);
        Task<IEnumerable<Inventario>> GetInventarioBajoStockAsync(int cantidadMinima);
        Task<IEnumerable<Inventario>> GetInventarioConDetallesAsync();
    }
} 