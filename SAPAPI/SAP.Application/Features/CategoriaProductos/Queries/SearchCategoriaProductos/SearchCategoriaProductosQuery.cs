using MediatR;
using SAP.Application.DTOs;
using System.Collections.Generic;

namespace SAP.Application.Features.CategoriaProductos.Queries.SearchCategoriaProductos
{
    public class SearchCategoriaProductosQuery : IRequest<IEnumerable<CategoriaProductoDto>>
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 