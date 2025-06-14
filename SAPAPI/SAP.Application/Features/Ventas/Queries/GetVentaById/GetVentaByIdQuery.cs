using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Ventas.Queries.GetVentaById
{
    public class GetVentaByIdQuery : IRequest<VentaDto>
    {
        public int VentaId { get; set; }
    }
} 