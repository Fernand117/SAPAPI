using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Productos.Queries.GetProductoById
{
    public class GetProductoByIdQuery : IRequest<ProductoDetalleDto>
    {
        public int ProductoId { get; set; }
    }
} 