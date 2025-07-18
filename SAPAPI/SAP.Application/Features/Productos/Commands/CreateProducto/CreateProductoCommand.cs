using MediatR;
using SAP.Application.DTOs;

namespace SAP.Application.Features.Productos.Commands.CreateProducto
{
    public class CreateProductoCommand : IRequest<ProductoDto>
    {
        public required CreateProductoDto Producto { get; set; }
    }
} 