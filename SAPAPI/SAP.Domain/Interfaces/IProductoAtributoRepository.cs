using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IProductoAtributoRepository : IGenericRepository<ProductoAtributo>
    {
        Task<IEnumerable<ProductoAtributo>> GetByProductoIdAsync(int productoId);
        Task<IEnumerable<ProductoAtributo>> GetByAtributoIdAsync(int atributoId);
        Task<ProductoAtributo> GetByProductoAndAtributoAsync(int productoId, int atributoId);
    }
} 