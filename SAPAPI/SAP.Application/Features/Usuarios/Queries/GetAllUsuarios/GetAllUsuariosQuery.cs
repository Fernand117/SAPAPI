using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Queries.GetAllUsuarios
{
    public class GetAllUsuariosQuery : IRequest<IEnumerable<UsuarioDto>>
    {
    }
} 