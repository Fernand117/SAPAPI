using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.DetalleVentas.Queries.GetDetalleVentaById
{
    public class GetDetalleVentaByIdQuery : IRequest<DetalleVentaDetalleDto>
    {
        public int DetalleVentaId { get; set; }
    }
} 