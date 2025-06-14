using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SAP.Domain.Interfaces;

namespace SAP.Application.Features.Productos.Commands.DeleteProducto
{
    public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, bool>
    {
        private readonly IProductoRepository _productoRepository;

        public DeleteProductoCommandHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<bool> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByIdAsync(request.ProductoId);
            if (producto == null)
                return false;

            // Eliminar atributos del producto
            await _productoRepository.DeleteAtributosAsync(request.ProductoId);

            // Eliminar el producto
            await _productoRepository.DeleteAsync(producto);

            return true;
        }
    }
} 