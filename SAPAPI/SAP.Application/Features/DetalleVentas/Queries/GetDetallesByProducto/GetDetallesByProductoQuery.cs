using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.DetalleVentas.Queries.GetDetallesByProducto
{
    public class GetDetallesByProductoQuery : IRequest<IEnumerable<DetalleVentaDto>>
    {
        public int ProductoId { get; set; }
    }
} 