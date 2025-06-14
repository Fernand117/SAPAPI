using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DeleteUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);
            if (usuario == null)
                return false;

            await _usuarioRepository.DeleteAsync(usuario);
            return true;
        }
    }
} 