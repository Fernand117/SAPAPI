using MediatR;

namespace SAP.Application.Features.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
    }
} 