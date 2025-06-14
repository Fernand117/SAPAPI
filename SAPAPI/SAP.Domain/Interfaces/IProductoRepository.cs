using System.Collections.Generic;
using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductosByCategoriaAsync(int categoriaId);
        Task<IEnumerable<Producto>> GetProductosWithAtributosAsync();
        Task<Producto> GetProductoWithAtributosAsync(int productoId);
        Task<IEnumerable<Producto>> GetProductosBySucursalAsync(int sucursalId);
        Task<IEnumerable<Producto>> GetProductosByVendedorAsync(int usuarioId);
        Task<bool> UpdateStockAsync(int productoId, int sucursalId, int cantidad);
        Task<Producto> AddAsync(Producto producto);
        Task<bool> UpdateAsync(Producto producto);
        Task<bool> DeleteAsync(Producto producto);
        Task AddAtributoAsync(ProductoAtributo productoAtributo, string valor);
        Task UpdateAtributoAsync(int productoId, int atributoId, string valor);
        Task DeleteAtributosAsync(int productoId);
        Task<Producto> GetByIdWithAtributosAsync(int productoId);
        Task<IEnumerable<Producto>> GetAllWithAtributosAsync();
        Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId);
    }
} 