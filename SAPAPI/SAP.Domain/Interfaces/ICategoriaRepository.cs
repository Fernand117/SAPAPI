using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetSubCategoriasAsync(int categoriaPadreId);
        Task<IEnumerable<Producto>> GetProductosAsync(int categoriaId);
        Task<IEnumerable<Categoria>> GetCategoriasPadreAsync();
        Task<IEnumerable<Categoria>> GetByNombreAsync(string nombre);
    }
} 