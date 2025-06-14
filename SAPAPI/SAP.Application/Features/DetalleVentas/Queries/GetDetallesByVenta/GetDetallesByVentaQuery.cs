using System.Collections.Generic;
using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.DetalleVentas.Queries.GetDetallesByVenta
{
    public class GetDetallesByVentaQuery : IRequest<IEnumerable<DetalleVentaDto>>
    {
        public int VentaId { get; set; }
    }
} 