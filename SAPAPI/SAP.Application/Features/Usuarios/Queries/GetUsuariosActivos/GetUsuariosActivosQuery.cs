using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Queries.GetUsuariosActivos
{
    public class GetUsuariosActivosQuery : IRequest<IEnumerable<UsuarioDto>>
    {
    }
} 