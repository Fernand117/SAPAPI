using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Productos.Commands.UpdateProducto
{
    public class UpdateProductoCommand : IRequest<ProductoDto>
    {
        public UpdateProductoDto? Producto { get; set; }
    }
}