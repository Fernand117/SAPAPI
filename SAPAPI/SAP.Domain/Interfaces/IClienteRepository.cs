using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> AddAsync(Cliente cliente);
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(Cliente cliente);
        Task<Cliente> GetByIdAsync(int clienteId);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<IEnumerable<Cliente>> GetByNombreAsync(string nombre);
        Task<Cliente> GetByEmailAsync(string email);
    }
} 