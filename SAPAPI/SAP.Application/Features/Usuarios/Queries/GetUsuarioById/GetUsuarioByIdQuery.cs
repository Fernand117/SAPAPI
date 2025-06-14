using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioDto>
    {
        public int UsuarioId { get; set; }
    }
} 