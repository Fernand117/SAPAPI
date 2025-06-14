using MediatR;

namespace SAP.Application.Features.Productos.Commands.DeleteProducto
{
    public class DeleteProductoCommand : IRequest<bool>
    {
        public int ProductoId { get; set; }
    }
} 