using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> AddAsync(Categoria categoria);
        Task<bool> UpdateAsync(Categoria categoria);
        Task<bool> DeleteAsync(Categoria categoria);
        Task<Categoria> GetByIdAsync(int categoriaId);
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<IEnumerable<Categoria>> GetCategoriasActivasAsync();
    }
} 