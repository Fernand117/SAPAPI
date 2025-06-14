using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface ISucursalRepository : IRepository<Sucursal>
    {
        Task<Sucursal> AddAsync(Sucursal sucursal);
        Task<bool> UpdateAsync(Sucursal sucursal);
        Task<bool> DeleteAsync(Sucursal sucursal);
        Task<Sucursal> GetByIdAsync(int sucursalId);
        Task<IEnumerable<Sucursal>> GetAllAsync();
        Task<IEnumerable<Sucursal>> GetByNombreAsync(string nombre);
        Task<Sucursal> GetByEmailAsync(string email);
    }
} 