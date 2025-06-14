using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommand : IRequest<UsuarioDto>
    {
        public UpdateUsuarioDto Usuario { get; set; }
    }
} 