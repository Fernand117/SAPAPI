using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Productos.Queries.SearchProductos
{
    public class SearchProductosQuery : IRequest<IEnumerable<ProductoDto>>
    {
        public string? SearchTerm { get; set; }
        public bool SoloActivos { get; set; } = true;
    }
}