using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Categorias.Queries.SearchCategorias
{
    public class SearchCategoriasQuery : IRequest<IEnumerable<CategoriaDto>>
    {
        public string SearchTerm { get; set; }
    }
} 