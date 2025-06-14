using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IAtributoProductoRepository : IGenericRepository<ProductoAtributo>
    {
        Task<IEnumerable<ProductoAtributo>> GetByCategoriaIdAsync(int categoriaId);
        Task<ProductoAtributo> GetByNombreAsync(string nombre);
        Task<IEnumerable<ProductoAtributo>> GetByTipoDatoAsync(string tipoDato);
        Task<IEnumerable<ProductoAtributo>> GetByCategoriaAndTipoAsync(int categoriaId, string tipoDato);
    }
} 