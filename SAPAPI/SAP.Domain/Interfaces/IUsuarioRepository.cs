using System.Threading.Tasks;
using SAP.Domain.Entities;

namespace SAP.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetUsuarioByUsernameAsync(string username);
        Task<Usuario> GetUsuarioWithRolesAsync(int usuarioId);
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task<bool> UpdatePasswordAsync(int usuarioId, string newPasswordHash);
        Task<bool> AssignRoleAsync(int usuarioId, int rolId);
        Task<bool> RemoveRoleAsync(int usuarioId, int rolId);
        Task<Usuario> GetByUsernameAsync(string username);
        Task<Usuario> GetByEmailAsync(string email);
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(Usuario usuario);
        Task<Usuario> AddAsync(Usuario usuario);
    }
}