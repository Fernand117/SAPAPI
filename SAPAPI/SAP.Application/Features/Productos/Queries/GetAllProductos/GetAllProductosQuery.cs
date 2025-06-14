using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Productos.Queries.GetAllProductos
{
    public class GetAllProductosQuery : IRequest<IEnumerable<ProductoDto>>
    {
        public bool SoloActivos { get; set; } = true;
    }
} 