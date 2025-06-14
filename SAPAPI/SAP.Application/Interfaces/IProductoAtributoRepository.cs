using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Application.Interfaces
{
    public interface IProductoAtributoRepository : IGenericRepository<ProductoAtributo>
    {
        Task<IEnumerable<ProductoAtributo>> GetAtributosByProductoAsync(int productoId);
        Task<IEnumerable<ProductoAtributo>> GetProductosByAtributoAsync(int atributoId);
        Task<ProductoAtributo> GetProductoAtributoByProductoAndAtributoAsync(int productoId, int atributoId);
        Task<IEnumerable<ProductoAtributo>> GetProductosAtributosConDetallesAsync();
    }
} 