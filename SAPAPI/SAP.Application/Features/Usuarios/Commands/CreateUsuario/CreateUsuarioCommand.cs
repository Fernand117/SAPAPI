using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<UsuarioDto>
    {
        public CreateUsuarioDto Usuario { get; set; }
    }
} 