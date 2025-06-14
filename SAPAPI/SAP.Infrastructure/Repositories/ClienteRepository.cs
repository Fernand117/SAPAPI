using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;

namespace SAP.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContext context) : base(context) { }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            await _dbSet.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            _dbSet.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Cliente cliente)
        {
            _dbSet.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> GetByIdAsync(int clienteId)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetByNombreAsync(string nombre)
        {
            return await _dbSet.Where(c => c.Nombre.Contains(nombre)).ToListAsync();
        }

        public async Task<Cliente> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
} 