using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetCategoriasActivas
{
    public class GetCategoriasActivasQuery : IRequest<IEnumerable<CategoriaDto>>
    {
    }
} 