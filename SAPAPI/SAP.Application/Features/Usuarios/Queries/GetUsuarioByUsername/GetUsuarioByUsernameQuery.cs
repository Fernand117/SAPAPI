using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Queries.GetUsuarioByUsername
{
    public class GetUsuarioByUsernameQuery : IRequest<UsuarioDto>
    {
        public string Username { get; set; }
    }
} 