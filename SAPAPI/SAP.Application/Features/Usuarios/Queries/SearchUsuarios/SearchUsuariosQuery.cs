using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Usuarios.Queries.SearchUsuarios
{
    public class SearchUsuariosQuery : IRequest<IEnumerable<UsuarioDto>>
    {
        public string SearchTerm { get; set; }
    }
} 