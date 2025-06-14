using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Application.Interfaces
{
    public interface IAtributoProductoRepository : IGenericRepository<AtributoProducto>
    {
        Task<IEnumerable<AtributoProducto>> GetAtributosByProductoAsync(int productoId);
        Task<IEnumerable<AtributoProducto>> GetProductosByAtributoAsync(int atributoId);
        Task<AtributoProducto> GetAtributoProductoByProductoAndAtributoAsync(int productoId, int atributoId);
        Task<IEnumerable<AtributoProducto>> GetAtributosProductoConDetallesAsync();
    }
} 