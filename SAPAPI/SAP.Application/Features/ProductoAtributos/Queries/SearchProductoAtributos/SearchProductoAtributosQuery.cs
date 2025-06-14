using MediatR;
using SAP.Application.DTOs;
using System.Collections.Generic;

namespace SAP.Application.Features.ProductoAtributos.Queries.SearchProductoAtributos
{
    public class SearchProductoAtributosQuery : IRequest<IEnumerable<ProductoAtributoDto>>
    {
        public int? ProductoId { get; set; }
        public int? AtributoId { get; set; }
    }
} 