using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IInventarioVendedorRepository
    {
        Task<IEnumerable<InventarioVendedor>> GetAllAsync();
        Task<InventarioVendedor> GetByIdAsync(int id);
        Task<IEnumerable<InventarioVendedor>> GetByEmpleadoIdAsync(int empleadoId);
        Task<IEnumerable<InventarioVendedor>> GetByProductoIdAsync(int productoId);
        Task<InventarioVendedor> AddAsync(InventarioVendedor inventarioVendedor);
        Task UpdateAsync(InventarioVendedor inventarioVendedor);
        Task DeleteAsync(int id);
    }
} 