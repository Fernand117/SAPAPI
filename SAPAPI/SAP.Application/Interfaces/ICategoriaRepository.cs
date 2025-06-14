using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Application.Interfaces
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriasConProductosAsync();
        Task<Categoria> GetCategoriaConProductosAsync(int id);
        Task<IEnumerable<Categoria>> GetCategoriasActivasAsync();
        Task<IEnumerable<Categoria>> GetCategoriasPorNombreAsync(string nombre);
    }
} 