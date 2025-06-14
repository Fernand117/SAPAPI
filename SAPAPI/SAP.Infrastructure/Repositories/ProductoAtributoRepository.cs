using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Infrastructure.Persistence;

namespace SAP.Infrastructure.Repositories
{
    public class ProductoAtributoRepository : GenericRepository<ProductoAtributo>, IProductoAtributoRepository
    {
        private new readonly ApplicationDbContext _context;

        public ProductoAtributoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductoAtributo>> GetByProductoIdAsync(int productoId)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Atributo)
                .Where(pa => pa.ProductoId == productoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductoAtributo>> GetByAtributoIdAsync(int atributoId)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Producto)
                .Where(pa => pa.AtributoId == atributoId)
                .ToListAsync();
        }

        public async Task<ProductoAtributo> GetByProductoAndAtributoAsync(int productoId, int atributoId)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Producto)
                .Include(pa => pa.Atributo)
                .FirstOrDefaultAsync(pa => pa.ProductoId == productoId && pa.AtributoId == atributoId);
        }

        public async Task<IEnumerable<ProductoAtributo>> GetAtributosByProductoAsync(int productoId)
        {
            return await _dbSet
                .Include(pa => pa.Producto)
                .Include(pa => pa.Atributo)
                .Where(pa => pa.ProductoId == productoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductoAtributo>> GetProductosByAtributoAsync(int atributoId)
        {
            return await _dbSet
                .Include(pa => pa.Producto)
                .Include(pa => pa.Atributo)
                .Where(pa => pa.AtributoId == atributoId)
                .ToListAsync();
        }

        public async Task<ProductoAtributo> GetProductoAtributoByProductoAndAtributoAsync(int productoId, int atributoId)
        {
            return await _dbSet
                .Include(pa => pa.Producto)
                .Include(pa => pa.Atributo)
                .FirstOrDefaultAsync(pa => pa.ProductoId == productoId && pa.AtributoId == atributoId);
        }

        public async Task<IEnumerable<ProductoAtributo>> GetProductosAtributosConDetallesAsync()
        {
            return await _dbSet
                .Include(pa => pa.Producto)
                .Include(pa => pa.Atributo)
                .ToListAsync();
        }
    }
} 