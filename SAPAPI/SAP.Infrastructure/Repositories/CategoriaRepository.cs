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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private new readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasActivasAsync()
        {
            return await _context.Categorias
                .Where(c => c.Activa)
                .ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByNombreAsync(string nombre)
        {
            return await _context.Categorias
                .FirstOrDefaultAsync(c => c.Nombre == nombre);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasConProductosAsync()
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .ToListAsync();
        }

        public async Task<Categoria> GetCategoriaConProductosAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasPadreAsync()
        {
            return await _context.Categorias
                .Where(c => c.CategoriaPadreId == null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetSubCategoriasAsync(int categoriaPadreId)
        {
            return await _context.Categorias
                .Where(c => c.CategoriaPadreId == categoriaPadreId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Categoria entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync(int categoriaId)
        {
            return await _context.Productos
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetByNombreAsync(string nombre)
        {
            return await _context.Categorias
                .Where(c => c.Nombre.Contains(nombre))
                .Include(c => c.CategoriaPadre)
                .Include(c => c.Productos)
                .ToListAsync();
        }

        public override async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.CategoriaPadre)
                .Include(c => c.SubCategorias)
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

        public override async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _context.Categorias
                .Include(c => c.CategoriaPadre)
                .Include(c => c.SubCategorias)
                .Include(c => c.Productos)
                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasPorNombreAsync(string nombre)
        {
            return await _dbSet
                .Where(c => c.Nombre.Contains(nombre))
                .ToListAsync();
        }
    }
} 