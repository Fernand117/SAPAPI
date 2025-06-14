using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.InventarioVendedores.Queries.GetInventarioVendedorById
{
    public class GetInventarioVendedorByIdQuery : IRequest<InventarioVendedorDetalleDto>
    {
        public int InventarioVendedorId { get; set; }
    }
} 