using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQuery : IRequest<IEnumerable<CategoriaDto>>
    {
    }
} 