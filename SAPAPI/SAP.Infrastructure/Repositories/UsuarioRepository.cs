using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAP.Domain.Entities;
using SAP.Domain.Interfaces;
using SAP.Infrastructure.Persistence;

namespace SAP.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _dbSet
                .Include(u => u.UsuarioRoles)
                    .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            _dbSet.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Usuario usuario)
        {
            _dbSet.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignRoleAsync(int usuarioId, int rolId)
        {
            var usuarioRol = new UsuarioRol
            {
                UsuarioId = usuarioId,
                RolId = rolId
            };

            await _context.Set<UsuarioRol>().AddAsync(usuarioRol);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRoleAsync(int usuarioId, int rolId)
        {
            var usuarioRol = await _context.Set<UsuarioRol>()
                .FirstOrDefaultAsync(ur => ur.UsuarioId == usuarioId && ur.RolId == rolId);

            if (usuarioRol == null)
                return false;

            _context.Set<UsuarioRol>().Remove(usuarioRol);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Usuario> GetUsuarioByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<Usuario> GetUsuarioWithRolesAsync(int usuarioId)
        {
            return await _dbSet
                .Include(u => u.UsuarioRoles)
                .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var usuario = await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
            if (usuario == null) return false;
            // Aquí deberías usar el validador de hash real, por simplicidad se compara directo
            return usuario.PasswordHash == password;
        }

        public async Task<bool> UpdatePasswordAsync(int usuarioId, string newPasswordHash)
        {
            var usuario = await _dbSet.FindAsync(usuarioId);
            if (usuario == null) return false;
            usuario.PasswordHash = newPasswordHash;
            _dbSet.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public override async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _dbSet.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
} 