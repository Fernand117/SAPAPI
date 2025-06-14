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
    public class AtributoProductoRepository : Repository<ProductoAtributo>, SAP.Domain.Interfaces.IAtributoProductoRepository
    {
        private new readonly ApplicationDbContext _context;

        public AtributoProductoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductoAtributo>> GetAtributosByProductoAsync(int productoId)
        {
            return await _dbSet
                .Include(ap => ap.Producto)
                .Include(ap => ap.Atributo)
                .Where(ap => ap.ProductoId == productoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductoAtributo>> GetProductosByAtributoAsync(int atributoId)
        {
            return await _dbSet
                .Include(ap => ap.Producto)
                .Include(ap => ap.Atributo)
                .Where(ap => ap.AtributoId == atributoId)
                .ToListAsync();
        }

        public async Task<ProductoAtributo> GetAtributoProductoByProductoAndAtributoAsync(int productoId, int atributoId)
        {
            return await _dbSet
                .Include(ap => ap.Producto)
                .Include(ap => ap.Atributo)
                .FirstOrDefaultAsync(ap => ap.ProductoId == productoId && ap.AtributoId == atributoId);
        }

        public async Task<IEnumerable<ProductoAtributo>> GetAtributosProductoConDetallesAsync()
        {
            return await _dbSet
                .Include(ap => ap.Producto)
                .Include(ap => ap.Atributo)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductoAtributo>> GetByCategoriaIdAsync(int categoriaId)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Producto)
                .Where(pa => pa.Producto.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task<ProductoAtributo> GetByNombreAsync(string nombre)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Atributo)
                .FirstOrDefaultAsync(pa => pa.Atributo.Nombre == nombre);
        }

        public async Task<IEnumerable<ProductoAtributo>> GetByTipoDatoAsync(string tipoDato)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Atributo)
                .Where(pa => pa.Atributo.Tipo == tipoDato)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductoAtributo>> GetByCategoriaAndTipoAsync(int categoriaId, string tipoDato)
        {
            return await _context.ProductoAtributos
                .Include(pa => pa.Producto)
                .Include(pa => pa.Atributo)
                .Where(pa => pa.Producto.CategoriaId == categoriaId && pa.Atributo.Tipo == tipoDato)
                .ToListAsync();
        }
    }
} 