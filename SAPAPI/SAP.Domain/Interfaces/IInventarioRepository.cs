using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IInventarioRepository : IGenericRepository<Inventario>
    {
        Task<IEnumerable<Inventario>> GetInventarioBySucursalAsync(int sucursalId);
        Task<Inventario> GetInventarioByProductoAndSucursalAsync(int productoId, int sucursalId);
        Task<IEnumerable<Inventario>> GetInventarioBajoStockAsync(int cantidadMinima);
    }
} 