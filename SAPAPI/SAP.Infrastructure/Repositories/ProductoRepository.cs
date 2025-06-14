using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Infrastructure.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Producto>> GetProductosByCategoriaAsync(int categoriaId)
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.ProductoAtributos)
                    .ThenInclude(a => a.Atributo)
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetProductosWithAtributosAsync()
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.ProductoAtributos)
                    .ThenInclude(a => a.Atributo)
                .ToListAsync();
        }

        public async Task<Producto> GetProductoWithAtributosAsync(int productoId)
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.ProductoAtributos)
                    .ThenInclude(a => a.Atributo)
                .FirstOrDefaultAsync(p => p.ProductoId == productoId);
        }

        public async Task<IEnumerable<Producto>> GetProductosBySucursalAsync(int sucursalId)
        {
            return await _dbSet
                .Include(p => p.Inventarios)
                .Where(p => p.Inventarios.Any(i => i.SucursalId == sucursalId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetProductosByVendedorAsync(int empleadoId)
        {
            return await _dbSet
                .Include(p => p.InventarioVendedores)
                .Where(p => p.InventarioVendedores.Any(iv => iv.EmpleadoId == empleadoId))
                .ToListAsync();
        }

        public async Task<bool> UpdateStockAsync(int productoId, int sucursalId, int cantidad)
        {
            var inventario = await _context.Set<Inventario>()
                .FirstOrDefaultAsync(i => i.ProductoId == productoId && i.SucursalId == sucursalId);

            if (inventario == null)
                return false;

            inventario.Cantidad += cantidad;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Producto> AddAsync(Producto producto)
        {
            await _dbSet.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> UpdateAsync(Producto producto)
        {
            _dbSet.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Producto producto)
        {
            _dbSet.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task AddAtributoAsync(ProductoAtributo productoAtributo, string valor)
        {
            var productoAtributoValor = new ProductoAtributoValor
            {
                ProductoId = productoAtributo.ProductoId,
                AtributoId = productoAtributo.AtributoId,
                Valor = valor
            };
            await _context.Set<ProductoAtributoValor>().AddAsync(productoAtributoValor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAtributoAsync(int productoId, int atributoId, string valor)
        {
            var atributo = await _context.Set<ProductoAtributoValor>()
                .FirstOrDefaultAsync(a => a.ProductoId == productoId && a.AtributoId == atributoId);
            if (atributo != null)
            {
                atributo.Valor = valor;
                _context.Set<ProductoAtributoValor>().Update(atributo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAtributosAsync(int productoId)
        {
            var atributos = _context.Set<ProductoAtributoValor>()
                .Where(a => a.ProductoId == productoId);
            _context.Set<ProductoAtributoValor>().RemoveRange(atributos);
            await _context.SaveChangesAsync();
        }

        public async Task<Producto> GetByIdWithAtributosAsync(int productoId)
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.ProductoAtributos)
                    .ThenInclude(a => a.Atributo)
                .Include(p => p.ProductoAtributos)
                .FirstOrDefaultAsync(p => p.ProductoId == productoId);
        }

        public async Task<IEnumerable<Producto>> GetAllWithAtributosAsync()
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.ProductoAtributos)
                    .ThenInclude(a => a.Atributo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId)
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.ProductoAtributos)
                    .ThenInclude(a => a.Atributo)
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }
    }
} 