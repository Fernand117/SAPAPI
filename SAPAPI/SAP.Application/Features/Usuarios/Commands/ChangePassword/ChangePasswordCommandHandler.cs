using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Usuarios.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ChangePasswordCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);
            if (usuario == null)
                return false;

            // Verificar la contraseña actual
            if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, usuario.PasswordHash))
                return false;

            // Actualizar con la nueva contraseña
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            return await _usuarioRepository.UpdateAsync(usuario);
        }
    }
} 